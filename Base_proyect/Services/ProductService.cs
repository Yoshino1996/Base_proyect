using Base_proyect.DTOs;
using Base_proyect.Exceptions;
using Base_proyect.Models;
using Base_proyect.Repositories.Interfaces;
using Base_proyect.Services.Interfaces;
using Base_proyect.Mapping;
using AutoMapper;

namespace Base_proyect.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<ProductDto> GetAll()
        {
            var products = _repository.GetAll();

            return _mapper.Map<List<ProductDto>>(products);
        }
        public ProductDto GetById(int id)
        {
            var product = _repository.GetById(id);

            if (product == null)
                throw new NotFoundException("Product not found");

            return _mapper.Map<ProductDto>(product);
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
            var product = _mapper.Map<Product>(dto);

            _repository.add(product);

            return _mapper.Map<ProductDto>(product);
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

            _mapper.Map(dto, product);
            _repository.update(product);
            return _mapper.Map<ProductDto>(product);

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
