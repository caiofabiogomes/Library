using Library.Core.Enums;
using Library.Core.Exceptions;

namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan()
        {
        }
        public Loan(int userId, int bookId, DateTime endDateLoan, decimal valuePerDay, decimal valuePerDayLate)
        {
            UserId = userId;
            BookId = bookId;
            StartDateLoan = DateTime.Now;
            EndDateLoan = endDateLoan;
            Status = ELoanStatus.InProgress;
            ValuePerDay = valuePerDay;
            ValuePerDayLate = valuePerDayLate;
            ValidateEndLoanDate();
        }
        public Loan(int userId, int bookId, DateTime startDateLoan, DateTime endDateLoan, decimal valuePerDay, decimal valuePerDayLate)
        {
            UserId = userId;
            BookId = bookId;
            StartDateLoan = startDateLoan;
            EndDateLoan = endDateLoan;
            Status = ELoanStatus.InProgress;
            ValuePerDay = valuePerDay;
            ValuePerDayLate = valuePerDayLate;
            ValidateEndLoanDate();
        }
        public Loan(int userId, DateTime endDateLoan, Book book)
        {
            UserId = userId;
            BookId = book.Id;
            StartDateLoan = DateTime.Now;
            EndDateLoan = endDateLoan;
            Status = ELoanStatus.InProgress;
            Book = book;
            ValidateEndLoanDate();
        }
        public int UserId { get; private set; }

        public User User { get; private set; }

        public int BookId { get; private set; }

        public Book Book { get; private set; }

        public DateTime StartDateLoan { get; private set; }

        public DateTime EndDateLoan { get; private set; }

        public DateTime? FinishDateLoan { get; private set; }

        public ELoanStatus Status { get; private set; }

        public decimal ValuePerDay { get; private set; }

        public decimal ValuePerDayLate { get; private set; }

        public decimal? TotalValuePaid { get; private set; }

        public string? PaymentId { get; private set; }


        public void FinishLoan(DateTime finishDate, decimal totalValuePaid, string paymentId)
        {
            if (Status == ELoanStatus.PaymentPending)
            {
                Status = ELoanStatus.Payed;
                FinishDateLoan = finishDate;
                TotalValuePaid = totalValuePaid;
                PaymentId = paymentId;
                ValidateFinishLoanDate();
            }
        }

        public void CancelLoan()
        {
            Status = ELoanStatus.Canceled;
        }

        public void PaymentPending()
        {
            Status = ELoanStatus.PaymentPending;
        }

        public decimal ValueToPayToFinishLoan(DateTime finishDateLoan)
        {
            decimal valueToPay = 0;

            int daysLate = (int)(finishDateLoan - EndDateLoan).TotalDays;
            int loanDays = (int)(EndDateLoan - StartDateLoan).TotalDays;

            if (daysLate > 0)
                valueToPay = daysLate * ValuePerDayLate;

            valueToPay += loanDays * ValuePerDay;

            return valueToPay;
        }

        private void ValidateFinishLoanDate()
        {
            if (FinishDateLoan < StartDateLoan)
                throw new EndDateLoanInvalidException("The loan finish date cannot be less than the start date.");
        }

        private void ValidateEndLoanDate()
        {
            if (EndDateLoan < StartDateLoan)
                throw new EndDateLoanInvalidException("The loan end date cannot be less than the start date.");
        }

    }
}
