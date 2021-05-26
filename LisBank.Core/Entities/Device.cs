using System;
using System.Collections.Generic;

#nullable disable

namespace LisBank.Core.Entities
{
    public partial class Device
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; }
        public string OperatingSystem { get; set; }
        public string Version { get; set; }

        public virtual Origin IdNavigation { get; set; }
    }
}
