using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamApp.Models
{
    public class CustomerRoles
    {
        //Role Id, Cust Id
       [Key]
       public int Role_Id { get; set; }
        [ForeignKey("CustomerAccounts")]
        public int Cust_Id { get; set; }

    }
}
