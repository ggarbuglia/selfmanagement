using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirCategoryTags", Schema = "dbo")]
    public partial class VirCategoryTag : BaseEntity
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(1)]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), Required, JsonPropertyOrder(2)]
        public string Tag { get; set; } = string.Empty;

        #region Parent Properties

        /// <summary>
        /// Gets or sets the virtual machine.
        /// </summary>
        /// <value>
        /// The virtual machine.
        /// </value>
        public virtual VirtualMachine VirtualMachine { get; set; } = new();

        #endregion
    }
}