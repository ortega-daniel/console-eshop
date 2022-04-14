using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public List<Subdepartment> Subdepartments { get; private set; }

        public Department(int id, string name, List<Subdepartment> subdepartments)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidOperationException("Department name can't be left empty");

            if (subdepartments == null || !subdepartments.Any())
                throw new InvalidOperationException("Subdepartment list can't be left empty");

            Name = name;
            Subdepartments = subdepartments;
        }
    }
}
