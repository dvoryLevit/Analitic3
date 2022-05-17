using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class Triangel : SolveEquation
    {
        /// <summary>
        /// מערך קודקודים
        /// </summary>
        public Point[] PointOfTriangle { get; set; }= new Point[3];
        /// <summary>
        /// מערך צלעות
        /// </summary>
        public Rib[] RibsOfTriangle { get; set; } = new Rib[3];
        /// <summary>
        /// מערך גבהים
        /// </summary>
        public Rib[] HeightsOfTriangle { get; set; } = new Rib[3];
        public static int NumOfPoint = 3;
        public static int NumOfRib = 3;
        public int Height { get; set; }
        public string NameOfTri { get; set; }
        public Triangel()
        {
            
        }

        public Triangel(string nameOfTri)
        {
            NameOfTri = nameOfTri;
            PointOfTriangle = new Point[3];
            RibsOfTriangle = new Rib[3];
            HeightsOfTriangle = new Rib[3];
            for (int i = 0; i < NumOfPoint; i++)
            {
                PointOfTriangle[i] = null;
                RibsOfTriangle[i] = null;
                HeightsOfTriangle[i] = null;
            }
            Height = 0;

        }

        public Triangel(Point[] pointOfTriangle,string naneOfTri)
        {
            NameOfTri = naneOfTri;
            PointOfTriangle = pointOfTriangle;
        }

        public Triangel(Point[] pointOfTriangle, int height)
        {
            PointOfTriangle = new Point[3];
            for (int i = 0; i < NumOfPoint; i++)
            {
                PointOfTriangle[i] = pointOfTriangle[i];
            }
            Height = height;
        }

        public double Area()
        {
            double area = 0;

            return area;
        }
        //straight calculation
        public double trianglePerimeter()
        {
            double scope = 0;
            double[] straight = new double[3];
            straight[0] = PointOfTriangle[0].Distance(PointOfTriangle[1]);
            straight[1] = PointOfTriangle[1].Distance(PointOfTriangle[2]);
            straight[2] = PointOfTriangle[2].Distance(PointOfTriangle[0]);
            for (int i = 0; i < straight.Length; i++)
                scope += straight[i];
            return scope;
        }

        /// <summary>
        /// הצבת צלעות המשולש המערך הצלעות
        /// </summary>
        public void PostingRibsOfTriangle()
        {
            RibsOfTriangle[0].Length = PointOfTriangle[2].Distance(PointOfTriangle[1]);
            RibsOfTriangle[1].Length = PointOfTriangle[0].Distance(PointOfTriangle[2]);
            RibsOfTriangle[2].Length = PointOfTriangle[0].Distance(PointOfTriangle[1]);
        }

        /// <summary>
        /// הצבת גבהים במערך הגבהים
        /// </summary>
        public void PostingHeightOfTriangel()
        {
            HeightsOfTriangle[0].Length = HeightCalculationForATriangle(PointOfTriangle[0], PointOfTriangle[1], PointOfTriangle[2]);
            HeightsOfTriangle[1].Length = HeightCalculationForATriangle(PointOfTriangle[1], PointOfTriangle[0], PointOfTriangle[2]);
            HeightsOfTriangle[2].Length = HeightCalculationForATriangle(PointOfTriangle[2], PointOfTriangle[0], PointOfTriangle[1]);
        }
        /// <summary>
        /// חישוב שטח משולש
        /// </summary>
        /// <returns></returns>
        public double TriangleArea()
        {
            return (RibsOfTriangle[0].Length * HeightsOfTriangle[0].Length) / 2;
        }
        public void PrintPointTrinangle()
        {
            Console.WriteLine("Point Of Triangle: ");
            for (int i = 0; i < NumOfPoint; i++)
            {
                Console.Write("("+PointOfTriangle[i].X+","+ PointOfTriangle[i].Y+")");
            }
        }
        public void PrintRibTrinangle()
        {
            Console.WriteLine("Ribs Of Triangle: ");
            for (int i = 0; i < NumOfPoint; i++)
            {
                Console.Write(RibsOfTriangle[i].Length + " ,");
            }
        }
        public void PrintHeightTrinangle()
        {
            Console.WriteLine("Heights Of Triangle: ");
            for (int i = 0; i < NumOfPoint; i++)
            {
                Console.Write(HeightsOfTriangle[i].Length + " ,");
            }
        }
        public string toString()
        {
            return "Point Of Triangle: " + PointOfTriangle[0];
        }
    }
}
