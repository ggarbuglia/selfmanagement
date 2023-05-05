using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirResources", Schema = "dbo")]
    public partial class VirResource : BaseEntity
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(2)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(3)]
        public string Value { get; set; } = String.Empty;
    }
}