﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("OrgStructures", Schema = "dbo")]
    public partial class OrgStructure : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string Group { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(800)"), MaxLength(800), Required, JsonPropertyOrder(2)]
        public string OrgUnit { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        [Required]
        public virtual OrgMailDatabaseGroup? MailDatabaseGroup { get; set; }

        [Required]
        public virtual OrgSection? Section { get; set; }

        #endregion

        #region Child Properties

        [JsonPropertyOrder(110)]
        public ICollection<OrgMembership>? Memberships { get; set; }

        #endregion
    }
}
