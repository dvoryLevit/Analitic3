using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Analitic3
{
    class TextOfExercise
    {
        //המחרוזת אליה נכנס ות מילות התרגיל
        public string Str { get; set; }

        public List<string> listSentence = new List<string>();
        //רשימת משולשים
        public List<Triangel> Tri { get; set; }

        public readonly IDictionary<string, Action<string, int>> keywordsOfTri;

        ///מילות מפתח של סוגי הנקודות
        public readonly IDictionary<string, Action<string, string>> keywordsOfPoint;

        public readonly IDictionary<string, Action<string, string>> keywordsOfSolution;

        public readonly IDictionary<string, Action<string>> keywordsOfProven;


        /// <summary>
        /// בנאי המאתחל את רשימת מילות המפתח
        /// </summary>
        /// <param name="str"></param>
        public TextOfExercise(string str)
        {
            this.Str = str;
            Tri = new List<Triangel>();
            keywordsOfTri = new Dictionary<string, Action<string, int>>();
            keywordsOfPoint = new Dictionary<string, Action<string, string>>();
            keywordsOfSolution = new Dictionary<string, Action<string, string>>();
            keywordsOfProven = new Dictionary<string, Action<string>>();
            //Regex poi = new Regex(@"[A-Z]{1}:\([0-9]{1,},[0-9]{1,}\)");
            //הוספת מילות מפתח לאובייקט משולש

            keywordsOfTri.Add("depicts the triangle", FuncDepictsTheTriangles);
            keywordsOfTri.Add("describes the triangle", FuncDepictsTheTriangles);
            keywordsOfTri.Add("Given the triangle", FuncDepictsTheTriangles);
            keywordsOfTri.Add("Point", FuncPoints);
            keywordsOfTri.Add("point", FuncPoints);
            keywordsOfTri.Add("vertex", FuncPoints);
            keywordsOfTri.Add("Calculate ", FuncCalculate);
            keywordsOfTri.Add("equation ", FuncEquation);
            keywordsOfTri.Add("Proven", FuncProven);
            keywordsOfTri.Add("Find", FuncCalculate);
            

            //הוספת מילות מפתח לאובייקט נקודה
            keywordsOfPoint.Add("X-axis", FuncXAxis);
            keywordsOfPoint.Add("Y-axis", FuncYAxis);
            //keywordsOfPoint.Add("point of intersection", FuncPointOfIntersection);
            keywordsOfPoint.Add("point rates ", FuncPointRates);
            keywordsOfPoint.Add("Find", FuncFind);
            keywordsOfPoint.Add("Given", FuncGivenPoint);
            keywordsOfPoint.Add("middle of the side", FuncMiddleRib);
            ///מילות מפתח לחישוב
            keywordsOfSolution.Add("point", FuncFindingAPoint);
            keywordsOfSolution.Add("distance", FuncFindingADistance);
            keywordsOfSolution.Add("length", FuncFindingALength);
            keywordsOfSolution.Add("area ", FuncFindingAnArea);
            keywordsOfSolution.Add("equation", FuncFindingAnEquation);
            //מילות מפתח להוכחות
            keywordsOfProven.Add("Perpendicular", FuncPerpendicular);
            keywordsOfProven.Add("Parallel", FuncPerpendicular);
        }

        private void FuncMiddleRib(string str, string nP)
        {
            string nRib = NameLine(str,0).Value;
            IndexStructure i = returnIndexOfRib(nRib);
            if (i.iList != -1)
            {
              Point p = new Point();
              Point p1 = Tri[i.iList].RibsOfTriangle[i.iArry].Vertex1;
             Point p2 = Tri[i.iList].RibsOfTriangle[i.iArry].Vertex2;
             if (ThereAreXAndY(p1)==true&& ThereAreXAndY(p2) == true)
             {
                p = Tri[0].CalculateAMidpoint(nP, p1, p2);
                PlacingAPoint(nP,p);
                PlacingAPoint2(nP,p);
                Console.WriteLine("point " + nP + " is : (" + p.X + "," + p.Y + ");");
             }
            }
   
        }

        /// <summary>
        /// מעבר על המחרות וחלוקה למשפטים
        /// </summary>
        public string[] StringScan()
        {

            string[] s = Str.Split("\n");
            return s;
        }


        /// <summary>
        /// יצירת משולש חדש
        /// </summary>
        public void creatTri()
        {
            string[] tempStr = StringScan();
            ///לולאה שעוברת על כל מערך המשפטים
            for (int i = 0; i < tempStr.Length; i++)
            {
                int index = 0;
                //בודקת אם המילה קיימת ואם כן שולחת לפונקציה המתאימה 
                foreach (var word in keywordsOfTri)
                {
                    string s = word.Key;
                    index = tempStr[i].IndexOf(word.Key, index);
                    if (index != -1)
                    {
                        //קריאה לפונקציה עם שרשור שם המשתנה
                         keywordsOfTri[word.Key](tempStr[i], index);
                        break;
                    }
                    else
                        index = 0;
                }
            }
        }

        /// <summary>
        /// מציבה את שמות המשולשים הנתונים ונקודותיהם
        /// </summary>
        /// <param name="str"></param>
        /// <param name="indexTri"></param>
        public void FuncDepictsTheTriangles(string str, int indexTri)
        {
            Regex rg = new Regex(@"[A-Z]{3}");

            while (indexTri < str.Length)
            {
                Match match = rg.Match(str, indexTri);
                if (match.Index != 0)
                {
                    indexTri = (match.Index) + (match.Value).Length;
                    Triangel t1 = new Triangel();
                    t1.NameOfTri = match.Value;
                    t1 = ReturnsTheVerticesOfTri(t1, t1.NameOfTri);
                    t1 = ReturnsTheRibOfTri(t1, t1.NameOfTri);
                    Tri.Add(t1);
                    Console.WriteLine("triangle=" + t1.NameOfTri + " ,point of triangle=" +
                           t1.PointOfTriangle[0].Name + "," + t1.PointOfTriangle[1].Name + "," + t1.PointOfTriangle[2].Name);
                    indexTri++;
                }
                else
                    break;
            }
        }


        /// <summary>
        /// מציב את ערכי הנקודות
        /// </summary>
        /// <param name="str"></param>
        /// <param name="indexP"></param>
        ///
        private void FuncPoints(string str, int indexP)
         {
           
            List<string> point = new List<string>();
            while (indexP < str.Length)
            {
                Match match = NamePoint(str, indexP);
                if (match.Index == 0)
                    break;
                point.Add(match.Value.Trim());
                indexP = (match.Index) + (match.Value).Length;
            }
            string temp = "";
            foreach (var wordP in keywordsOfPoint)
            {
                temp = wordP.Key;
                indexP = str.IndexOf(temp);
                if (indexP != -1)
                {
                    foreach (var p in point)
                    {
                        keywordsOfPoint[wordP.Key](str, p);
                    }
                    break;
                }

            }
        }

        /// <summary>
        /// ניתוח המשוואה והצבת הפרמטרים 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void FuncEquation(string str, int index)
        {
            Regex rg1 = new Regex(@"y=-*[0-9]{0,}\.*[0-9]{0,}x\+*-*[0-9]{0,}\.*[0-9]{0,}");
            string straight = NameLine(str, 0).Value;
            str = str.Replace(" ", String.Empty);
            Match match1 = rg1.Match(str);
            string p1 = straight.Substring(0, 1);
            string p2 = straight.Substring(1, 1);
            foreach (var t in Tri)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (t.RibsOfTriangle[i].NameRib.Contains(p1) && t.RibsOfTriangle[i].NameRib.Contains(p2))

                    {
                        t.RibsOfTriangle[i].LineEquation = new Equation();
                         t.RibsOfTriangle[i].LineEquation.M= Incline(match1.Value);
                        t.RibsOfTriangle[i].LineEquation.B = FindB(match1.Value);
                        Console.WriteLine(" the eqution "+ t.RibsOfTriangle[i].NameRib+" is: Y = " + t.RibsOfTriangle[i].LineEquation.M + "X + " + t.RibsOfTriangle[i].LineEquation.B + " .");
                    }
                }


            }

        }

        /// <summary>
        /// קורא לפונקציה המתאימה להוכחה שהתבקשה
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void FuncProven(string str, int index)
        {
            if (str.Contains("perpendicular"))
            {
                FuncPerpendicular(str);
            }
        }

        /// <summary>
        /// מציאת השיפוע מתוך המחרוזת
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private double Incline(string str)
        {
            double m = 0;
            int eq = 1;
            int x = str.IndexOf("x", eq);
            //במקרה והשיפוע יורד
            if (str.IndexOf("-") != -1 && str.IndexOf("-") < x)
            {
                if ((x - (str.IndexOf("-") + 1)) != 0)
                {
                    string tmp = str.Substring(3, x - 3);
                    m = Convert.ToDouble(tmp);
                    m *= -1;
                }
                else
                    m = -1;

            }
            //במקרה והשיפוע עולה
            else
            {
                if ((x - (eq + 1)) != 0)
                {
                    string ms = str.Substring(2, x - (eq + 1));
                    m = Convert.ToDouble(ms);
                }
                else
                    m = 1;
            }
            return m;
        }

        /// <summary>
        /// מציאת המספר החופשי במחרוזת
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private double FindB(string str)
        {
            double b = 0;
            int op = str.IndexOf("x", 0);
            b = double.Parse(str.Substring(op + 2));
            if (str.Contains("+") == false)
                b *= -1;

            return b;

        }

        /// <summary>
        /// שולחת לפונקציית חישוב עפ"י הדרישה הנתונה
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void FuncCalculate(string str, int index)
        {
            string temp = "";
            foreach (var whatCalc in keywordsOfSolution)
            {
                temp = whatCalc.Key;
                if (str.Contains(temp))
                {
                    keywordsOfSolution[whatCalc.Key](str, "");
                    break;
                }
            }
        }


        /// <summary>
        /// Y בנקודה הנמצאת על ציר ה X הצבת 0  ב
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void FuncYAxis(string str, string str2)
        {
            foreach (var t in Tri)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(str2))
                    {
                        t.PointOfTriangle[i].X = 0;
                        t.PointOfTriangle[i].flagX = true;
                    }

                    if (t.RibsOfTriangle[i].Vertex1.Name.Equals(str2))
                    {
                        t.RibsOfTriangle[i].Vertex1.X = 0;
                        t.RibsOfTriangle[i].Vertex1.flagX = true;

                    }

                    if (t.RibsOfTriangle[i].Vertex2.Name.Equals(str2))
                    {
                        t.RibsOfTriangle[i].Vertex2.X = 0;
                        t.RibsOfTriangle[i].Vertex2.flagX = true;
                    }

                }

            }

        }


        /// <summary>
        /// X בנקודה הנמצאת על ציר ה Y הצבת 0  ב 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void FuncXAxis(string str, string str2)
        {
            foreach (var t in Tri)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(str2))
                    {
                        t.PointOfTriangle[i].flagY = true;
                        t.PointOfTriangle[i].Y = 0;
                    }
                    if (t.RibsOfTriangle[i].Vertex1.Name.Equals(str2))
                    {
                        t.RibsOfTriangle[i].Vertex1.flagY = true;
                        t.RibsOfTriangle[i].Vertex1.Y = 0;
                    }
                    if (t.RibsOfTriangle[i].Vertex2.Name.Equals(str2))
                    {
                        t.RibsOfTriangle[i].Vertex2.flagY = true;
                        t.RibsOfTriangle[i].Vertex2.Y = 0;
                    }

                }

            }
        }


        /// <summary>
        /// הפניה לפונקציות המביאות את תוצאות התרגיל
        /// </summary>
        /// <param name="whatFind"></param>
        /// <param name="x"></param>
        private void FuncFind(string whatFind, string x)
        {
            foreach (var word in keywordsOfSolution)
            {
                string temp = word.Key;
                if (whatFind.Contains(temp))
                {
                    keywordsOfSolution[word.Key](x, whatFind);
                    break;
                }
            }

        }

        /// <summary>
        /// מציאת ערכי הנקודות המבוקשות
        /// </summary>
        /// <param name="p"></param>
        private void FuncFindingAPoint(string p, string str)
        {
            Point point = new Point();
            bool flag = false;
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(p))
                    {
                        if (t.PointOfTriangle[i].flagX == true && t.PointOfTriangle[i].flagY == true)
                        {
                            Console.WriteLine("point " + p + " is: (" + t.PointOfTriangle[i].X + "," + t.PointOfTriangle[i].Y + ");");
                            break;
                        }
                        else
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                flag = false;
                                if (t.RibsOfTriangle[j].NameRib.Contains(p) && t.RibsOfTriangle[j].LineEquation != null)
                                {
                                    if (t.PointOfTriangle[i].flagX == true)
                                    {
                                        t.PointOfTriangle[i].Y = t.FindingY(t.PointOfTriangle[i].X, t.RibsOfTriangle[j].LineEquation);
                                        point = t.PointOfTriangle[i];
                                        flag = true;
                                    }
                                    
                                    else if (t.PointOfTriangle[i].flagY == true)
                                    {
                                        t.PointOfTriangle[i].X = t.FindingX(t.PointOfTriangle[i].Y, t.RibsOfTriangle[j].LineEquation);
                                        point = t.PointOfTriangle[i];
                                        flag = true;
                                    }
                                    ///אם זאת נקודת חיתוך
                                    else
                                    {
                                       point= PointOfIntersection(p);
                                        flag = true;
                                    }

                                }

                                if (flag==true)
                                {
                                    point.flagX = true;
                                    point.flagY = true;
                                    PlacingAPoint(p, point);
                                    PlacingAPoint2(p, point);
                                    break;
                                }
                               
                            }
                            if (flag == true)
                                break;
                        }
                    }
                }
            }
            Console.WriteLine("point " + p + " is: (" + point.X + "," + point.Y + ");");

        }
        /// <summary>
        /// מציאת המשוואה המבוקשת
        /// </summary>
        /// <param name="str"></param>
        /// <param name="str2"></param>
        private void FuncFindingAnEquation(string str, string str2)
        {
            List<string> lRib = CreateAList(str, 0, 2);
            Equation eq=new Equation();
            foreach (var l in lRib)
            {
                     IndexStructure i = returnIndexOfRib(l);
                    if(i.iArry!=-1)
                    if (ThereAreXAndY(Tri[i.iList].RibsOfTriangle[i.iArry].Vertex1) == true && ThereAreXAndY(Tri[i.iList].RibsOfTriangle[i.iArry].Vertex2))
                    {
                     eq=Tri[0].CalculateEquationByTwoPoints(Tri[i.iList].RibsOfTriangle[i.iArry].Vertex1, Tri[i.iList].RibsOfTriangle[i.iArry].Vertex2);
                     Console.WriteLine(" the eqution "+ Tri[i.iList].RibsOfTriangle[i.iArry].NameRib+ "is: Y = " + eq.M + "X + " + eq.B + " .");
                        break;
                    }
            }
        }
        /// <summary>
        /// בודק אם כל ערכי הנקודה מלאים
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ThereAreXAndY(Point p)
        {
            return (p.flagX == true && p.flagY == true);
              
        }
       
        /// <summary>
        /// הוכחת הופכי ונגדי
        /// </summary>
        /// <param name="str"></param>
        private void FuncPerpendicular(string str)
        {
            int index = 0;
            Match mathc= NameLine(str, index);
            string line1 = mathc.Value;
            index = mathc.Index + (mathc.Value).Length;
            string line2 = NameLine(str, index).Value;
            double mL1 = 0;
            double mL2 = 0;
            IndexStructure i1 = returnIndexOfRib(line1);
            IndexStructure i2 = returnIndexOfRib(line2);
            if (i1.iArry != -1 && i2.iArry != -1)
            {

                if (Tri[i1.iList].RibsOfTriangle[i1.iArry].LineEquation != null)
                    mL1 = Tri[i1.iList].RibsOfTriangle[i1.iArry].LineEquation.M;
                else
                    mL1 = Tri[0].CalcIncline(Tri[i1.iList].RibsOfTriangle[i1.iArry].Vertex1, Tri[i1.iList].RibsOfTriangle[i1.iArry].Vertex2);

                if (Tri[i2.iList].RibsOfTriangle[i2.iArry].LineEquation != null)
                    mL1 = Tri[i2.iList].RibsOfTriangle[i2.iArry].LineEquation.M;
                else
                    mL1 = Tri[0].CalcIncline(Tri[i2.iList].RibsOfTriangle[i2.iArry].Vertex1, Tri[i2.iList].RibsOfTriangle[i2.iArry].Vertex2);

    
                if (Tri[0].NumberInverseAndpposite(mL1) == mL2)
                    Console.WriteLine("the line is Perpendicular");
                else
                    Console.WriteLine("the line is not Perpendicular");
            }
        }

        /// <summary>
        /// מציאת שטח משולש
        /// </summary>
        /// <param name="str"></param>
        private void FuncFindingAnArea(string str,string p)
        {
            string triangle = NameTriangle(str, 0).Value;
            double area = 0;
            foreach (var t in Tri)
            { 
                    if (t.NameOfTri.Equals(triangle))
                    {
                       area= t.CalculationOfATriangularAreaByPoint(t.PointOfTriangle[0], t.PointOfTriangle[1], t.PointOfTriangle[2]);
                        Console.WriteLine("area of triangle " + t.NameOfTri + " is:" + area);
                    }
            }
        }
      
       
        /// <summary>
        /// מוציא את ערכי הנקודה הנתונה ומציב במקום המתאים
        /// </summary>
        /// <param name="str"></param>
        /// <param name="p"></param>
        private void FuncGivenPoint(string str, string p)
        {
            Regex poi = new Regex(@"-*[0-9]{1,}");
            int index = str.IndexOf(p);
            Match x = poi.Match(str, index);
            index = x.Index + (x.Value).Length;
            Match y = poi.Match(str, index);
            foreach (var t in Tri)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(p))
                    {
                        t.PointOfTriangle[i]= FillsValuesInAPoint(double.Parse(x.Value), double.Parse(y.Value), p);
                        Console.WriteLine( p+":(" + t.PointOfTriangle[i].X + "," + t.PointOfTriangle[i].Y + ")");
                    }
                    if (t.RibsOfTriangle[i].Vertex1.Name.Equals(p))
                    {
                        t.RibsOfTriangle[i].Vertex1= FillsValuesInAPoint(double.Parse(x.Value), double.Parse(y.Value), p);
                        Console.WriteLine(p + ":(" + t.RibsOfTriangle[i].Vertex1.X + "," + t.RibsOfTriangle[i].Vertex1.Y + ")");
                    }
                    if (t.RibsOfTriangle[i].Vertex2.Name.Equals(p))
                    {
                        t.RibsOfTriangle[i].Vertex2 = FillsValuesInAPoint(double.Parse(x.Value), double.Parse(y.Value), p);
                        Console.WriteLine(p + ":(" + t.RibsOfTriangle[i].Vertex2.X + "," + t.RibsOfTriangle[i].Vertex2.Y + ")");

                    }
                }
            }
        }

        /// <summary>
        /// מחזיר את הקודקודי המשולש
        /// </summary>
        /// <returns></returns>
        public Triangel ReturnsTheVerticesOfTri(Triangel t, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                string result = str[i].ToString();
                t.PointOfTriangle[i] = new Point();
                t.PointOfTriangle[i].Name = result;
            }
            return t;
        }

        /// <summary>
        /// מקבל שם משולש ומציב את שמות צלעותיו
        /// </summary>
        /// <param name="t2"></param>
        /// <param name="strR"></param>
        /// <returns></returns>
        public Triangel ReturnsTheRibOfTri(Triangel t2, string strR)
        {
            for (int i = 0; i < 3; i++)
            {
                t2.RibsOfTriangle[i] = new Rib();
            }
            t2.RibsOfTriangle[0].NameRib = strR.Substring(0, 2);
            t2.RibsOfTriangle[0].Vertex1.Name = strR.Substring(0, 1);
            t2.RibsOfTriangle[0].Vertex2.Name = strR.Substring(1, 1);

            t2.RibsOfTriangle[1].NameRib = strR.Substring(1, 2);
            t2.RibsOfTriangle[1].Vertex1.Name = strR.Substring(1, 1);
            t2.RibsOfTriangle[1].Vertex2.Name = strR.Substring(2, 1);

            t2.RibsOfTriangle[2].NameRib = strR[0].ToString() + strR[2].ToString();
            t2.RibsOfTriangle[2].Vertex1.Name = strR[0].ToString();
            t2.RibsOfTriangle[2].Vertex2.Name = strR[2].ToString();
            return t2;

        }


        /// <summary>
        /// מחלץ את שם המשולש
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Match NameTriangle(string str, int index)
        {
            Regex rg = new Regex(@"[A-Z]{3}");
            Match match = rg.Match(str, index);

            return match;
        }
        /// <summary>
        /// מחלץ את שם הנקודה
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Match NamePoint(string str, int index)
        {
            Regex rg = new Regex(@" [A-Z]{1} ");
            Match match = rg.Match(str, index);
            return match;
        }
        /// <summary>
        /// מחלץ את שם הישר
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Match NameLine(string str, int index)
        {
            Regex rg = new Regex(@"[A-Z]{2}");
            Match match = rg.Match(str, index);
            return match;
        }

        private void FuncPointRates(string arg1, string arg2)
        {
            throw new NotImplementedException();
        }
        private void FuncFindingALength(string str, string p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// פונקצייה למציאת מרחק בין 2 נקודות
        /// </summary>
        /// <param name="p"></param>
        /// <param name="str"></param>
        private void FuncFindingADistance(string p, string str)
        {
            int index = 0;
            Match match = NamePoint(str, index);
            string pN1 =match.Value.Trim();
            index = match.Index+1;
            string pN2 = NamePoint(str, index).Value.Trim();
            Point p1 = new Point();
            Point p2 = new Point();
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(pN1))
                        p1 = t.PointOfTriangle[i];
                    if (t.PointOfTriangle[i].Name.Equals(pN2))
                        p2 = t.PointOfTriangle[i];
                }
            }
           Console.WriteLine(" the distance from point"+pN1 +" to:"+ pN2+" is:"+p1.Distance(p2));
        }

 
        /// <summary>
        /// מציאת אינדקס של נקודה במשולש מתוך מערך הנקודות
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int returnIndexOfPoint(string p)
        {
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(p))
                        return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// מציאת אינדקס של ישר במשולש מתוך מערך הצלעות
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IndexStructure returnIndexOfRib(string line)
        {
            IndexStructure index = new IndexStructure(-1,-1);
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.RibsOfTriangle[i].NameRib.Equals(line))
                    {
                        index.iList = Tri.IndexOf(t);
                        index.iArry = i;
                        return index;
                    }
                }
            }
            return index;
        }
        /// <summary>
        /// מציאת אינדקס של ישר במשולש מתוך מערך הצלעות
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IndexStructure returnIndexOfRib(string line,Triangel t1)
        {
            IndexStructure index = new IndexStructure(-1,-1);
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.RibsOfTriangle[i].NameRib.Equals(line))
                    {
                        index.iList = Tri.IndexOf(t);
                        index.iArry = i;
                        return index;
                    }

                }
            }
       
            return index;
        }
        public List<string> CreateAList(string str,int index,int lenght)
        {
            List<string> listLine = new List<string>();
            Match match=NamePoint(str, index);
            while (index < str.Length)
            {
                switch (lenght)
                {
                    case 2:
                           match = NameLine(str, index);
                        break;
                    case 3:
                         match = NameTriangle(str, index);
                        break;
                }
                if (match.Index == 0)
                    break;
                index = match.Index + match.Value.Length;
                listLine.Add(match.Value);
            }
            return listLine;
        }
        /// <summary>
        ///  פונקציה הקוראת לבנאי מלא של נקודה
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="n"></param>
        /// <returns></returns>
       public Point FillsValuesInAPoint(double x,double y,string n)
        {
            Point p = new Point(x, y, n);
            return p;
        }
        /// <summary>
        /// הצבת נקודה במערך הצלעות
        /// </summary>
        /// <param name="nameP"></param>
        /// <param name="p"></param>
        public void PlacingAPoint(string nameP,Point p)
        {
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfRib; i++)
                {
                    if (t.RibsOfTriangle[i].Vertex1.Name.Equals(nameP))
                    {
                        t.RibsOfTriangle[i].Vertex1 = p;
                    }
                    if (t.RibsOfTriangle[i].Vertex2.Name.Equals(nameP))
                    {
                        t.RibsOfTriangle[i].Vertex2 = p;
                    }
                }
            }
        }
        /// <summary>
        /// הצבת נקודה במערך הנקודות
        /// </summary>
        /// <param name="nameP"></param>
        /// <param name="p"></param>
        public void PlacingAPoint2(string nameP, Point p)
        {
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfPoint; i++)
                {
                    if (t.PointOfTriangle[i].Name.Equals(nameP))
                    {
                        t.PointOfTriangle[i] = p;
                    }
                }
            }
        }
        /// <summary>
        /// נקודת חיתוך
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point PointOfIntersection(string p)
        {
            Equation eq1 = new Equation();
            Equation eq2 = new Equation();
            Point point = new Point(p);
            string l1 = "l1";
            string l2 = "l2";
            bool flag = false;
            foreach (var t in Tri)
            {
                for (int i = 0; i < Triangel.NumOfRib; i++)
                {
                    if (t.RibsOfTriangle[i].NameRib.Contains(p) && t.RibsOfTriangle[i].LineEquation != null
                        && t.RibsOfTriangle[i].NameRib.Equals(l2) == false&&flag==false)
                    {
                        eq1 = t.RibsOfTriangle[i].LineEquation;
                        l1 = t.RibsOfTriangle[i].NameRib;
                        flag = true;
                    }

                    if (t.RibsOfTriangle[i].NameRib.Contains(p) && t.RibsOfTriangle[i].LineEquation != null
                          && t.RibsOfTriangle[i].NameRib.Equals(l1) == false)
                    {
                        eq2 = t.RibsOfTriangle[i].LineEquation;
                        l2 = t.RibsOfTriangle[i].NameRib;
                    }
                }
                
            }
            
            point = Tri[0].EquationSolution(point, eq1, eq2);
            return point;
        }
    }


}

