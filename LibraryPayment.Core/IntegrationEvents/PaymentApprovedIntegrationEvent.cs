namespace LibraryPayment.Infra.EventsInputModels
{
    public class PaymentApprovedIntegrationEvent
    {
        public PaymentApprovedIntegrationEvent(int loanId,DateTime finishDateLoan, string paymentId, decimal totalValuePaid)
        {
            LoanId = loanId;
            FinishDateLoan = finishDateLoan;
            PaymentId = paymentId;
            TotalValuePaid = totalValuePaid;
        }

        public int LoanId { get; private set; }

        public DateTime FinishDateLoan { get; private set; }

        public string PaymentId { get; private set; }

        public decimal TotalValuePaid { get; private set; }

    }
}
