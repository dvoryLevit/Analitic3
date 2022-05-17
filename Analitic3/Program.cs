using System;
using IronOcr;
namespace Analitic3
{
    class Program
    {
        public static void temp()
        {
            //Point p0 = new Point(8,6,"A");
            //Point p1 = new Point(6,0,"B");
            //Point p2 = new Point(14, 0, "C");
            //Point[] p= new Point[3];
            //p[0] = new Point(8, 6, "A");
            //p[1] = new Point(6, 0, "B");
            //p[2] = new Point(14, 0, "C");
            ////p1.Distance(p2);
            //Triangel t = new Triangel(p);
            //t.PostingRibsOfTriangle();
            ////t.PostingHeightOfTriangel();
            ////t.TriangleArea();
            //t.PrintPointTrinangle();
            //t.PrintRibTrinangle();
            //Console.WriteLine(p2.Distance(p1));
            //Console.WriteLine(p0.Distance(p2));
            //Console.WriteLine(p0.Distance(p1));
            //TextOfExercise t = new TextOfExercise("The drawing in front of you depicts the triangles ABD and BCD\n" +
            //                "Points B, N and C are on the X - axis\n" +
            //                "The equation of the straight line BD is y = 3x - 18\n" +
            //                "The DC straight equation is y = -x + 14\n" +
            //                "Point D is the point of intersection of the lines BD and DC\n" +
            //                "Find the rates of points B and C.\n" +
            //                "Find point rates D\n" +
            //                "Given that the line AB is perpendicular to the line BD\n" +
            //                "Calculate the area of ​​the triangle ABD\n" +
            //                "Calculate the square area of ​​the ABCD\n");
        }
        static void Main(string[] args)
        {
            TextOfExercise t2;
            //t.creatTri();
            var Ocr = new IronTesseract();
            Ocr.Language = OcrLanguage.English;
            using (var Input = new OcrInput(@"D:\project\pic45.png"))
            {
                var Result = Ocr.Read(Input);
                t2 = new TextOfExercise(Result.Text);
                Console.WriteLine(Result.Text);
            }
            t2.creatTri();

        }
    }
}
