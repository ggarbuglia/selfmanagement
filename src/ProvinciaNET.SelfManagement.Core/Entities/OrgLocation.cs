using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    public class OrgLocation : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string PostalCode { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        #endregion

        #region Child Properties

        public ICollection<AdUserAccount>? AdUserAccounts { get; set; }

        #endregion
    }
}
