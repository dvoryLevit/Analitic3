using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Analitic3
{
    class PresentingTheSolution
    {
        protected void SolutionFindingX(double y, Equation e)
        {
            Console.WriteLine("  The soulution of Equation by Y and Equation:");
            Console.WriteLine("  Y*" + y + " = " + e.M + "x +(" + e.B + ")");
            Console.WriteLine("  " + e.M * -1 + "x =" + e.B);
            Console.WriteLine("  " + e.B + " /" + e.M * -1 + "=" + e.B / (e.M * -1));
            Console.WriteLine("-----------");
        }
        protected void SolutionFindingY(double x, Equation e)
        {
            Console.WriteLine("  The soulution of Equation by X and Equation:");
            Console.WriteLine("  Y = " + e.M + "*" + x + "+(" + e.B + ")");
            Console.WriteLine("  Y=" + (e.M * x) + e.B);
            Console.WriteLine("-----------");
        }
        protected void SolutionCalculateEquationByInclineAndPoint(double m, Point p)
        {
            Console.WriteLine("  Solution Calculate Equation By Incline And Point:");
            Console.WriteLine("  y - y1 = m ( x - x1 )");
            Console.WriteLine("  m="+m);
            Console.WriteLine("  (x1,y1) = ("+p.X+","+p.Y+" )");
            Console.WriteLine("  y - " + p.Y+" = "+m+"( x-"+p.X+")");
            Console.WriteLine("  y = "+ m + "x"+"+"+m*p.X*-1+"+"+p.Y);
            Console.WriteLine("  y = "+m+"x+"+((m * p.X * -1) + p.Y));
            Console.WriteLine("-----------");
            
        }
        protected void SolutionCalcIncline(Point p1, Point p2)
        {
            Console.WriteLine("  m = ((Y2 - Y1)/(X2 - X1))");
            Console.WriteLine("  m = (("+ (p2.Y+ "-"+ p1.Y)+" ))/(( "+ (p2.X +"-"+ p1.X)+"))");
            Console.WriteLine("  m = ("+ (p2.Y - p1.Y)+"/"+ (p2.X - p1.X)+")");
            Console.WriteLine("  m = "+ (p2.Y - p1.Y) / (p2.X - p1.X));
            Console.WriteLine("---------------------");
        }
        public static bool isValidMobileNumber(string inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]
                {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";

            // Class Regex Represents an
            // immutable regular expression.
            //   Format                Pattern
            // xxxxxxxxxx           ^[0 - 9]{ 10}$
            // +xx xx xxxxxxxx     ^\+[0 - 9]{ 2}\s +[0 - 9]{ 2}\s +[0 - 9]{ 8}$
            // xxx - xxxx - xxxx   ^[0 - 9]{ 3} -[0 - 9]{ 4}-[0 - 9]{ 4}$
            Regex re = new Regex(strRegex);

            // The IsMatch method is used to validate
            // a string or to ensure that a string
            // conforms to a particular pattern.
            if (re.IsMatch(inputMobileNumber))
                return (true);
            else
                return (false);
        }
    }
}