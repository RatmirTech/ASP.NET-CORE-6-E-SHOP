using WebShop.Models;

namespace WebShop.DataAccess.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
