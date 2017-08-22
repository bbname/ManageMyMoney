using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MMM.Model
{
    public abstract class Entity
    {
        public virtual string Id { get; set; }
    }
}