using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CollectReq> CollectReq { get; set; }
    }
}