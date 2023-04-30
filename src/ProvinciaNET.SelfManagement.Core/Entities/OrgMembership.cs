using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("OrgMemberships", Schema = "dbo")]
    public partial class OrgMembership : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        [ConcurrencyCheck, JsonPropertyOrder(3)]
        public bool Show { get; set; } = true;

        #endregion

        #region Parent Properties

        public int StructureId { get; set; }
        public virtual OrgStructure? Structure { get; set; }

        #endregion

        #region Child Properties

        [JsonIgnore]
        public virtual ICollection<AdUserAccount>? AdUserAccounts { get; set; }

        #endregion
    }
}
