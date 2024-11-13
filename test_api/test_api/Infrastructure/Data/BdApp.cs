using Microsoft.EntityFrameworkCore;
using test_api.Model.Domaine.Entities;

namespace test_api.Infrastructure.Data
{
    public class BdApp : DbContext
    {
        public BdApp() { }
        public BdApp(DbContextOptions<BdApp>options) : base(options)  {
        
        }
        public DbSet<Product> Products { get; set; }
    }
}
