using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class TestData
    {
        public static List<Department> DepartmentsList = new()
        {
            new Department(1, "Electronicos", new List<Subdepartment>
            {
                new Subdepartment(1, "TVs"),
                new Subdepartment(2, "Celulares"),
                new Subdepartment(3, "Audio"),
                new Subdepartment(4, "Accesorios de Computadoras"),
            }),
            new Department(2, "Muebles", new List<Subdepartment>
            {
                new Subdepartment(5, "Cocina"),
                new Subdepartment(6, "Comedor"),
                new Subdepartment(7, "Sala"),
            }),
            new Department(3, "Alimentos", new List<Subdepartment>
            {
                new Subdepartment(8, "Lacteos"),
                new Subdepartment(9, "Carnes frias"),
                new Subdepartment(10, "Pastas"),
            }),
        };

        public static List<Product> ProductList = new()
        { 
            new Product(1, "Teclado", "Teclado inalambrico", 500, "Logitech", "S1234", 50),
            new Product(2, "Monitor", "Monitor 21 pulgadas", 1200, "LG", "S1235", 25),
        };

        public static List<Provider> GetProviders() 
        { 
            List<Provider> providers = new();

            var p1 = new Provider(1, "Gamesa", "proveedor@gamesa.com");
            p1.SetAddress("Islas 123", "Mexicali");
            p1.SetPhoneNumber("6861234567");
            providers.Add(p1);

            var p2 = new Provider(2, "Levis", "proveedor@levis.com");
            p2.SetAddress("Islas Levis 123", "Tijuana");
            p2.SetPhoneNumber("6641236754");
            providers.Add(p2);

            var p3 = new Provider(3, "Mercado Chuchita", "proveedor@chuchita.com");
            p3.SetAddress("Nieves 9902", "Tijuana");
            p3.SetPhoneNumber("6645467894");
            providers.Add(p3);

            return providers;
        }

        public static List<PurchaseOrder> PurchaseOrderList = new();
        public static Cart Cart = new();
        public static List<Order> OrderList = new();
    }
}
