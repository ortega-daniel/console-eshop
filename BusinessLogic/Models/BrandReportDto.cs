using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class BrandReportDto
    {
        public string Brand { get; set; }
        public List<ProductReportDto> Products { get; set; }
    }
}
