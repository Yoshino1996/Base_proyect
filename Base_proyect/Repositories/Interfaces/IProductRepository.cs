using Base_proyect.Models;


namespace Base_proyect.Repositories.Interfaces
{
    public interface IProductRepository
    {

        List<Product> GetAll();
        Product? GetById(int id);
        void add(Product product);
        void update(Product product);
        void Delete(Product product);
    }
}
