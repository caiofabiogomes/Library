using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPayment.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(decimal value,int loanId, DateTime finishDateLoan)
        {
            Value = value;
            LoanId = loanId;
            FinishDateLoan = finishDateLoan;
        }

        public decimal Value { get; private set; }
        
        public int LoanId { get; private set; }

        public DateTime FinishDateLoan { get; private set; }
    }
}
