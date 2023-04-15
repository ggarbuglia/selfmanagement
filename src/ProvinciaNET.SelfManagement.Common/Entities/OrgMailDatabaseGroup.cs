﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinciaNET.SelfManagement.Common.Entities
{
    public class OrgMailDatabaseGroup : BaseEntity
    {
        #region Properties

        [Required, Column(TypeName = "varchar(100)"), MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        #endregion

        #region Child Properties

        public ICollection<OrgStructure>? Structures { get; set; }

        #endregion
    }
}
