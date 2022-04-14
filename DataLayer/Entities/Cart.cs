using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        public Cart()
        {
            Products = new();
            Total = 0;
        }

        public void ClearCart() 
        { 
            Products.Clear();
            Total = 0;
        }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine("Your Cart\n");
            foreach (var product in Products)
            {
                result.AppendLine($" {product.Id} - {product.Name}\n {(product.Price * product.Stock):c} Qty: {product.Stock}\n");
            }

            result.AppendLine($"Total: {Total:c}");

            return result.ToString();
        }
    }
}
