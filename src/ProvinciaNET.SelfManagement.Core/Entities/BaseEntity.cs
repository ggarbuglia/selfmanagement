using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    public abstract class BaseEntity
    {
        #region Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), JsonPropertyOrder(-10)]
        public int Id { get; set; }

        [ConcurrencyCheck, JsonPropertyOrder(100)]
        public bool Active { get; set; } = true;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), Required, JsonPropertyOrder(101)]
        public string CreatedBy { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "datetime2"), Required, JsonPropertyOrder(102)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), JsonPropertyOrder(103)]
        public string? ModifiedBy { get; set; } = null;

        [ConcurrencyCheck, Column(TypeName = "datetime2"), JsonPropertyOrder(104)]
        public DateTime? ModifiedOn { get; set; } = null;

        #endregion
    }
}
