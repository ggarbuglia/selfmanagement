using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// OrgLocation Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("OrgLocations", Schema = "dbo")]
    public partial class OrgLocation : BaseEntity
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

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(3)]
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(4)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the display name of the ad group.
        /// </summary>
        /// <value>
        /// The display name of the ad group.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(5)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the ad group account.
        /// </summary>
        /// <value>
        /// The name of the ad group account.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(6)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        #endregion

        #region Child Properties

        /// <summary>
        /// Gets or sets the ad user accounts.
        /// </summary>
        /// <value>
        /// The ad user accounts.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<AdUserAccount>? AdUserAccounts { get; set; }

        #endregion
    }
}
