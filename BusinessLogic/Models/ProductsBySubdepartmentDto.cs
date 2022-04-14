using System.Collections.Generic;
using DataLayer.Entities;

namespace BusinessLogic.Models
{
    public class ProductsBySubdepartmentDto
    {
        public Subdepartment Subdepartment { get; set; }
        public List<Product> Products { get; set; }
    }
}
