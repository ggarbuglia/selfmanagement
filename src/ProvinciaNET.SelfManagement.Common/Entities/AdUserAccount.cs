using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProvinciaNET.SelfManagement.Common.Entities
{
    public class AdUserAccount : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string SamAccountName { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string UserPrincipalName { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string GivenName { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string SurName { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        [Required]
        public OrgLocation? Location { get; set; }

        [Required]
        public OrgMembership? Membership { get; set; }

        #endregion

        #region Child Properties

        public ICollection<AdUserAccountProvision>? AdUserAccountProvisions { get; set; }

        #endregion
    }
}
