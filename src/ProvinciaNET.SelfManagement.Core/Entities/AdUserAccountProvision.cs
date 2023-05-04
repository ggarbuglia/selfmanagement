using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// AdUserAccountProvision Class
    /// </summary>
    /// <seealso cref="ProvinciaNET.SelfManagement.Core.Entities.BaseEntity" />
    [Table("AdUserAccountProvisions", Schema = "dbo")]
    public partial class AdUserAccountProvision : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), Required, JsonPropertyOrder(2)]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        [ConcurrencyCheck, JsonPropertyOrder(3)]
        public bool HasError { get; set; } = false;

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(max)"), Required, JsonPropertyOrder(4)]
        public string Error { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        /// <summary>
        /// Gets or sets the ad user account identifier.
        /// </summary>
        /// <value>
        /// The ad user account identifier.
        /// </value>
        public int? AdUserAccountId { get; set; }
        /// <summary>
        /// Gets or sets the ad user account.
        /// </summary>
        /// <value>
        /// The ad user account.
        /// </value>
        public virtual AdUserAccount? AdUserAccount { get; set; }

        #endregion
    }
}