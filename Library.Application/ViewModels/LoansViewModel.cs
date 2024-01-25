using Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class LoansViewModel
    {
        public LoansViewModel(int userId, int bookId, DateTime startDateLoan, DateTime endDateLoan, DateTime? finishDateLoan, ELoanStatus status)
        {
            UserId = userId;
            BookId = bookId;
            StartDateLoan = startDateLoan;
            EndDateLoan = endDateLoan;
            FinishDateLoan = finishDateLoan;
            Status = status;
        }

        public int UserId { get; private set; }

        public int BookId { get; private set; }
        
        public DateTime StartDateLoan { get; private set; }

        public DateTime EndDateLoan { get; private set; }

        public DateTime? FinishDateLoan { get; private set; }

        public ELoanStatus Status { get; private set; }

    }
}
