namespace Library.Application.ViewModels
{
    public class FinishLoanViewModel
    {
        public FinishLoanViewModel(bool isLate, int daysLate)
        {
            IsLate = isLate;
            DaysLate = daysLate;
        }
        public bool IsLate { get; private set; }

        public int DaysLate { get; private set; }
    }
}
