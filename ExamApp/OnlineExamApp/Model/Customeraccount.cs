using System;
using System.Collections.Generic;

namespace OnlineExamApp.Model
{
    public partial class Customeraccount
    {
        public Customeraccount()
        {
            Assignedtesttable = new HashSet<Assignedtesttable>();
            Simtest = new HashSet<Simtest>();
        }

        public int CustId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public byte[] PasswordHash { get; set; }
        public int? PhoneNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? RoleId { get; set; }

        public virtual Customerrole Role { get; set; }
        public virtual ICollection<Assignedtesttable> Assignedtesttable { get; set; }
        public virtual ICollection<Simtest> Simtest { get; set; }
    }
}
