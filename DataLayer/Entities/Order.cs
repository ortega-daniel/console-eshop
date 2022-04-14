using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        private static int _orderSeed = 1000;

        public Order(List<Product> products)
        {
            if (products is null || !products.Any())
                throw new ArgumentException("Product list can't be left empty");

            Id = _orderSeed++;
            Products = products;
            Total = products.Sum(product => product.Price * product.Stock);
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder result = new();

            result.AppendLine($"Order \t#{Id}");

            foreach (var product in Products)
                result.AppendLine($" {product.Name} - {(product.Price * product.Stock):c} Qty: {product.Stock}");

            result.AppendLine($" Total: {Total:c}");

            return result.ToString();
        }
    }
}
