using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; } = new();

        public Subdepartment(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Subdepartment name can't be left empty");

            Id = id;
            Name = name;
        }

        public void AddProduct(Product product) 
            => Products.Add(product);
    }
}
