using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class CartService : ICartService
    {
        private Cart _cart = TestData.Cart;

        public void AddProduct(Product product) 
            => _cart.Products.Add(product);

        public void CalculateTotal() 
            => _cart.Total = _cart.Products.Sum(product => product.Price * product.Stock);

        public void ClearCart() 
            => _cart.ClearCart();

        public Cart GetCart() 
            => _cart;

        public Product GetProductFromCart(int productId)
        {
            var element = _cart.Products.Find(product => product.Id == productId);

            if (element is null)
                throw new ApplicationException($"Product {productId} doesn't exist");

            return element;
        }

        public bool ProductInCart(int productId) 
            => _cart.Products.Find(product => product.Id == productId) is not null;

        public void RemoveProduct(int productId)
        {
            var element = _cart.Products.Find(product => product.Id == productId);

            if (element is null)
                throw new ApplicationException($"Product {productId} doesn't exist");

            _cart.Products.Remove(element);
        }

        public void UpdateProductQuantity(int productId, int qty)
        {
            var element = _cart.Products.Find(product => product.Id == productId);

            if (element is null)
                throw new ApplicationException($"Product {productId} doesn't exist");

            element.UpdateStock(qty);
        }
    }
}
