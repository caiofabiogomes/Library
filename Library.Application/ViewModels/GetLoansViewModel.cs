using Library.Core.Enums;

namespace Library.Application.ViewModels
{
    public class GetLoansViewModel
    {
        public GetLoansViewModel(int loanId, int userId, ELoanStatus status, int bookId, string bookTitle, string author, string isbn, DateTime publicationDate, DateTime startDateLoan, DateTime endDateLoan, DateTime? finishDateLoan)
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

    }
}
