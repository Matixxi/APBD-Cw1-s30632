namespace zadanies30632.Models.Users
{
    public class Employee : User
    {
        public override int MaxRentals { get; } = 5;
        public override string UserType { get; } = "Pracownik";

        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " (" + UserType + ")";
        }
    }
}