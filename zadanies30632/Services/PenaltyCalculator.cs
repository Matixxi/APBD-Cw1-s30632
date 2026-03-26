namespace zadanies30632.Services
{
    public class PenaltyCalculator
    {
        private const decimal PenaltyPerDay = 10m;

        public decimal Calculate(DateTime dueDate, DateTime returnDate)
        {
            if (returnDate <= dueDate)
            {
                return 0;
            }

            int daysLate = (returnDate - dueDate).Days;
            return daysLate * PenaltyPerDay;
        }
    }
}