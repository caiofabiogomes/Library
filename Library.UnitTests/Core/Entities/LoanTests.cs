using Library.Core.Entities;
using Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTests.Core.Entities
{
    public class LoanTests
    {

        [Fact]
        public void FinishDataOk_FinishLoan_StatusIsPayedWhenPaymentIsPending() 
        {
            //Arrange -> preparar os objetos para teste
            var loan = new Loan(1, 1, DateTime.Now.AddDays(15), 5, 10);

            loan.PaymentPending();

            //ACT -> ação a ser testada
            loan.FinishLoan(DateTime.Now.AddDays(14),30,"teste-173636623");

            //Assert -> verificação sobre o estado final
            Assert.Equal(ELoanStatus.Payed, loan.Status);
        }

        //[Theory]
        //[InlineData(15)]
        //Public void MeuTesteEstaAtrasado(int dias)
        [Fact]

        public void FinishDataOk_CancelLoan_StatusIsCanceled()
        {
            //Arrange -> preparar os objetos para teste
            var loan = new Loan(1, 1, DateTime.Now.AddDays(15), 5, 10);

            //ACT -> ação a ser testada
            loan.CancelLoan();

            //Assert -> verificação sobre o estado final
            Assert.Equal(ELoanStatus.Canceled, loan.Status);
        }
    }
}
