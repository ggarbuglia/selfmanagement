using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// OrgMembership Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("OrgMemberships", Schema = "dbo")]
    public partial class OrgMembership : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the display name of the ad group.
        /// </summary>
        /// <value>
        /// The display name of the ad group.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string AdGroupDisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name of the ad group account.
        /// </summary>
        /// <value>
        /// The name of the ad group account.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string AdGroupAccountName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OrgMembership"/> is show.
        /// </summary>
        /// <value>
        ///   <c>true</c> if show; otherwise, <c>false</c>.
        /// </value>
        [ConcurrencyCheck, JsonPropertyOrder(3)]
        public bool Show { get; set; } = true;

        #endregion

        #region Parent Properties

        /// <summary>
        /// Gets or sets the structure identifier.
        /// </summary>
        /// <value>
        /// The structure identifier.
        /// </value>
        public int? StructureId { get; set; }

        /// <summary>
        /// Gets or sets the structure.
        /// </summary>
        /// <value>
        /// The structure.
        /// </value>
        public virtual OrgStructure? Structure { get; set; }

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
