using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities.Virtualization
{
    /// <summary>
    ///
    /// </summary>
    [Table("VirtualMachineDisks", Schema = "dbo")]
    public partial class VirtualMachineDisk
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        [Required, JsonPropertyOrder(1)]
        public int Index { get; set; } = 0;

        /// <summary>
        /// Gets or sets the type of the disk.
        /// </summary>
        /// <value>
        /// The type of the disk.
        /// </value>
        [Required, JsonPropertyOrder(2), Column(TypeName = "varchar(3)"), MaxLength(3)]
        public string DiskType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the disk size gb.
        /// </summary>
        /// <value>
        /// The disk size gb.
        /// </value>
        [Required, JsonPropertyOrder(3)]
        public int DiskSizeGB { get; set; } = 0;

        #region Parent Properties

        /// <summary>
        /// Gets or sets the virtual machine.
        /// </summary>
        /// <value>
        /// The virtual machine.
        /// </value>
        public virtual VirtualMachine VirtualMachine { get; set; } = new();

        #endregion Parent Properties
    }
}