using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zero_Hunger.Models;

namespace Zero_Hunger
{
    public class CRContext : DbContext
    {
        public DbSet<CollectReq> CollectRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}