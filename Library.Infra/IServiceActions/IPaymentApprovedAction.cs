namespace Library.Infra.IServiceActions
{
    public interface IPaymentApprovedAction
    {
        Task FinishLoan(int loanId, DateTime finishDateLoan, decimal totalPaid, string paymentId);
    }
}
