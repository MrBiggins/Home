using System.Data.Entity;

namespace Stock.DB {
    public class StockDbContext : DbContext {

        public DbSet<Branch> Branches { get; set; }
    }
}
