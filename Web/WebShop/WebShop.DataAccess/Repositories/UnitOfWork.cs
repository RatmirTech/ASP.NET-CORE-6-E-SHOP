using WebShop.DataAccess.Data;

namespace WebShop.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
