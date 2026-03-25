namespace zadanies30632.Models.Users
{
    public class Student : User
    {
        public override int MaxRentals { get; } = 2;
        
        public override string UserType { get; } = "Student";
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " (" + UserType + ")";
        }
    }
}