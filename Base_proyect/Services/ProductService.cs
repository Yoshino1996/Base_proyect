using Base_proyect.Models;
using Base_proyect.Repositories.Interfaces;
using Base_proyect.Services.Interfaces;


namespace Base_proyect.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }
        public Product? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public Product Create(Product product)
        {
            _repository.add(product);
            return product;
        }
        public Product Update(int id, Product Update)
        {
            var product = _repository.GetById(id);

            if(product==null)
                return null!;

            product.Name = Update.Name;
            product.Price = Update.Price;
            product.stock = Update.stock;


            _repository.update(product);
            return product;

        }
        public void Delete(int id)
        {
            var product = _repository.GetById(id);

            if (product != null)
                _repository.Delete(product);
        }

    }
}
