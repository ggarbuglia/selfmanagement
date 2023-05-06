using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities.Organization
{
    /// <summary>
    /// OrgMailDatabaseGroup Class
    /// </summary>
    /// <seealso cref="BaseEntity" />
    [Table("OrgMailDatabaseGroups", Schema = "dbo")]
    public partial class OrgMailDatabaseGroup : BaseEntity
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

        #endregion Properties

        #region Child Properties

        /// <summary>
        /// Gets or sets the structures.
        /// </summary>
        /// <value>
        /// The structures.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<OrgStructure>? Structures { get; }

        #endregion Child Properties
    }
}