using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirNetworks", Schema = "dbo")]
    public partial class VirNetwork : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>
        /// The mask.
        /// </value>
        [Required, JsonPropertyOrder(2)]
        public int Mask { get; set; }

        /// <summary>
        /// Gets or sets the gateway.
        /// </summary>
        /// <value>
        /// The gateway.
        /// </value>
        [Column(TypeName = "varchar(15)"), MaxLength(15), Required, JsonPropertyOrder(3)]
        public string Gateway { get; set; } = string.Empty;
    }
}