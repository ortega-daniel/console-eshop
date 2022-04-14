using BusinessLogic.Models;
using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Implementations
{
    public class ReportsService : IReportsService
    {
        private List<Product> _productList = TestData.ProductList;
        private List<PurchaseOrder> _poList = TestData.PurchaseOrderList;

        public List<ProductReportDto> Report1()
        {
            return _productList
                .OrderByDescending(product => product.Price)
                .Take(5)
                .Select(product => new ProductReportDto { Name = product.Name, Price = product.Price })
                .ToList();
        }

        public List<ProductReportDto> Report2()
        {
            return _productList
                .Where(product => product.Stock <= 5)
                .OrderBy(product => product.Stock)
                .Select(product => new ProductReportDto { Name = product.Name, Stock = product.Stock })
                .ToList();
        }

        public List<BrandReportDto> Report3()
        {
            return _productList
                .OrderBy(product => product.Name)
                .Select(product => new ProductReportDto { Name = product.Name, Brand = product.Brand })
                .GroupBy(productDto => productDto.Brand)
                .Select(group => new BrandReportDto { Brand = group.Key, Products = group.ToList() })
                .ToList();
        }

        public List<PurchaseOrderDto> Report5()
        {
            return _poList
                .Where(po => po.Status == PurchaseOrderStatus.Paid)
                .Where(po => po.PurchaseDate >= DateTime.Now.AddDays(-7))
                .Select(po => new PurchaseOrderDto { Number = po.Number, PurchaseDate = po.PurchaseDate})
                .OrderByDescending(po => po.PurchaseDate)
                .ToList();
        }

        public List<PurchaseOrderDto> Report6()
        {
            return _poList
                .Where(po => po.PurchasedProducts.Any(product => product.Id == 1))
                .Select(po => new PurchaseOrderDto { Number = po.Number, PurchaseDate = po.PurchaseDate })
                .ToList();
        }

        public List<PurchaseOrderDto> Report7()
        {
            return _poList
                .Where(po => po.Provider.Name == "Levis")
                .Where(po => po.Status != PurchaseOrderStatus.Paid)
                .Select(po => new PurchaseOrderDto { Number = po.Number, PurchaseDate = po.PurchaseDate})
                .ToList();
        }

        public ProductReportDto Report8()
        {
            return _poList
                .Where(po => po.Status == PurchaseOrderStatus.Paid)
                .SelectMany(po => po.PurchasedProducts)
                .GroupBy(product => product.Id)
                .Select(group => new { Id = group.Key, Qty = group.Sum(product => product.Stock) })
                .OrderByDescending(product => product.Qty)
                .Select(product => new ProductReportDto { Name = _productList.Find(p => p.Id == product.Id)?.Name, Stock = product.Qty})
                .First();
        }
    }
}
