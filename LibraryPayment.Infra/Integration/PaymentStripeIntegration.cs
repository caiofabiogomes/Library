using LibraryPayment.Core.Interfaces.Integrations;
using Stripe;

namespace LibraryPayment.Infra.Integration
{
    public class PaymentStripeIntegration : IPaymentStripeIntegration
    { 
        public PaymentStripeIntegration(string secretKey)
        {
            StripeConfiguration.ApiKey = secretKey;
        }

        public async Task<string> ProcessPayment(decimal value)
        {
            try
            {
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = (long)(value * 100),
                    Currency = "BRL",
                    PaymentMethod = "pm_card_visa",
                    Confirm = true,
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true,  
                        AllowRedirects = "never" 
                    }
                };

                var paymentIntentService = new PaymentIntentService();
                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                return paymentIntent.Id;
            }
            catch (StripeException ex)
            {
                throw new Exception("Erro ao processar o pagamento: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar o pagamento: " + ex.Message);
            }
        }

    }
}