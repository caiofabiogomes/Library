using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
