using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPayment.Infra.IServicesConsumers
{
    public interface IProcessPaymentAction
    {
        Task<string> ProcessPayment(decimal value);
    }
}
