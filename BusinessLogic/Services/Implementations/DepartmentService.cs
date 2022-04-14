using BusinessLogic.Services.Abstractions;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> _departmentList = TestData.DepartmentsList;

        public List<Department> GetDepartments() 
        {
            return _departmentList;
        }

        public List<Subdepartment> GetSubdepartments(string name)
        {
            return _departmentList.Find(department => department.Name.Equals(name))?.Subdepartments;
        }
    }
}
