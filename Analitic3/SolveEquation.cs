using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class SolveEquation : PresentingTheSolution
    {

        /// <summary>
        /// שיפוע
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public double CalcIncline(Point p1, Point p2)
        {
            return (p2.Y - p1.Y) / (p2.X - p1.X);
        }
        /// <summary>
        ///  ומשווואה Y ע"י  X מציאת 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public double FindingX(double y, Equation e)
        {
            SolutionFindingX(y, e);
            return e.B / (y + (e.M * -1));
        }
        /// <summary>
        ///  ומשווואה X ע"י  Y מציאת 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public double FindingY(double x, Equation e)
        {
            SolutionFindingY(x, e);
            return (e.M * x) + e.B;
        }
        /// <summary>
        /// משוואת ישר ע"פ נקודה ושיפוע
        /// </summary>
        /// <param name="m">שיפוע</param>
        /// <param name="p">נקודה</param>
        /// <returns>משוואת ישר</returns>
        public Equation CalculateEquationByInclineAndPoint(double m, Point p)
        {
            SolutionCalculateEquationByInclineAndPoint(m, p);
            double b = p.Y - (m * p.X);
            Equation e = new Equation();
            e.B = b;
            e.M = m;
            return e;
        }
        /// <summary>
        /// חישוב משוואת ישר עפ"י 2 נקודות
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public Equation CalculateEquationByTwoPoints(Point p1,Point p2)
        {
            double m = CalcIncline(p1, p2);
            return CalculateEquationByInclineAndPoint(m,p1);
        }
        /// <summary>
        /// מציאת נקודת חיתוך בין 2 משוואות
        /// </summary>
        /// <param name="equation1">משוואה 1</param>
        /// <param name="equation2">משוואה 2</param>
        /// <returns>נקודת החיתוך</returns>
        public Point EquationSolution(Point p, Equation equation1, Equation equation2)
        {
            double temp = equation1.M * (-1) + equation2.M;
            p.X = (equation1.B + equation2.B * (-1)) / temp;
            p.Y = (equation1.B + (equation1.M * p.X));
            return p;


        }
        /// <summary>
        /// חישוב הופכי ונגדי 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public double NumberInverseAndpposite(double num)
        {
            double number = num * (-1);
            number = Math.Pow(number, -1);
            return number;
        }
        /// <summary>
        /// חישוב גובה למשולש
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public double HeightCalculationForATriangle(Point p1, Point p2, Point p3)
        {
            double height;
            Point p = new Point();
            double m1 = CalcIncline(p2, p3);
            Equation e1 = CalculateEquationByInclineAndPoint(m1, p2);
            double m2 = NumberInverseAndpposite(m1);
            Equation e2 = CalculateEquationByInclineAndPoint(m2, p1);
            p = EquationSolution(p, e1, e2);
            height = p.Distance(p1);
            return height;


        }
        /// <summary>
        /// חישוב שטח משולש ע"י 3 נקודות
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns></returns>
        public double CalculationOfATriangularAreaByPoint(Point p1, Point p2, Point p3)
        {
            double area = Math.Abs((p1.X * (p3.Y - p2.Y) + p2.X * (p1.Y - p3.Y) + p3.X * (p2.Y - p1.Y)))/2;
            return area;

        }
        /// <summary>
        /// חישוב שטח משולש ע"י גובע וצלע
        /// </summary>
        /// <param name="rib">צלע</param>
        /// <param name="height">גובה</param>
        /// <returns></returns>
        public double CalculationOfATriangularAreaByHeightandRib(double rib, double height)
        {
            return (rib * height) / 2;
        }
        /// <summary>
        ///חישוב נקודת אמצע קטע ע"י 2 נקודות הישר
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public Point CalculateAMidpoint(string np,Point p1,Point p2) 
        {
            Point p = new Point(np);
            p.X = (p1.X + p2.X) / 2;
            p.Y = (p1.Y + p2.Y) / 2;
            return p;
        }
        /// <summary>
        /// חישוב נקודת קצה ע"י נקודה ונקודת אמצע
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public Point CalculateAnEndpoint(string np ,Point mP,Point p2)
        {
            Point p = new Point(np);
            p.X = (p2.X * -1) + (mP.X * 2);
            p.Y = (p2.Y * -1) + (mP.Y * 2);
            return p;
        }

    }
}
