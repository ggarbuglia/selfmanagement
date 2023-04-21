using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    public abstract class BaseEntity
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public bool Active { get; set; } = true;

        [Required, Column(TypeName = "varchar(100)")]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(100)")]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        #endregion
    }
}
