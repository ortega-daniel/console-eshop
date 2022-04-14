using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Entities
{
    public class PurchaseOrder
    {
        public int Number { get; private set; }
        public decimal Total { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public Provider Provider { get; private set; }
        public List<Product> PurchasedProducts { get; private set; }
        public PurchaseOrderStatus Status { get; set; }

        private static int _poSeed = 30000;

        public PurchaseOrder(Provider provider, List<Product> purchasedProducts, DateTime? purchaseDate = null)
        {
            if (provider == null)
                throw new ArgumentNullException("Provider can't be left empty");

            if (purchasedProducts == null || !purchasedProducts.Any())
                throw new ArgumentNullException("Purchased products can't be left empty");

            Number = _poSeed++;
            Total = purchasedProducts.Sum(product => product.Price * product.Stock);
            Provider = provider;
            PurchasedProducts = purchasedProducts;
            PurchaseDate = purchaseDate ?? DateTime.Now;
            Status = PurchaseOrderStatus.Pending;
        }

        public override string ToString()
        {
            StringBuilder result = new();
            
            result.AppendLine($"P.O. {Number} - {PurchaseDate.ToString("d")} ({Status.ToString().ToUpper()})");
            
            foreach (var product in PurchasedProducts)
            {
                result.AppendLine($" {product.Name}, {product.Stock}");
            }

            result.AppendLine($"Total: {Total:C}");

            return result.ToString();
        }

        public void ChangeStatus(PurchaseOrderStatus status) 
            => Status = status;
    }
}
