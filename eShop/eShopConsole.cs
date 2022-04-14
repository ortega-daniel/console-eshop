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
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public eShopConsole() 
        { 
            _productService = new ProductService();
            _departmentService = new DepartmentService();
            _reportsService = new ReportsService();
            _purchaseOrderService = new PurchaseOrderService();
            _cartService = new CartService();
            _orderService = new OrderService();
        }

        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Admin Menu");
            Console.WriteLine("2) Client Menu");
            Console.WriteLine("0) Exit");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    bool showAdminMenu = true;
                    while (showAdminMenu)
                    {
                        showAdminMenu = AdminMenu();
                    }
                    break;
                case "2":
                    bool showClientMenu = true;
                    while (showClientMenu)
                    {
                        showClientMenu = ClientMenu();
                    }
                    break;
                default:
                    break;
            }

            return true;
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
