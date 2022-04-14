using System.Collections.Generic;
using DataLayer.Entities;

namespace BusinessLogic.Services.Abstractions
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
