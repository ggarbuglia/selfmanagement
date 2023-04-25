using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("OrgLocations", Schema = "dbo")]
    public partial class OrgLocation : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string Address { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(3)]
        public string PostalCode { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(4)]
        public string City { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(5)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(6)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        #endregion

        #region Child Properties

        [JsonPropertyOrder(110)]
        public ICollection<AdUserAccount>? AdUserAccounts { get; set; }

        #endregion
    }
}
