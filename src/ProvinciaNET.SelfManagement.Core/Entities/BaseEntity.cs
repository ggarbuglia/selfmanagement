using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    /// <summary>
    /// BaseEntity Abstract Class
    /// </summary>
    public abstract class BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), JsonPropertyOrder(-10)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseEntity" /> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [ConcurrencyCheck, JsonPropertyOrder(100)]
        public bool Active { get; set; } = true;

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), Required, JsonPropertyOrder(101)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "datetime2"), Required, JsonPropertyOrder(102)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), JsonPropertyOrder(103)]
        public string? ModifiedBy { get; set; } = null;

        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>
        /// The modified on.
        /// </value>
        [ConcurrencyCheck, Column(TypeName = "datetime2"), JsonPropertyOrder(104)]
        public DateTime? ModifiedOn { get; set; } = null;

        #endregion
    }
}
