namespace LibraryPayment.Application.InputModels
{
    public class ProcessPaymentInputModel
    {
        public ProcessPaymentInputModel(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; private set; }

    }
}
