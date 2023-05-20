using EFCoreproject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EFCoreAIGS.Data
{
    public class AIGSContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<SpendingDetail> SpendingDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OOQ5RCV\SQLEXPRESS;Database=AIGSDatabase;TrustServerCertificate=true;Trusted_Connection=true;");
            
            optionsBuilder.LogTo(Console.WriteLine,
                                            new[]
                                            {
                                                DbLoggerCategory.Database.Name },
                                            Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}
