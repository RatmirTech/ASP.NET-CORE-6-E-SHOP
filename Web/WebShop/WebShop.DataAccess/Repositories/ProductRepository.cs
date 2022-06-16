using WebShop.DataAccess.Data;
using WebShop.Models;

namespace WebShop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
        public void Update(Product product)
        {
            var productDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productDB != null)
            {
                productDB.Name = product.Name;
                productDB.Description = product.Description;
                productDB.Price = product.Price;
                if (product.ImageUrl != null)
                    productDB.ImageUrl = product.ImageUrl;
            }
        }
    }
}
