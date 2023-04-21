using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    public class OrgStructure : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Group { get; set; } = string.Empty;

        [Required, Column(TypeName = "varchar(800)"), MaxLength(800)]
        public string OrgUnit { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        [Required]
        public virtual OrgMailDatabaseGroup? MailDatabaseGroup { get; set; }

        [Required]
        public virtual OrgSection? Section { get; set; }

        #endregion

        #region Child Properties

        public ICollection<OrgMembership>? Memberships { get; set; }

        #endregion
    }
}
