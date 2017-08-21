using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MMM.Model
{
    public class Transaction : Entity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime SetDate { get; set; }
        public string Description { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}