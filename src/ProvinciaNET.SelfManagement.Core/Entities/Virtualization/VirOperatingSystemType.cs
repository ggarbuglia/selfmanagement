using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities.Virtualization
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirOperatingSystemTypes", Schema = "dbo")]
    public partial class VirOperatingSystemType : BaseEntity
    {
        /// <summary>
        /// Gets or sets the operating system.
        /// </summary>
        /// <value>
        /// The operating system.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string OperatingSystem { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the flavor.
        /// </summary>
        /// <value>
        /// The flavor.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(2)]
        public string Flavor { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(3)]
        public string Code { get; set; } = string.Empty;
    }
}