using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace BusinessLogic.Models
{
    public class DepartmentHierarchyDto
    {
        public Department Department { get; set; }
        public List<ProductsBySubdepartmentDto> Child { get; set; }
    }
}
