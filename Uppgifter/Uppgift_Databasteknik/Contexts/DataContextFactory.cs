using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Uppgift_Databasteknik.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<DataContext>();
        builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexander\source\repos\Uppgifter\Uppgift_Databasteknik\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        return new DataContext(builder.Options);
    }
}
