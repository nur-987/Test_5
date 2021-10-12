using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    interface ILoanCalculator
    {
        double Principal { get; set; }
        double Interest { get; set; }
        int Duration { get; set; }
        double AmountToPay { get; set; }

        void Calculate();
    }
}
