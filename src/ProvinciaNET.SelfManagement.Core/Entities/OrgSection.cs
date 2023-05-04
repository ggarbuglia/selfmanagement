using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// OrgSection Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("OrgSections", Schema = "dbo")]
    public partial class OrgSection : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        /// <summary>
        /// Gets or sets the cost center identifier.
        /// </summary>
        /// <value>
        /// The cost center identifier.
        /// </value>
        public int? CostCenterId { get; set; }

        /// <summary>
        /// Gets or sets the cost center.
        /// </summary>
        /// <value>
        /// The cost center.
        /// </value>
        public virtual OrgCostCenter? CostCenter { get; set; }

        /// <summary>
        /// Gets or sets the direction identifier.
        /// </summary>
        /// <value>
        /// The direction identifier.
        /// </value>
        public int? DirectionId { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public virtual OrgDirection? Direction { get; set; }

        #endregion

        #region Child Properties

        /// <summary>
        /// Gets or sets the structures.
        /// </summary>
        /// <value>
        /// The structures.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<OrgStructure>? Structures { get; set; }

        #endregion
    }
}
