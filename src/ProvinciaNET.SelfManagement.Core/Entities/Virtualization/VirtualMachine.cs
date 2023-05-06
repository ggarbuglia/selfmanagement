using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities.Virtualization
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("VirtualMachines", Schema = "dbo")]
    public partial class VirtualMachine : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column(TypeName = "varchar(10)"), MaxLength(10), Required, JsonPropertyOrder(1)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column(TypeName = "varchar(500)"), MaxLength(500), Required, JsonPropertyOrder(2)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the folder path.
        /// </summary>
        /// <value>
        /// The folder path.
        /// </value>
        [Column(TypeName = "varchar(300)"), MaxLength(300), Required, JsonPropertyOrder(3)]
        public string FolderPath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the cores.
        /// </summary>
        /// <value>
        /// The cores.
        /// </value>
        [Required, JsonPropertyOrder(4)]
        public int Cores { get; set; } = 0;

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        /// <value>
        /// The memory.
        /// </value>
        [Required, JsonPropertyOrder(5)]
        public int Memory { get; set; } = 0;

        /// <summary>
        /// Gets or sets a value indicating whether [use template].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use template]; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyOrder(6)]
        public bool UseTemplate { get; set; } = false;

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>
        /// The template.
        /// </value>
        [Column(TypeName = "varchar(50)"), MaxLength(50), JsonPropertyOrder(7)]
        public string? Template { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether [use image].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use image]; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyOrder(8)]
        public bool UseImage { get; set; } = false;

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        [Column(TypeName = "varchar(500)"), MaxLength(500), JsonPropertyOrder(9)]
        public string? ImagePath { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether [use DHCP].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use DHCP]; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyOrder(10)]
        public bool UseDhcp { get; set; } = true;

        /// <summary>
        /// Gets or sets the i PV4 address.
        /// </summary>
        /// <value>
        /// The i PV4 address.
        /// </value>
        [Column(TypeName = "varchar(15)"), MaxLength(15), JsonPropertyOrder(11)]
        public string? IPv4Address { get; set; } = null;

        /// <summary>
        /// Gets or sets the DNS address1.
        /// </summary>
        /// <value>
        /// The DNS address1.
        /// </value>
        [Column(TypeName = "varchar(15)"), MaxLength(15), JsonPropertyOrder(12)]
        public string? DnsAddress1 { get; set; } = null;

        /// <summary>
        /// Gets or sets the DNS address2.
        /// </summary>
        /// <value>
        /// The DNS address2.
        /// </value>
        [Column(TypeName = "varchar(15)"), MaxLength(15), JsonPropertyOrder(13)]
        public string? DnsAddress2 { get; set; } = null;

        #region Parent Properties

        /// <summary>
        /// Gets or sets the data store.
        /// </summary>
        /// <value>
        /// The data store.
        /// </value>
        [JsonPropertyOrder(18)]
        public virtual VirDataStore DataStore { get; set; } = new();

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        /// <value>
        /// The network.
        /// </value>
        [JsonPropertyOrder(19)]
        public virtual VirNetwork Network { get; set; } = new();

        /// <summary>
        /// Gets or sets the type of the operating system.
        /// </summary>
        /// <value>
        /// The type of the operating system.
        /// </value>
        [JsonPropertyOrder(20)]
        public virtual VirOperatingSystemType OperatingSystemType { get; set; } = new();

        #endregion Parent Properties

        #region Child Properties

        /// <summary>
        /// Gets or sets the disks.
        /// </summary>
        /// <value>
        /// The disks.
        /// </value>
        [JsonPropertyOrder(14)]
        public virtual ICollection<VirtualMachineDisk>? Disks { get; }

        /// <summary>
        /// Gets or sets the category tags.
        /// </summary>
        /// <value>
        /// The category tags.
        /// </value>
        [JsonPropertyOrder(15)]
        public virtual ICollection<VirCategoryTag>? CategoryTags { get; }

        #endregion Child Properties
    }
}