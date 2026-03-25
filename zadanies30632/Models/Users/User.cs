namespace zadanies30632.Models.Users
{
    public abstract class User
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract int MaxRentals { get; }
        
        public abstract string UserType { get; }

        public User(string firstName, string lastName)
        {
            Id = _nextId++;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return "[" + Id + "] " + FirstName + " " + LastName;
        }
    }
}