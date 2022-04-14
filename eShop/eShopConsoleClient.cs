using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool ClientMenu()
        {
            Console.Clear();
            Console.WriteLine("1) My Cart");
            Console.WriteLine("2) My Orders");
            Console.WriteLine("3) My Reports");
            Console.WriteLine("0) Main Menu");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    bool showCartMenu = true;
                    while (showCartMenu)
                    {
                        showCartMenu = CartMenu();
                    }
                    break;
                case "2":
                    bool showOrdersMenu = true;
                    while (showOrdersMenu)
                    {
                        showOrdersMenu = OrdersMenu();
                    }
                    break;
                case "3":
                    bool showClientReportsMenu = true;
                    while (showClientReportsMenu)
                    {
                        showClientReportsMenu = ClientReportsMenu();
                    }
                    break;
                default:
                    break;
            }

            return true;
        }
    }
}
