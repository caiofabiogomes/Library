using Library.Core.Entities;
using Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class GetLoansByUserViewModel
    {
        public GetLoansByUserViewModel(int userId, ELoanStatus status, int bookId, string bookTitle, string author, string isbn, DateTime publicationDate, DateTime startDateLoan, DateTime endDateLoan, DateTime? finishDateLoan)
        {
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
