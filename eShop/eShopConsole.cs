using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Implementations;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop
{
    public partial class eShopConsole
    {
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly IReportsService _reportsService;
        private readonly IPurchaseOrderService _purchaseOrderService;

        public eShopConsole() 
        { 
            _productService = new ProductService();
            _departmentService = new DepartmentService();
            _reportsService = new ReportsService();
            _purchaseOrderService = new PurchaseOrderService();
        }

        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Add a new product");
            Console.WriteLine("2) Edit a product");
            Console.WriteLine("3) Get all products");
            Console.WriteLine("4) Get a product");
            Console.WriteLine("5) Delete a product");
            Console.WriteLine("6) Reports");
            Console.WriteLine("7) Purchase Orders");
            Console.WriteLine("0) Exit");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    AddProduct();
                    break;
                case "2":
                    EditProduct();
                    break;
                case "3":
                    GetAllProducts();
                    break;
                case "4":
                    GetProduct();
                    break;
                case "5":
                    DeleteProduct();
                    break;
                case "6":
                    bool showReportsMenu = true;
                    while (showReportsMenu) 
                    {
                        showReportsMenu = ReportsMenu();
                    }
                    break;
                case "7":
                    bool showPurchaseOrdersMenu = true;
                    while (showPurchaseOrdersMenu) 
                    {
                        showPurchaseOrdersMenu = PurchaseOrdersMenu();
                    }
                    break;
                default:
                    break;
            }

            return true;
        }

        private void AddProduct()
        {
            Console.WriteLine("Please indicate de required values for adding a new product:\n");
            int id = GetIntInput("Product Id: ");
            string name = GetStringInput("Name: ");
            decimal price = GetDecimalInput("Price: ");
            string description = GetStringInput("Description: ");
            string brand = GetStringInput("Brand: ");
            string sku = GetStringInput("SKU: ");

            Subdepartment subdepartment = AskForSubdepartment();

            try
            {
                var product = new Product(id, name, description, price, brand, sku);

                subdepartment.AddProduct(product);
                product.SetSubdepartment(subdepartment);

                _productService.AddProduct(product);

                Console.WriteLine("New product added successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void EditProduct()
        {
            int id = GetIntInput("Project Id (to update):");

            Product origProduct = _productService.GetProduct(id);

            if (origProduct != null)
            {
                Console.Write("New Product Name: ");
                string name = Console.ReadLine();
                Console.Write("New Product Description: ");
                string description = Console.ReadLine();
                Console.Write("New Product Brand: ");
                string brand = Console.ReadLine();
                Console.Write("New Product Price: ");
                string price = Console.ReadLine();

                try
                {
                    decimal priceDecimal;
                    if (string.IsNullOrEmpty(price))
                        priceDecimal = origProduct.Price;
                    else
                        if (!decimal.TryParse(price, out priceDecimal))
                        throw new FormatException("The value for Price is invalid");

                    if (string.IsNullOrEmpty(name))
                        name = origProduct.Name;

                    if (string.IsNullOrEmpty(description))
                        description = origProduct.Description;

                    if (string.IsNullOrEmpty(brand))
                        brand = origProduct.Brand;

                    _productService.UpdateProduct(new Product(origProduct.Id, name, description, priceDecimal, brand, origProduct.Sku, origProduct.Stock));
                    Console.WriteLine($"Product {origProduct.Id} was successfully updated");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"Product {id} doesn't exist");
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void GetAllProducts()
        {
            List<Product> products = _productService.GetProducts();

            if (products.Any())
                products.ForEach(product => Console.WriteLine(product.ToString()));
            else
                Console.WriteLine("Products List is Empty");

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void GetProduct()
        {
            int id = GetIntInput("Product Id: ");
            Product product = _productService.GetProduct(id);

            if (product != null)
                Console.WriteLine(product.ToString());
            else
                Console.WriteLine($"Product {id} Was Not Found");

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private void DeleteProduct()
        {
            int id = GetIntInput("Product Id (to delete): ");

            try
            {
                _productService.DeleteProduct(id);
                Console.WriteLine($"Product {id} deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }

        private Subdepartment AskForSubdepartment()
        {
            Console.WriteLine("Choose a Department:");
            List<Department> departmentsList = _departmentService.GetDepartments();

            for (int i = 0; i < departmentsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {departmentsList.ElementAt(i).Name}");
            }

            int selectedDepartment = GetIntInput("Deparment: ");
            Department department = departmentsList.ElementAt(selectedDepartment - 1);

            Console.WriteLine($"Choose a Subdepartment for {department.Name}: ");
            for (int i = 0; i < department.Subdepartments.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {department.Subdepartments.ElementAt(i).Name}");
            }

            int selectedSubdepartment = GetIntInput("Subdepartment: ");
            Subdepartment subdepartment = department.Subdepartments.ElementAt(selectedSubdepartment - 1);

            subdepartment.Department = department;
            return subdepartment;
        }

        #region UserInput
        private int GetIntInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;
            }
        }

        private decimal GetDecimalInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                    return result;
            }
        }

        private string GetStringInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    return input;
            }
        }
        #endregion
    }
}
