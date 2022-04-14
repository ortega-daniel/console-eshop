using BusinessLogic;
using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool PurchaseOrdersMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Create Purchase Order");
            Console.WriteLine("2) Get All Purchase Orders");
            Console.WriteLine("3) Change PO Status");
            Console.WriteLine("0) Go Back");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    CreatePurchaseOrder();
                    break;
                case "2":
                    GetAllPurchaseOrders();
                    break;
                case "3":
                    ChangePurchaseOrderStatus();
                    break;
                default:
                    break;
            }

            return true;
        }

        private void ChangePurchaseOrderStatus() 
        {
            int poNumber = GetIntInput("PO Number: ");
            
            Console.WriteLine("\nStatus List");
            foreach (var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                Console.WriteLine($"- {status}");
            }

            string poStatus = GetStringInput("\nStatus: ");
            if (Enum.TryParse(poStatus, out PurchaseOrderStatus newStatus)) 
            {
                try
                {
                    PurchaseOrder po = _purchaseOrderService.ChangeStatus(poNumber, newStatus);
                    
                    if (newStatus == PurchaseOrderStatus.Paid)
                    {
                        po.PurchasedProducts
                            .GroupBy(product => product.Id)
                            .Select(group => new { Id = group.Key, Qty = group.Sum(product => product.Stock)})
                            .ToList()
                            .ForEach(product => _productService.GetProduct(product.Id).AddStock(product.Qty));
                    }

                    Console.WriteLine($"PO {poNumber} status was successfully updated");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void CreatePurchaseOrder() 
        {
            try 
            {
                var providerList = TestData.GetProviders();
                providerList.ForEach(provider => Console.WriteLine($" {provider.Id} - {provider.Name}"));
                int inputProviderId = GetIntInput("\nProvider: ");

                var provider = providerList.Find(provider => provider.Id == inputProviderId);

                if (provider == null)
                    throw new ApplicationException($"Provider {inputProviderId} is not in the list");

                List<Product> purchaseOrderProducts = new();

                var productList = _productService.GetProducts();
                productList.ForEach(product => Console.WriteLine($" {product.Id} - {product.Name}, price: {product.Price}, stock: {product.Stock}"));

                // Ask for PO products
                do
                {
                    int inputProductId = GetIntInput("\nProduct: ");

                    var productAux = productList.Find(product => product.Id == inputProductId);

                    if (productAux == null)
                    {
                        Console.WriteLine($"Product {inputProductId} is not in the list");
                        Console.WriteLine("\n Press any key to continue...");
                        Console.ReadLine();
                        continue;
                    }

                    var product = new Product(productAux.Id, productAux.Name, productAux.Description, productAux.Price, productAux.Brand, productAux.Sku);

                    int purchaseOrderQty = GetIntInput("Purchase Order Qty: ");
                    product.UpdateStock(purchaseOrderQty);

                    purchaseOrderProducts.Add(product);

                    Console.WriteLine($"Product {product.Id} added to PO");

                    string continueAdding;
                    while (true) 
                    {
                        continueAdding = GetStringInput("Continue adding products? (y/n): ");
                        if (continueAdding.ToLower() == "y" || continueAdding.ToLower() == "n")
                            break;
                    }

                    if (continueAdding == "y")
                        continue;
                    else
                        break;
                } while (true);

                _purchaseOrderService.AddPurchaseOrder(new PurchaseOrder(provider, purchaseOrderProducts));
                Console.WriteLine("\nPurchase order created successfully");

                Console.Write("\nPress any key to continue...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void GetAllPurchaseOrders() 
        { 
            var data = _purchaseOrderService.GetPurchaseOrders();

            if (data.Any())
                foreach (var po in data)
                    Console.WriteLine(po.ToString());
            else 
                Console.WriteLine("Purchase Order list is empty");

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
