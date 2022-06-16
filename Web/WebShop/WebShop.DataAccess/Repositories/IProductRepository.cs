using WebShop.Models;

namespace WebShop.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
