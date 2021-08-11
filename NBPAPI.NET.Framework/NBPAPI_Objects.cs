using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBPAPI.NET.Framework
{
    public class ExchangeRatesTable
    {
        /// <summary>
        /// The exchange rate available in exchange rates table.
        /// </summary>
        public class ExchangeRate
        {
            string currency;
            string code;
            double mid;

            /// <summary>
            /// Currency name.
            /// </summary>
            /// <value>
            /// The currency.
            /// </value>
            public string Currency { get => currency; set => currency = value; }
            /// <summary>
            /// Currency code.
            /// </summary>
            /// <value>
            /// The code.
            /// </value>
            public string Code { get => code; set => code = value; }
            /// <summary>
            /// Currency mid.
            /// </summary>
            /// <value>
            /// Medium value of buy and sell of currency (from PLN).
            /// </value>
            public double Mid { get => mid; set => mid = value; }
        }
    }
}
