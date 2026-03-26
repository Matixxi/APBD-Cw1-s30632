using zadanies30632.Models.Users;

namespace zadanies30632.Models
{
    public class Rental
    {
        private static int _nextId = 1;

        public int Id { get; set; }
        public User User { get; set; }
        public Models.Equipment.Equipment Equipment { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal PenaltyFee { get; set; }

        public Rental(User user, Models.Equipment.Equipment equipment, DateTime rentalDate, int rentalDays)
        {
            Id = _nextId++;
            User = user;
            Equipment = equipment;
            RentalDate = rentalDate;
            DueDate = rentalDate.AddDays(rentalDays);
            ReturnDate = null;
            PenaltyFee = 0;
        }

        public bool IsReturned()
        {
            return ReturnDate != null;
        }

        public bool IsOverdue()
        {
            return !IsReturned() && DateTime.Now > DueDate;
        }

        public override string ToString()
        {
            return "[" + Id + "] " + User.FirstName + " " + User.LastName +
                   " - " + Equipment.Name +
                   " | Termin: " + DueDate.ToShortDateString() +
                   (IsReturned() ? " | Zwrocono: " + ReturnDate.Value.ToShortDateString() : " | Nie zwrocono") +
                   (PenaltyFee > 0 ? " | Kara: " + PenaltyFee + "zl" : "");
        }
    }
}