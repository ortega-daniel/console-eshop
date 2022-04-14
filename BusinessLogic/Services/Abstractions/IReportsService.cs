using BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services.Abstractions
{
    public interface IReportsService
    {
        public List<ProductReportDto> Report1();
        public List<ProductReportDto> Report2();
        public List<BrandReportDto> Report3();
        public List<PurchaseOrderDto> Report5();
        public void Report4();
        public List<PurchaseOrderDto> Report6();
        public List<PurchaseOrderDto> Report7();
        public ProductReportDto Report8();
        public decimal ClientReport1();
    }
}
