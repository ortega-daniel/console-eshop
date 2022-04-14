using System;

namespace DataLayer.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Subdepartment Subdepartment { get; set; }

        public Product(int id, string name, string description, decimal price, string brand, string sku, int stock = 1)
        {
            if (price < 0)
                throw new InvalidOperationException("Product price must be greater than or equal to 0");

            if (stock <= 0)
                throw new InvalidOperationException("Product stock must be greater than 0");

            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Product name can't be left empty");

            if (string.IsNullOrEmpty(description))
                throw new InvalidOperationException("Product description can't be left empty");

            if (string.IsNullOrEmpty(brand))
                throw new InvalidOperationException("Product brand can't be left empty");

            if (string.IsNullOrEmpty(sku))
                throw new InvalidOperationException("Product SKU can't be left empty");

            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Brand = brand;
            Sku = sku;
            Stock = stock;
        }

        public void SetSubdepartment(Subdepartment subdepartment) 
        {
            if (subdepartment == null)
                throw new ArgumentNullException("Subdepartment is needed");

            Subdepartment = subdepartment;
        }

        public void UpdateStock(int stock) 
        { 
            Stock = stock;
        }

        public void AddStock(int quantity) 
        {
            Stock += quantity;
        }

        public override string ToString()
        {
            return $"Product Id: {Id}\nName: {Name}\nDescription: {Description}\nPrice: {Price}\nStock: {Stock}\nDepartment: {Subdepartment?.Department}\nSubdepartment: {Subdepartment?.Name}";
        }
    }
}
