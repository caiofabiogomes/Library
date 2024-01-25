using Library.Core.Enums;
using Library.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Loan : BaseEntity
    {
        public Loan() 
        {
        }
        public Loan(int userId, int bookId,DateTime endDateLoan) 
        {
            UserId = userId;
            BookId = bookId;
            StartDateLoan = DateTime.Now;
            EndDateLoan = endDateLoan;
            Status = ELoanStatus.InProgress;
            ValidateEndLoanDate();
        }
        public Loan(int userId, DateTime endDateLoan,Book book)
        {
            UserId = userId;
            BookId = book.Id;
            StartDateLoan = DateTime.Now;
            EndDateLoan = endDateLoan;
            Status = ELoanStatus.InProgress;
            Book = book;
            ValidateEndLoanDate();
        }
        public int UserId {  get; private set; }

        public User User { get; private set; }
        
        public int BookId { get; private set; }
        
        public Book Book { get; private set; }
        
        public DateTime StartDateLoan { get; private set; }
        
        public DateTime EndDateLoan { get; private set; }

        public DateTime? FinishDateLoan { get; private set; }

        public ELoanStatus Status { get; private set; }

        public void FinishLoan(DateTime finishDate) 
        {
            Status = ELoanStatus.Done;
            FinishDateLoan = finishDate;
            ValidateFinishLoanDate();
        }

        public void CancelLoan() 
        {
            Status = ELoanStatus.Canceled;
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
