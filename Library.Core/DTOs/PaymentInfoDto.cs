namespace Library.Core.DTOs
{
    public class PaymentInfoDto
    {
        public PaymentInfoDto(int loanId, decimal value, DateTime finishDateLoan)
        {
            LoanId = loanId;
            Value = value;
            FinishDateLoan = finishDateLoan;
        }

        public int LoanId { get; private set; }

        public decimal Value { get; private set; }

        public DateTime FinishDateLoan { get; private set; }
    }
}
