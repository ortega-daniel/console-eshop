using System;
using System.Collections.Generic;
using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class ProductService : IProductService
    {
        private List<Product> _productList = TestData.ProductList;

        public List<Product> GetProducts() 
        {
            return _productList;
        }

        public Product GetProduct(int id) 
        {
            return _productList.Find(p => p.Id == id);
        }

        public void AddProduct(Product product) 
        {
            _productList.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            int idx = _productList.FindIndex(p => p.Id == product.Id);

            if (idx != -1)
                _productList[idx] = product;
            else
                throw new ApplicationException($"Product with ID {product.Id} was not found");
        }

        public void DeleteProduct(int id)
        {
            Product element = _productList.Find(p => p.Id == id);

            if (element != null)
                _ = _productList.Remove(_productList.Find(p => p.Id == id));
            else
                throw new ApplicationException($"Product with ID {id} was not found");
        }
    }
}
