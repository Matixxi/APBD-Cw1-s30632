namespace zadanies30632.Models.Equipment
{
    public abstract class Equipment
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public Equipment(string name)
        {
            Id = _nextId++;
            Name = name;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return "[" + Id + "] " + Name + " - " + (IsAvailable ? "Dostepny" : "Niedostepny");
        }
    }
}