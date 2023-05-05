using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// OrgCostCenter Class
    /// </summary>
    /// <seealso cref="BaseEntity" />
    [Table("OrgCostCenters", Schema = "dbo")]
    public partial class OrgCostCenter : BaseEntity
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

        #region Child Properties

        /// <summary>
        /// Gets or sets the sections.
        /// </summary>
        /// <value>
        /// The sections.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<OrgSection>? Sections { get; }

        #endregion
    }
}
