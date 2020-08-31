using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Customerrole
    {
        public Customerrole()
        {
            Customeraccount = new HashSet<Customeraccount>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Customeraccount> Customeraccount { get; set; }
    }
}
