using Microsoft.EntityFrameworkCore;
using OptiStock.MAUI.Models;

namespace OptiStock.MAUI.Database
{
    public class OptiStockDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public OptiStockDbContext(DbContextOptions options) : base(options) { }
    }
}
