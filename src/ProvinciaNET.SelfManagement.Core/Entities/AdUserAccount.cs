using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// AdUserAccount Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("AdUserAccounts", Schema = "dbo")]
    public partial class AdUserAccount : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the sam account.
        /// </summary>
        /// <value>
        /// The name of the sam account.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string SamAccountName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the user principal.
        /// </summary>
        /// <value>
        /// The name of the user principal.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string UserPrincipalName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(200)"), MaxLength(200), Required, JsonPropertyOrder(3)]
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the given.
        /// </summary>
        /// <value>
        /// The name of the given.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(4)]
        public string GivenName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the sur.
        /// </summary>
        /// <value>
        /// The name of the sur.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(5)]
        public string SurName { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual OrgLocation? Location { get; set; }

        /// <summary>
        /// Gets or sets the membership identifier.
        /// </summary>
        /// <value>
        /// The membership identifier.
        /// </value>
        public int? MembershipId { get; set; }

        /// <summary>
        /// Gets or sets the membership.
        /// </summary>
        /// <value>
        /// The membership.
        /// </value>
        public virtual OrgMembership? Membership { get; set; }

        #endregion

        #region Child Properties

        /// <summary>
        /// Gets or sets the ad user account provisions.
        /// </summary>
        /// <value>
        /// The ad user account provisions.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<AdUserAccountProvision>? AdUserAccountProvisions { get; set; }

        #endregion
    }
}
