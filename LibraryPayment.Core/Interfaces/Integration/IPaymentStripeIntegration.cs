using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPayment.Core.Interfaces.Integrations
{
    public interface IPaymentStripeIntegration
    {
        Task<string> ProcessPayment(decimal value);
    }
}
