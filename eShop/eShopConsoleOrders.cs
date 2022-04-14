using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool OrdersMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Get all orders");
            Console.WriteLine("0) Go back");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    GetAllOrders();
                    break;
                default:
                    break;
            }

            return true;
        }

        public void GetAllOrders() 
        {
            Console.Clear();
            var orders = _orderService.GetOrders();

            if (orders.Any())
                foreach (var order in orders)
                    Console.WriteLine(order);
            else
                Console.WriteLine("You haven't made any orders!");

            Console.Write("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
