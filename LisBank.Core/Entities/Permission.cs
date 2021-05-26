using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Table { get; set; }
        public string Type { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
    }
}
