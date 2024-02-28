using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagement.Services;
public class ProductService

{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public ProductService(IDbContextFactory<AppDbContext> dbContextFactory)

    {

        _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

    }
    /// <summary>
    /// This method returns the list of product
    /// </summary>
    /// <returns></returns>
    public async Task<List<Product>> GetAllProductsAsync()
    {
        using (var context = _dbContextFactory.CreateDbContext())
        {
            return await context.Products.ToListAsync();
        }
    }
    /// <summary>
    /// This method adds a new product to the DbContext and saves it
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task AddProduct(Product product)
    {
        using (var contex = _dbContextFactory.CreateDbContext())
        {
            contex.Products.Add(product);
            await contex.SaveChangesAsync();
        }
    }
    /// <summary>
    /// This method finds a product by their ID
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public async Task<Product> GetProductByIdAsync(int productId)
    {
        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var product = await context.Products.FindAsync(productId);
                if (product == null)
                {
                    // If the product with the specified ID is not found handle the exception
                    throw new KeyNotFoundException($"Product with ID {productId} not found");
                }
                return product;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// This method updates an existing product and saves the changes
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task UpdateProductAsync(Product product)
    {
        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var existingProduct = await context.Products.FindAsync(product.ProductID);

                if (existingProduct != null)
                {
                    context.Entry(existingProduct).CurrentValues.SetValues(product);
                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException($"Product with ID {product.ProductID} not found");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    /// <summary>
    /// This method deletes an existing product and saves the changes
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task DeleteProductAsync(int productId)
    {
        try
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Product product = await GetProductByIdAsync(productId);
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

}