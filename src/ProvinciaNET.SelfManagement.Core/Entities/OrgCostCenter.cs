using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("OrgCostCenters", Schema = "dbo")]
    public partial class OrgCostCenter : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        #endregion

        #region Child Properties

        [JsonPropertyOrder(110)]
        public ICollection<OrgSection>? Sections { get; set; }

        #endregion
    }
}
