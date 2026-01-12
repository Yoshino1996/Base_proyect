using Base_proyect.Models;
using Base_proyect.DTOs;



namespace Base_proyect.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto? GetById(int id);
        ProductDto Create(ProductCreateDto dto);
        ProductDto Update(int id, ProductCreateDto dto);
        void Delete(int id);
    }
}
