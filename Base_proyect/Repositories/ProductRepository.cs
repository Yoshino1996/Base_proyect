using Base_proyect.Data;
using Base_proyect.Models;
using Base_proyect.Repositories.Interfaces;

namespace Base_proyect.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Product> GetAll() { 

            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
