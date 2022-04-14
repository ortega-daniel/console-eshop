using DataLayer.Entities;
using System.Collections.Generic;

namespace BusinessLogic.Services.Abstractions
{
    public interface IDepartmentService
    {
        public List<Department> GetDepartments();
        public List<Subdepartment> GetSubdepartments(string name);
    }
}
