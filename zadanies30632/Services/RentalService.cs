using zadanies30632.Models;
using zadanies30632.Models.Users;

namespace zadanies30632.Services
{
    public class RentalService
    {
        private List<Models.Equipment.Equipment> _equipments = new List<Models.Equipment.Equipment>();
        private List<User> _users = new List<User>();
        private List<Rental> _rentals = new List<Rental>();
        private PenaltyCalculator _penaltyCalculator = new PenaltyCalculator();

        public void AddEquipment(Models.Equipment.Equipment equipment)
        {
            _equipments.Add(equipment);
            Console.WriteLine("Dodano sprzet: " + equipment.Name);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            Console.WriteLine("Dodano uzytkownika: " + user.FirstName + " " + user.LastName);
        }

        public void RentEquipment(int userId, int equipmentId, int rentalDays)
        {
            User user = null;
            foreach (var u in _users)
            {
                if (u.Id == userId) user = u;
            }

            Models.Equipment.Equipment equipment = null;
            foreach (var e in _equipments)
            {
                if (e.Id == equipmentId) equipment = e;
            }

            if (user == null)
            {
                Console.WriteLine("Nie znaleziono uzytkownika.");
                return;
            }

            if (equipment == null)
            {
                Console.WriteLine("Nie znaleziono sprzetu.");
                return;
            }

            if (!equipment.IsAvailable)
            {
                Console.WriteLine("Sprzet jest niedostepny.");
                return;
            }

            int activeRentals = 0;
            foreach (var r in _rentals)
            {
                if (r.User.Id == userId && !r.IsReturned()) activeRentals++;
            }

            if (activeRentals >= user.MaxRentals)
            {
                Console.WriteLine("Uzytkownik przekroczyl limit wypozyczen: " + user.MaxRentals);
                return;
            }

            equipment.IsAvailable = false;
            Rental rental = new Rental(user, equipment, DateTime.Now, rentalDays);
            _rentals.Add(rental);
            Console.WriteLine("Wypozyczono: " + equipment.Name + " dla " + user.FirstName);
        }

        public void ReturnEquipment(int rentalId)
        {
            Rental rental = null;
            foreach (var r in _rentals)
            {
                if (r.Id == rentalId) rental = r;
            }

            if (rental == null)
            {
                Console.WriteLine("Nie znaleziono wypozyczenia.");
                return;
            }

            if (rental.IsReturned())
            {
                Console.WriteLine("Sprzet juz zostal zwrocony.");
                return;
            }

            rental.ReturnDate = DateTime.Now;
            rental.PenaltyFee = _penaltyCalculator.Calculate(rental.DueDate, rental.ReturnDate.Value);
            rental.Equipment.IsAvailable = true;

            Console.WriteLine("Zwrocono: " + rental.Equipment.Name);
            if (rental.PenaltyFee > 0)
            {
                Console.WriteLine("Naliczono kare: " + rental.PenaltyFee + "zl");
            }
        }

        public void MarkUnavailable(int equipmentId)
        {
            foreach (var e in _equipments)
            {
                if (e.Id == equipmentId)
                {
                    e.IsAvailable = false;
                    Console.WriteLine("Oznaczono jako niedostepny: " + e.Name);
                    return;
                }
            }
            Console.WriteLine("Nie znaleziono sprzetu.");
        }

        public List<Rental> GetActiveRentalsForUser(int userId)
        {
            List<Rental> result = new List<Rental>();
            foreach (var r in _rentals)
            {
                if (r.User.Id == userId && !r.IsReturned()) result.Add(r);
            }
            return result;
        }

        public List<Rental> GetOverdueRentals()
        {
            List<Rental> result = new List<Rental>();
            foreach (var r in _rentals)
            {
                if (r.IsOverdue()) result.Add(r);
            }
            return result;
        }

        public List<Models.Equipment.Equipment> GetAllEquipments()
        {
            return _equipments;
        }

        public List<Rental> GetAllRentals()
        {
            return _rentals;
        }
    }
}