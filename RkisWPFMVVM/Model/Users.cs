using System;
using System.Collections.Generic;

namespace RkisWPFMVVM
{
    public partial class Users
    {
        public Users()
        {
            TaskIdUserCreationNavigations = new HashSet<Tasks>();
            TaskIdUserTakeNavigations = new HashSet<Tasks>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Sername { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Tasks> TaskIdUserCreationNavigations { get; set; }
        public virtual ICollection<Tasks> TaskIdUserTakeNavigations { get; set; }
    }
}
