using zadanies30632.Models;
using zadanies30632.Models.Users;

namespace zadanies30632.Services;

public class RaportService
{
    private List<Models.Equipment.Equipment> _equipments;
    private List<Rental> _rentals;
    

    public RaportService(List<Models.Equipment.Equipment> equipments, List<Rental> rentals)
    {
        _equipments = equipments;
        _rentals = rentals;
    }
    
    public void ShowAllEquipments()
    {
        Console.WriteLine("----Cały sprzęt----");
        foreach (var eq in _equipments)
        {
                Console.WriteLine(eq.ToString());
        }
    }
    
    public void ShowAvailableEquipment()
    {
        Console.WriteLine("----Dostępny sprzęt----");
        foreach (var eq in _equipments)
        {
            if (eq.IsAvailable == true)
            {
                Console.WriteLine(eq.ToString());
            }
            
        }
    }

    public void ShowAvtiveRentalForUser(int userId)
    {
        Console.WriteLine("---- Aktywne wypożyczenia użytkowniika----");
        foreach (var r in _rentals)
            {
                if (r.User.Id == userId && r.IsReturned() == false)
                {
                    Console.WriteLine(r.ToString());
                }
            }
    }

    public void ShowOverdueRentals()
    {
        Console.WriteLine("---- Wypozyczenia po terminie----");
        foreach (var rent in _rentals)
        {
            if (rent.IsOverdue())
            {
                Console.WriteLine(rent.ToString());
            }
        }
    }
    
    public void ShowSummaryReport()
    {
        int totalEquipment = _equipments.Count;
        int availableEquipment = 0;
        int activeRentals = 0;
        int overdueRentals = 0;

        foreach (var equ in _equipments)
        {
            if (equ.IsAvailable == true)
                {
                availableEquipment++;
                }
        }

        foreach (var rent in _rentals)
        {
            if (!rent.IsReturned())
            {
                activeRentals++;
            }

            if (rent.IsOverdue())
            {
                overdueRentals++;
            }
        }
        

        Console.WriteLine("--- Raport podsumowujacy ---");
        Console.WriteLine("Sprzet lacznie: " + totalEquipment);
        Console.WriteLine("Sprzet dostepny: " + availableEquipment);
        Console.WriteLine("Aktywne wypozyczenia: " + activeRentals);
        Console.WriteLine("Przeterminowane wypozyczenia: " + overdueRentals);
    }
}