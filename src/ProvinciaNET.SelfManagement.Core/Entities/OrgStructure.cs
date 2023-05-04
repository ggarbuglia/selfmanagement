using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// OrgStructure Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("OrgStructures", Schema = "dbo")]
    public partial class OrgStructure : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the org unit.
        /// </summary>
        /// <value>
        /// The org unit.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(800)"), MaxLength(800), Required, JsonPropertyOrder(2)]
        public string OrgUnit { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        /// <summary>
        /// Gets or sets the mail database group identifier.
        /// </summary>
        /// <value>
        /// The mail database group identifier.
        /// </value>
        public int? MailDatabaseGroupId { get; set; }

        /// <summary>
        /// Gets or sets the mail database group.
        /// </summary>
        /// <value>
        /// The mail database group.
        /// </value>
        public virtual OrgMailDatabaseGroup? MailDatabaseGroup { get; set; }

        /// <summary>
        /// Gets or sets the section identifier.
        /// </summary>
        /// <value>
        /// The section identifier.
        /// </value>
        public int? SectionId { get; set; }


        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        public virtual OrgSection? Section { get; set; }

        #endregion

        #region Child Properties

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>
        /// The memberships.
        /// </value>
        [JsonIgnore]
        public virtual ICollection<OrgMembership>? Memberships { get; set; }

        #endregion
    }
}
