using System;
using System.Collections.Generic;
using System.Text;

namespace Analitic3
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public bool flagX { get; set; }
        public bool flagY { get; set; }

        public string Name { get; set; }

        public Point()
        {
            flagX = false;
            flagY = false;
        }

        public Point(double x, double y, string name)
        {
            flagX = true;
            flagY = true;
            X = x;
            Y = y;
            Name = name;
        }

        public Point(string name)
        {
            Name = name;
            flagX = true;
            flagY = true;
        }

        //מרחק בין נקודות
        public double Distance(Point other)
        {
            double distance;
           distance = Math.Sqrt(Math.Pow((this.X - other.X), 2) + Math.Pow((this.Y - other.Y), 2));
            return distance;
        }
    }
}
