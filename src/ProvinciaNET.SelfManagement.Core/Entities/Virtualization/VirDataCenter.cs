using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirDataCenters", Schema = "dbo")]
    public partial class VirDataCenter : BaseEntity 
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        #region Child Properties

        /// <summary>
        /// Gets or sets the clusters.
        /// </summary>
        /// <value>
        /// The clusters.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<VirCluster>? Clusters { get; set; }

        #endregion
    }
}