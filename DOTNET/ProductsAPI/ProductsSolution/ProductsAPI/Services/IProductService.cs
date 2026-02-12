using ProductsAPI.DTOs;

namespace ProductsAPI.Services
{
    public interface IProductService
    {
        List<GetProductDto> GetAll();

        GetProductDto GetById(int id);

        GetProductDto Create(CreateProductDto dto);

        bool Update(int id, UpdateProductDto dto);

        bool Delete(int id);
    }
}

