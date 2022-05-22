using System;
using System.Collections.Generic;

namespace RkisWPFMVVM
{
    public partial class StatusTabl
    {
        public StatusTabl()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int IdStatus { get; set; }
        public string? NameStatus { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
