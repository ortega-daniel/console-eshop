using BusinessLogic.Services.Implementations;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            eShopConsole console = new();
            bool showMenu = true;

            while (showMenu) 
            {
                showMenu = console.MainMenu();
            }
        }
    }
}
