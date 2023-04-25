using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("AdUserAccountProvisions", Schema = "dbo")]
    public partial class AdUserAccountProvision : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, JsonPropertyOrder(1)]
        public int? AdUserAccountId { get; set; }

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), Required, JsonPropertyOrder(2)]
        public string Status { get; set; } = string.Empty;

        [ConcurrencyCheck, JsonPropertyOrder(3)]
        public bool HasError { get; set; } = false;

        [ConcurrencyCheck, Column(TypeName = "varchar(max)"), Required, JsonPropertyOrder(4)]
        public string Error { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        [Required]
        public AdUserAccount? AdUserAccount { get; set; }

        #endregion
    }
}