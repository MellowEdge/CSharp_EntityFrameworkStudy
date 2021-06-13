using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class WorkerContext : DbContext
    {
        public WorkerContext()
            : base("DbConnection")
        { }

        public DbSet<Worker> Workers { get; set; }
    }
}
