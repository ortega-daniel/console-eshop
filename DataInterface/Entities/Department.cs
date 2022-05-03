namespace DataInterface.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subdepartment> Subdepartments { get; set; }
    }
}
