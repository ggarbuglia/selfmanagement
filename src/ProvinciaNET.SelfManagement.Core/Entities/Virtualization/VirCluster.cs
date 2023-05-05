using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirClusters", Schema = "dbo")]
    public partial class VirCluster : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        #region Parent Properties

        /// <summary>
        /// Gets or sets the data center identifier.
        /// </summary>
        /// <value>
        /// The data center identifier.
        /// </value>
        public int DataCenterId { get; set; }

        /// <summary>
        /// Gets or sets the data center.
        /// </summary>
        /// <value>
        /// The data center.
        /// </value>
        public virtual VirDataCenter? DataCenter { get; set; } = null;

        #endregion
    }
}