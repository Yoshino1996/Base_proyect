using Base_proyect.DTOs;
using Base_proyect.Exceptions;
using Base_proyect.Models;
using Base_proyect.Repositories.Interfaces;
using Base_proyect.Services.Interfaces;
using Base_proyect.Middleware;

namespace Base_proyect.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDto> GetAll()
        {
            var products = _repository.GetAll();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }
        public ProductDto GetById(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }




        public ProductDto Create(ProductCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Name is required");
            }
            if (dto.Price <= 0)
            {
                throw new ValidationException("price must be greater than zero");
            }
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _repository.add(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public ProductDto Update(int id, ProductCreateDto dto)
        {
            var product = _repository.GetById(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ValidationException("Name is required");
            }
            if (dto.Price <= 0)
            {
                throw new ValidationException("price must be greater than zero");
            }

            product.Name = dto.Name;
            product.Price = dto.Price;

            _repository.update(product);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product==null)
            {
                throw new NotFoundException("product not found");
            }

            _repository.Delete(product);
        }

    }
}
