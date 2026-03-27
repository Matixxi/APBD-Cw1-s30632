using zadanies30632.Models.Equipment;
using zadanies30632.Models.Users;
using zadanies30632.Services;

namespace zadanies30632.UI
{
    public class ConsoleUI
    {
        private RentalService _rentalService = new RentalService();
        private RaportService _raportService;

        public ConsoleUI()
        {
            _raportService = new RaportService(
                _rentalService.GetAllEquipments(),
                _rentalService.GetAllRentals()
            );
        }

        public void Run()
        {
            Console.WriteLine("=== Dodawanie sprzetu ===");
            _rentalService.AddEquipment(new Laptop("Dell XPS", 16, "Intel i7"));
            _rentalService.AddEquipment(new Laptop("Lenovo ThinkPad", 8, "Intel i5"));
            _rentalService.AddEquipment(new Projector("Epson EB", 1080, true));
            _rentalService.AddEquipment(new Camera("Canon EOS", 24, true));
            
            Console.WriteLine("\n=== Dodawanie uzytkownikow ===");
            _rentalService.AddUser(new Student("Jan", "Kowalski"));
            _rentalService.AddUser(new Student("Anna", "Nowak"));
            _rentalService.AddUser(new Employee("Piotr", "Wisniewski"));

            
            Console.WriteLine("\n=== Caly sprzet ===");
            _raportService.ShowAllEquipments();
            
            Console.WriteLine("\n=== Wypozyczanie sprzetu ===");
            _rentalService.RentEquipment(1, 1, 7);
            _rentalService.RentEquipment(1, 2, 5);

            
            Console.WriteLine("\n=== Proba przekroczenia limitu ===");
            _rentalService.RentEquipment(1, 3, 3);
            
            Console.WriteLine("\n=== Proba wypozyczenia niedostepnego sprzetu ===");
            _rentalService.RentEquipment(2, 1, 3);
            
            Console.WriteLine("\n=== Oznaczenie sprzetu jako niedostepny ===");
            _rentalService.MarkUnavailable(4);

            
            Console.WriteLine("\n=== Zwrot w terminie ===");
            _rentalService.ReturnEquipment(1);
            
            Console.WriteLine("\n=== Zwrot z opoznieniem ===");
            _rentalService.GetAllRentals()[1].DueDate = DateTime.Now.AddDays(-5);
            _rentalService.ReturnEquipment(2);
            
            _rentalService.RentEquipment(3, 3, 7);
            _rentalService.GetAllRentals()[2].DueDate = DateTime.Now.AddDays(-3);
            
            Console.WriteLine("\n=== Aktywne wypozyczenia uzytkownika 3 ===");
            _raportService.ShowAvtiveRentalForUser(3);

            
            Console.WriteLine("\n=== Przeterminowane wypozyczenia ===");
            _raportService.ShowOverdueRentals();
            
            Console.WriteLine("\n");
            _raportService.ShowSummaryReport();
        }
    }
}