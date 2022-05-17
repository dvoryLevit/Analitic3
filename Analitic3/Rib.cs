using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class Rib
    {
        /// <summary>
        /// קדקד 1
        /// </summary>
        public Point Vertex1 { get; set; }
        /// <summary>
        /// קדקד 2
        /// </summary>
        public Point Vertex2 { get; set; }
        /// <summary>
        /// משוואת ישר
        /// </summary>
        public Equation LineEquation { get; set; }

        /// <summary>
        /// אורך הצלע
        /// </summary>
        public double Length { get; set; }
        public string NameRib { get; set; }

        public Rib()
        {
            Vertex1 = new Point();
            Vertex2 = new Point();
            //LineEquation = new Equation();
        }

        //public double length
        //{
        //    get { return length; }
        //    set
        //    {
        //        try { length = Vertex1.Distance(Vertex2); }
        //        catch (Exception e)
        //        { length = 0; }
        //    }
        //}
        //שיפוע
        public double CalcHeight()
        {
            return (Vertex1.Y - Vertex1.Y) / (Vertex1.X - Vertex1.X);
        }
        public string Name()
        {
            return Vertex1.Name + Vertex2.Name;
        }

    }
}
