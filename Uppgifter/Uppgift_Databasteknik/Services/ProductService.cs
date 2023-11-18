using System.Diagnostics;
using Uppgift_Databasteknik.Entities;
using Uppgift_Databasteknik.Models;
using Uppgift_Databasteknik.Repositories;

namespace Uppgift_Databasteknik.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly PricingUnitRepository _pricingUnitRepository;
    private readonly ProductCategoryRepository _productCategoryRepository;

    public ProductService(ProductRepository productRepository, PricingUnitRepository pricingUnitRepository, ProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _pricingUnitRepository = pricingUnitRepository;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<bool> CreateProductAsync(ProductRegistrationForm form)
    {
        try
        {
            if (! await _productRepository.ExistsAsync(x => x.ProductName == form.ProductName))
            {
                var pricingUnitEntity = await _pricingUnitRepository.GetAsync(x => x.UnitName == form.PricingUnit);
                pricingUnitEntity ??= await _pricingUnitRepository.CreateAsync(new PricingUnitEntity { UnitName = form.PricingUnit });

                var productCategoryEntity = await _productCategoryRepository.GetAsync(x => x.CategorytName == form.ProductCategory);
                productCategoryEntity ??= await _productCategoryRepository.CreateAsync(new ProductCategoryEntity { CategorytName = form.ProductCategory });

                var productEntity = await _productRepository.CreateAsync(new ProductEntity
                {
                    ProductName = form.ProductName,
                    ProductDescription = form.ProductDescription,
                    ProductPrice = form.ProductPrice,
                    PricingUnitId = pricingUnitEntity.Id,
                    ProductCategoryId = productCategoryEntity.Id
                });

                if (productEntity != null)
                    return true;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return false;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            return products;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
