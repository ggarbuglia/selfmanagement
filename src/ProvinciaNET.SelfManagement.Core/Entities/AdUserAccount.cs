﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.Core.Entities
{
    [Table("AdUserAccounts", Schema = "dbo")]
    public partial class AdUserAccount : BaseEntity
    {
        #region Properties

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(1)]
        public string SamAccountName { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(2)]
        public string UserPrincipalName { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(200)"), MaxLength(200), Required, JsonPropertyOrder(3)]
        public string EmailAddress { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(4)]
        public string GivenName { get; set; } = string.Empty;

        [ConcurrencyCheck, Column(TypeName = "varchar(100)"), MaxLength(100), Required, JsonPropertyOrder(5)]
        public string SurName { get; set; } = string.Empty;

        #endregion

        #region Parent Properties

        public int LocationId { get; set; }
        public virtual OrgLocation? Location { get; set; }

        public int MembershipId { get; set; }
        public virtual OrgMembership? Membership { get; set; }

        #endregion

        #region Child Properties

        [JsonIgnore]
        public virtual ICollection<AdUserAccountProvision>? AdUserAccountProvisions { get; set; }

        #endregion
    }
}
