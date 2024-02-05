using CarReviewApp.Data;
using CarReviewApp.Models;
using CarReviewApp.Interfaces;


namespace CarReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Category.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Category.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Category.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Car> GetCarByCategory(int categoryId)
        {
            return _context.CarCategories.Where(e => e.CategoryId == categoryId).Select(k => k.Car).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}