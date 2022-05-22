using System;
using System.Collections.Generic;

namespace RkisWPFMVVM
{
    public partial class Tasks
    {
        public int IdTask { get; set; }
        public string? NameTask { get; set; }
        public string? Discription { get; set; }
        public DateTime? DatePubl { get; set; }
        public int? IdUserCreation { get; set; }
        public int? IdUserTake { get; set; }
        public int? Status { get; set; }

        public virtual Users? IdUserCreationNavigation { get; set; }
        public virtual Users? IdUserTakeNavigation { get; set; }
        public virtual StatusTabl? StatusNavigation { get; set; }
    }
}
