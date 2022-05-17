using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class Equation
    {
        /// <summary>
        /// שיפוע הישר
        /// </summary>
        public double M { get; set; }
        /// <summary>
        /// המספר החופשי
        /// </summary>
        public double B { get; set; }
        /// <summary>
        /// שם הצלע
        /// </summary>
        public string NameRib { get; set; }

        public Equation(double m, double b)
        {
            M = m;
            B = b;
        }

        public Equation()
        {
        }
    }
}
