using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    //not complete
    //implementation of midduration and long duration
    class ShortLoan : ILoanCalculator
    {
        public double Principal { get; set; }
        public double Interest { get; set; }
        public int Duration { get; set; }
        public double AmountToPay { get; set; }

        public void Calculate()
        {
            //ShortLoan loan = new ShortLoan(principal);
            //loan.AmountToPay = Principal * (Interest / 100) * Duration;
        }
        public ShortLoan(double principal)
        {
            this.Interest = 5;
            this.Duration = 5;
            this.Principal = principal;
        }
    }
}
