using Uppgift_Databasteknik.Contexts;
using Uppgift_Databasteknik.Entities;

namespace Uppgift_Databasteknik_Test;

public class DataContextFactoryTests
{
    [Fact]
    public void CreateDbContext_CanConnectToDatabaseAndQueryData()
    {
        // Arrange
        var factory = new DataContextFactory();
        using var context = factory.CreateDbContext(null!);

        // Act
        var products = context.Products.ToList();

        // Assert   
        Assert.NotNull(products);
        Assert.IsType<List<ProductEntity>>(products);
    }
}
