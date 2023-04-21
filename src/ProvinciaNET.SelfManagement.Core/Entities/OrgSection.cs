using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    public class OrgSection : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        [Required]
        public virtual OrgCostCenter? CostCenter { get; set; }

        [Required]
        public virtual OrgDirection? Direction { get; set; }

        #endregion

        #region Child Properties

        public ICollection<OrgStructure>? Structures { get; set; }

        #endregion
    }
}
