using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private bool ReportsMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Top 5 productos mas caros ordenados por precio mas alto");
            Console.WriteLine("2) Productos con 5 unidades o menos ordenados por unidades");
            Console.WriteLine("3) Nombre de productos por marcas ordenados por nombre de producto");
            Console.WriteLine("4) Agrupacion de departamentos con subdepartamentos y nombres de productos");
            Console.WriteLine("5) Ordenes de compra con el estado pagado de los últimos 7 días");
            Console.WriteLine("6) Ordenes de compra que abastecieron el Teclado");
            Console.WriteLine("7) Ordenes de compra pendientes de pagar del proveedor Levis");
            Console.WriteLine("8) Producto con unidades mas compradas");
            Console.WriteLine("0) Go Back");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    Report1();
                    break;
                case "2":
                    Report2();
                    break;
                case "3":
                    Report3();
                    break;
                case "4":
                    Report4();
                    break;
                case "5":
                    Report5();
                    break;
                case "6":
                    Report6();
                    break;
                case "7":
                    Report7();
                    break;
                case "8":
                    Report8();
                    break;
                default:
                    break;
            }

            return true;
        }

        private bool ClientReportsMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Total gastado");
            Console.WriteLine("0) Go Back");

            Console.Write("\nSelect an option:");
            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    ClientReport1();
                    break;
                default:
                    break;
            }

            return true;
        }

        private void Report1()
        {
            _reportsService.Report1()
                .ForEach(dto => Console.WriteLine($"{dto.Name} {dto.Price}"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report2()
        {
            _reportsService.Report2()
                .ForEach(dto => Console.WriteLine($"{dto.Name} {dto.Stock}"));

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report3()
        {
            var data = _reportsService.Report3();

            foreach (var brandDto in data)
            {
                Console.WriteLine($"{brandDto.Brand}:");
                foreach (var productDto in brandDto.Products)
                {
                    Console.WriteLine($"\t{productDto.Name}");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report4()
        {
            var result = _productService.GetProducts()
                .GroupBy(p => new { Department = p.Subdepartment.Department, Subdepartment = p.Subdepartment.Name })
                .GroupBy(group => group.Key.Department);

            foreach (var department in result)
            {
                Console.WriteLine($"- Department: {department.Key}");
                foreach (var subdepartment in department)
                {
                    Console.WriteLine($"\t- Subdepartment: {subdepartment.Key.Subdepartment}");
                    foreach (var product in subdepartment)
                    {
                        Console.WriteLine($"\t\t- {product.Name}");
                    }
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report5() 
        {
            var result = _reportsService.Report5();

            foreach (var po in result)
                Console.WriteLine($"PO {po.Number} - {po.PurchaseDate:d}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report6() 
        {
            var result = _reportsService.Report6();

            foreach (var po in result)
                Console.WriteLine($"PO {po.Number} - {po.PurchaseDate:d}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report7() 
        {
            var result = _reportsService.Report7();

            foreach (var po in result)
                Console.WriteLine($"PO {po.Number} - {po.PurchaseDate:d}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void Report8() 
        {
            var data = _reportsService.Report8();

            Console.WriteLine($"{data.Name} - {data.Stock} total units from POs");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void ClientReport1() 
        {
            var data = _reportsService.ClientReport1();

            Console.WriteLine($"Total amount spent: {data:c}");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
