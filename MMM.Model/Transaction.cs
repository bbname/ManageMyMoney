using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMM.Model
{
    public class Transaction : Entity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime Created { get; set; }
    }
}