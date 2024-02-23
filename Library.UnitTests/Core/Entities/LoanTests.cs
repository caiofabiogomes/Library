using Library.Core.Entities;
using Library.Core.Enums;

namespace Library.UnitTests.Core.Entities
{
    public class LoanTests
    {

        [Fact]
        public void FinishDataOk_FinishLoan_StatusIsPayedWhenPaymentIsPending() 
        { 
            var loan = new Loan(1, 1, DateTime.Now.AddDays(15), 5, 10);

            loan.PaymentPending();
             
            loan.FinishLoan(DateTime.Now.AddDays(14),30,"teste-173636623");
             
            Assert.Equal(ELoanStatus.Payed, loan.Status);
        }


        [Theory]
        [InlineData("2023-01-01", "2023-01-15", "2023-02-10", 5,7,252.00)]
        [InlineData("2023-01-01", "2023-01-15", "2023-01-20", 2, 4, 48.00)]   
        [InlineData("2023-01-01", "2023-01-15", "2023-02-20", 3, 5, 222.00)]  
        [InlineData("2023-01-01", "2023-01-15", "2023-01-10", 1, 2, 14.00)]
        [InlineData("2023-01-01", "2023-01-15", "2023-01-15", 0.5, 4, 7.00)]   
        [InlineData("2023-01-01", "2023-01-15", "2023-01-14", 3, 6.5, 42.00)]    
        [InlineData("2023-01-01", "2023-01-15", "2023-01-16", 2, 7.5, 35.50)]    
        [InlineData("2023-01-01", "2023-01-15", "2023-01-05", 1, 2, 14.00)]   
        [InlineData("2023-01-01", "2023-01-15", "2023-01-25", 3, 4, 82.00)]
        public void InputIsOk_CalculateValueToPay(DateTime startedDate,DateTime endDate,DateTime finishDate,decimal valuePerDay, decimal valuePerDayLate,decimal valueToPay) 
        {
            var loan = new Loan(1, 1, startedDate,endDate, valuePerDay,valuePerDayLate);

            var totalValueToPay = loan.ValueToPayToFinishLoan(finishDate);

            Assert.Equal(totalValueToPay, valueToPay);
        }


        [Fact]
        public void FinishDataOk_CancelLoan_StatusIsCanceled()
        { 
            var loan = new Loan(1, 1, DateTime.Now.AddDays(15), 5, 10);
             
            loan.CancelLoan();
            
            Assert.Equal(ELoanStatus.Canceled, loan.Status);
        }
    }
}
