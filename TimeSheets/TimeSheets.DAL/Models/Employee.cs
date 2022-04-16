namespace TimeSheets.DAL.Models
{
    public class Employee :Person
    {
        public int Department { get; set; }
        public int Division { get; set; }
    }
}
