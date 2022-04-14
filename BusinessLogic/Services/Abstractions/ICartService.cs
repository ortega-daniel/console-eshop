using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BusinessLogic.Services.Abstractions
{
    public interface ICartService
    {
        public void AddProduct(Product product);
        public void RemoveProduct(int productId);
        public Cart GetCart();
        public void CalculateTotal();
        public void UpdateProductQuantity(int productId, int qty);
        public bool ProductInCart(int productId);
        public Product GetProductFromCart(int productId);
        public void ClearCart();
    }
}
