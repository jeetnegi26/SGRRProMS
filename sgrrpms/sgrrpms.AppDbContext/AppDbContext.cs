using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sgrrpms.AppDbContext
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb() : base("PMSConnectionString")
        {
        }
        public DbSet<User> User { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssign> RoleAssign { get; set; }
        //public DbSet<FormMaster> FormMaster { get; set; }
        public DbSet<RoleDetails> RoleDetails { get; set; }
        //public DbSet<ModuleMaster> ModuleMaster { get; set; }

    }
}
