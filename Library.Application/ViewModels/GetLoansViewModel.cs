using Library.Core.Enums;

namespace Library.Application.ViewModels
{
    public class GetLoansViewModel
    {
        public GetLoansViewModel(int loanId, int userId, ELoanStatus status, int bookId, string bookTitle, string author, string isbn,decimal valuePerDay, decimal valuePerDayLate, DateTime publicationDate, DateTime startDateLoan, DateTime endDateLoan, DateTime? finishDateLoan, decimal? totalValuePaid, string? paymentId)
        {
            LoanId = loanId;
            UserId = userId;
            Status = status;
            BookId = bookId;
            BookTitle = bookTitle;
            BookAuthor = author;
            BookISBN = isbn;
            BookPublicationDate = publicationDate;
            StartDateLoan = startDateLoan;
            EndDateLoan = endDateLoan;
            FinishDateLoan = finishDateLoan;
            ValuePerDay = valuePerDay;
            ValuePerDayLate = valuePerDayLate;
            TotalValuePaid = totalValuePaid;
            PaymentId = paymentId;
        }

        public int LoanId { get; private set; }
        public int UserId { get; private set; }

        public int BookId { get; private set; }

        public string BookTitle { get; private set; }

        public string BookAuthor { get; private set; }

        public string BookISBN { get; private set; }

        public DateTime BookPublicationDate { get; private set; }

        public DateTime StartDateLoan { get; private set; }

        public DateTime EndDateLoan { get; private set; }

        public DateTime? FinishDateLoan { get; private set; }

        public ELoanStatus Status { get; private set; }

        public decimal ValuePerDay { get; private set; }

        public decimal ValuePerDayLate { get; private set; }

        public decimal? TotalValuePaid { get; private set; }

        public string? PaymentId { get; private set; }

    }
}
