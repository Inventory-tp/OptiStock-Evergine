using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OptiStock.MAUI.Database
{
    //DatabaseContextFactory class is a factory of our DataBase "OptiStockDbContext"
    //Its only one method CreateDbcontext() permits to create a new context to the database
    public class OptiStockDbContextFactory : IDesignTimeDbContextFactory<OptiStockDbContext>
    {
        public OptiStockDbContext CreateDbContext(string[] args = null)
        {
            //Create an instance of DbContextOptionsBuilder
            DbContextOptionsBuilder<OptiStockDbContext> options = new();

            //Create an instance of sqlite connection string with database path constant as parameter
            SqliteConnectionStringBuilder builder = new(Constants.DatabasePath);

            builder.DataSource = Path.GetFullPath(
                Path.Combine(
                    //If get Data from DataDirectory not found then from baseDirectory
                    AppDomain.CurrentDomain.GetData("DataDirectory") as string
                    ?? AppDomain.CurrentDomain.BaseDirectory,
                builder.DataSource));
            string connectionString = builder.ToString();

            //Setting Sqlite as our Database with the connection string as parameter
            options.UseSqlite(connectionString);

            //Creating a new instance of our Database context
            return new OptiStockDbContext(options.Options);
        }
    }
}
