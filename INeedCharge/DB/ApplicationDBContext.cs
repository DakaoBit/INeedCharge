using INeedCharge.Models.ChargeStation.Operator;
using INeedCharge.Models.ChargeStation.Station;
using Microsoft.EntityFrameworkCore;

namespace INeedCharge.DB
{
    public class ApplicationDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ApplicationDb");
        }
        /// <summary>
        /// 營運業者
        /// </summary>
        public DbSet<Operator> Operators { get; set; }
 
    }
}
