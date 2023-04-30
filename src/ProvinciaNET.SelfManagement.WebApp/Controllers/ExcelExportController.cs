using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace ProvinciaNET.SelfManagement.WebApp.Controllers
{
    public class ExcelExportController : Controller
    {
        /// <summary>
        /// Exports to CSV.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records">The records.</param>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public FileStreamResult ExportToCsv<T>(IEnumerable<T> records, string? filename) where T : class
        {
            var columns = GetTypeProperties(records.First().GetType());

            var sb = new StringBuilder();
            foreach (var record in records)
            {
                var row = (columns.Select(column => $"{GetObjectPropertyValue(record, column.Key)}".Trim())).ToList();
                sb.AppendLine(string.Join(",", row.ToArray()));
            }

            var ms = new MemoryStream(UTF8Encoding.Default.GetBytes($"{string.Join(",", columns.Select(c => c.Key))}{Environment.NewLine}{sb}"));

            return new FileStreamResult(ms, "text/csv")
            {
                FileDownloadName = (!string.IsNullOrEmpty(filename) ? filename : "Export") + ".csv"
            };
        }

        /// <summary>
        /// Exports to XLSX.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="records">The records.</param>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public FileStreamResult ExportToXlsx<T>(IEnumerable<T> records, string? filename) where T : class
        {
            var columns = GetTypeProperties(records.First().GetType());
            var ms = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                var wb = document.AddWorkbookPart();
                wb.Workbook = new Workbook();

                var ws = wb.AddNewPart<WorksheetPart>();
                ws.Worksheet = new Worksheet();

                var wss = wb.AddNewPart<WorkbookStylesPart>();
                GenerateWorkbookStylesPartContent(wss);

                var sheets = wb.Workbook.AppendChild(new Sheets());
                sheets.Append(new Sheet() { Id = wb.GetIdOfPart(ws), SheetId = 1, Name = "Sheet1" });

                wb.Workbook.Save();

                var sheetData = ws.Worksheet.AppendChild(new SheetData());

                var headerRow = new Row();

                foreach (var column in columns)
                {
                    headerRow.Append(new Cell() { CellValue = new CellValue(column.Key), DataType = new EnumValue<CellValues>(CellValues.String) });
                }

                sheetData.AppendChild(headerRow);

                foreach (var record in records)
                {
                    var row = new Row();

                    foreach (var column in columns)
                    {
                        var value = GetObjectPropertyValue(record, column.Key);
                        var stringValue = $"{value}".Trim();

                        var cell = new Cell();

                        var underlyingType = column.Value.IsGenericType && column.Value.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                            Nullable.GetUnderlyingType(column.Value) : column.Value;

                        var typeCode = Type.GetTypeCode(underlyingType);

                        if (typeCode == TypeCode.DateTime)
                        {
                            if (!string.IsNullOrWhiteSpace(stringValue))
                            {
                                cell.CellValue  = new CellValue() { Text = ((DateTime)value!).ToOADate().ToString(CultureInfo.InvariantCulture) };
                                cell.DataType   = new EnumValue<CellValues>(CellValues.Number);
                                cell.StyleIndex = (UInt32Value)1U;
                            }
                        }
                        else if (typeCode == TypeCode.Boolean)
                        {
                            cell.CellValue = new CellValue(stringValue.ToLowerInvariant());
                            cell.DataType  = new EnumValue<CellValues>(CellValues.Boolean);
                        }
                        else if (IsNumericType(typeCode))
                        {
                            if (value != null)
                            {
                                stringValue = Convert.ToString(value, CultureInfo.InvariantCulture);
                            }
                            cell.CellValue = new CellValue(stringValue!);
                            cell.DataType  = new EnumValue<CellValues>(CellValues.Number);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(stringValue);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }

                        row.Append(cell);
                    }

                    sheetData.AppendChild(row);
                }

                wb.Workbook.Save();
            }

            if (ms?.Length > 0) ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms!, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = (!string.IsNullOrEmpty(filename) ? filename : "Export") + ".xlsx"
            };
        }

        /// <summary>
        /// Gets the object property value.
        /// </summary>
        /// <param name="target">The object.</param>
        /// <param name="name">The property name.</param>
        /// <returns></returns>
        private static object? GetObjectPropertyValue(object target, string name)
        {
            if (target == null) return null;
            var t = target.GetType();
            if (t == null) return null;
            var p = t.GetProperty(name);
            if (p == null) return null;
            return p.GetValue(target);
        }

        /// <summary>
        /// Gets the type properties.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static IEnumerable<KeyValuePair<string, Type>> GetTypeProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && IsSimpleType(p.PropertyType))
                .OrderBy(p => p.CustomAttributes.First(ca => ca.AttributeType.Name == "JsonPropertyOrderAttribute").ConstructorArguments.First().Value)
                .Select(p => new KeyValuePair<string, Type>(p.Name, p.PropertyType));
        }

        /// <summary>
        /// Determines whether the specified type is simple type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is simple type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsSimpleType(Type type)
        {
            var underlyingType = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                Nullable.GetUnderlyingType(type) : type;

            if (underlyingType == typeof(Guid)) return true;

            var typeCode = Type.GetTypeCode(underlyingType);

            return typeCode switch
            {
                TypeCode.Boolean or
                TypeCode.Byte or
                TypeCode.Char or
                TypeCode.DateTime or
                TypeCode.Decimal or
                TypeCode.Double or
                TypeCode.Int16 or
                TypeCode.Int32 or
                TypeCode.Int64 or
                TypeCode.SByte or
                TypeCode.Single or
                TypeCode.String or
                TypeCode.UInt16 or
                TypeCode.UInt32 or
                TypeCode.UInt64 => true,
                _ => false,
            };
        }

        /// <summary>
        /// Determines whether the specified type is numeric type.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is numeric type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsNumericType(TypeCode typeCode)
        {
            return typeCode switch
            {
                TypeCode.Decimal or 
                TypeCode.Double or 
                TypeCode.Int16 or 
                TypeCode.Int32 or 
                TypeCode.Int64 or 
                TypeCode.UInt16 or 
                TypeCode.UInt32 or 
                TypeCode.UInt64 => true,
                _ => false,
            };
        }

        /// <summary>
        /// Generates the content of the workbook styles part.
        /// </summary>
        /// <param name="workbookStylesPart">The workbook styles part.</param>
        private static void GenerateWorkbookStylesPartContent(WorkbookStylesPart workbookStylesPart)
        {
            var fonts = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };
            fonts.Append(new Font() { Color = new Color() { Theme = (UInt32Value)1U }, FontName = new FontName() { Val = "Calibri" }, FontSize = new FontSize() { Val = 11D }, FontFamilyNumbering = new FontFamilyNumbering() { Val = 2 }, FontScheme = new FontScheme() { Val = FontSchemeValues.Minor } });

            var fills = new Fills() { Count = (UInt32Value)2U };
            fills.Append(new Fill() { PatternFill = new() { PatternType = PatternValues.None } });
            fills.Append(new Fill() { PatternFill = new() { PatternType = PatternValues.Gray125 } });

            var borders = new Borders() { Count = (UInt32Value)1U };
            borders.Append(new Border() { LeftBorder = new LeftBorder(), RightBorder = new RightBorder(), TopBorder = new TopBorder(), BottomBorder = new BottomBorder(), DiagonalBorder = new DiagonalBorder() });

            var cellStyleFormats = new CellStyleFormats() { Count = (UInt32Value)1U };
            cellStyleFormats.Append(new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U });

            var cellFormats = new CellFormats() { Count = (UInt32Value)2U };
            cellFormats.Append(new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U });
            cellFormats.Append(new CellFormat() { NumberFormatId = (UInt32Value)14U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true });

            var cellStyles = new CellStyles() { Count = (UInt32Value)1U };
            cellStyles.Append(new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U });

            var differentialFormats = new DifferentialFormats() { Count = (UInt32Value)0U };
            var tableStyles = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

            var stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");

            var stylesheetExtension2 = new StylesheetExtension() { Uri = "{9260A510-F301-46a8-8635-F512D64BE5F5}" };
            stylesheetExtension2.AddNamespaceDeclaration("x15", "http://schemas.microsoft.com/office/spreadsheetml/2010/11/main");
            stylesheetExtension2.Append(OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<x15:timelineStyles defaultTimelineStyle=\"TimeSlicerStyleLight1\" xmlns:x15=\"http://schemas.microsoft.com/office/spreadsheetml/2010/11/main\" />"));

            var stylesheetExtensionList = new StylesheetExtensionList();
            stylesheetExtensionList.Append(stylesheetExtension1);
            stylesheetExtensionList.Append(stylesheetExtension2);

            var stylesheet = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac x16r2 xr" } };

            stylesheet.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");
            stylesheet.AddNamespaceDeclaration("x16r2", "http://schemas.microsoft.com/office/spreadsheetml/2015/02/main");
            stylesheet.AddNamespaceDeclaration("xr", "http://schemas.microsoft.com/office/spreadsheetml/2014/revision");

            stylesheet.Append(fonts);
            stylesheet.Append(fills);
            stylesheet.Append(borders);
            stylesheet.Append(cellStyleFormats);
            stylesheet.Append(cellFormats);
            stylesheet.Append(cellStyles);
            stylesheet.Append(differentialFormats);
            stylesheet.Append(tableStyles);
            stylesheet.Append(stylesheetExtensionList);

            workbookStylesPart.Stylesheet = stylesheet;
        }
    }
}