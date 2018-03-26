namespace Emplonomy.API.ViewModels
{
    public class EmployeesViewModel
    {
        public Employees[] employees { get; set; }

    }

    public class Employees
    {
        public int DepId { get; set; }
        public int ManId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneCell { get; set; }
        public string Password { get; set; }

    }
}
