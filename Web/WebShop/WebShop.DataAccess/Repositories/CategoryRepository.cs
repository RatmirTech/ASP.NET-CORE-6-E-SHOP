using WebShop.DataAccess.Data;
using WebShop.Models;

namespace WebShop.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (categoryDB != null)
            {
                categoryDB.Name = category.Name;
                categoryDB.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
