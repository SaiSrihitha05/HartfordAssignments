using ProductsAPI.Models;
using ProductsAPI.DTOs;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        
        private static List<Product> products = new List<Product>()
        {
            new Product { ProductId = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 75000 },
            new Product { ProductId = 2, Name = "Mouse", Description = "Wireless Mouse", Price = 1500 }
        };

        public List<GetProductDto> GetAll()
        {
            return products.Select(p => new GetProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public GetProductDto GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return null;

            return new GetProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price
            };
        }

        public GetProductDto Create(CreateProductDto dto)
        {
            var newProduct = new Product
            {
                ProductId = products.Any() ? products.Max(p => p.ProductId) + 1 : 1,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            products.Add(newProduct);

            return new GetProductDto
            {
                ProductId = newProduct.ProductId,
                Name = newProduct.Name,
                Price = newProduct.Price
            };
        }

        public bool Update(int id, UpdateProductDto dto)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;

            return true;
        }

        public bool Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
                return false;

            products.Remove(product);
            return true;
        }
    }
}
