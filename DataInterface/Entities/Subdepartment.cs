namespace DataInterface.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
