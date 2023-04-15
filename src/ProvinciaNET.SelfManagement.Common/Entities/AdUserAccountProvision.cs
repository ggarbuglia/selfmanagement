using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProvinciaNET.SelfManagement.Common.Entities
{
    public class AdUserAccountProvision : BaseEntity
    {
        #region Properties

        public AdUserAccount? AdUserAccount { get; set; }

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Status { get; set; } = string.Empty;

        public bool HasError { get; set; } = false;

        [Required, Column(TypeName = "varchar(max)")]
        public string Error { get; set; } = string.Empty;

        #endregion
    }
}
