using Base_proyect.Models;



namespace Base_proyect.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product Create(Product product);
        Product Update(int id, Product product);
        void Delete(int id);
    }
}
