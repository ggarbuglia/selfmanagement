using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Common.Entities
{
    public class OrgMembership : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        [Required]
        public bool Show { get; set; } = true;

        #endregion

        #region Parent Properties

        [Required]
        public OrgStructure? Structure { get; set; }

        #endregion

        #region Child Properties

        public ICollection<AdUserAccount>? AdUserAccounts { get; set; }

        #endregion
    }
}
