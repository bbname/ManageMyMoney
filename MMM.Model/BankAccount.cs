using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMM.Model
{
    public class BankAccount : Entity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public int Currency { get; set; }
        public DateTime Created { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}