using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabMO2
{
    static class Function
    {
        public static double GetFunction(MyVector x)
        {
            return 6*Math.Pow(x.x1,2)+0.3*x.x1*x.x2+2*Math.Pow(x.x2,2);
        }
        public static MyVector GetGradient(MyVector x)
        {
            var gradient = new MyVector(12 * x.x1 + 0.3 * x.x2, 0.3 * x.x1 + 4 * x.x2);
            return gradient;
        }
        public static double GetNorma(MyVector vector)
        {
            return Math.Sqrt(Math.Pow(vector.x1,2)+Math.Pow(vector.x2,2));
        }
        public static MyVector GetMinPoint(double x1,double x2, int maxNumberOfIterations, double e1,double e2)
        {
            MyVector xCurrent = new MyVector(x1,x2); //1
            Console.WriteLine("");
            Console.WriteLine("Начальные значения");
            Console.WriteLine($"X = ({xCurrent.x1}; {xCurrent.x2})");
            Console.WriteLine($"Значение функции = {GetFunction(xCurrent)}");
            Console.WriteLine("");
            for (int k = 0; k < maxNumberOfIterations; k++) //2 and 5
            {
                MyVector gradient = GetGradient(xCurrent); //3
                if (GetNorma(gradient) < e1)
                {
                    Console.WriteLine($"Минимум найден на итерации {k + 1}");
                    return xCurrent; //4
                }
                double t = 0.5; //6
                MyVector xNext;
                do
                {
                    xNext = new MyVector(xCurrent.x1 - t * gradient.x1, xCurrent.x2 - t * gradient.x2); //7
                    t = t / 2;  //8
                } while (GetFunction(xNext) - GetFunction(xCurrent) >= 0);
                if (GetNorma(new MyVector(xNext.x1 - xCurrent.x1, xNext.x2 - xCurrent.x2)) < e2)
                {
                    if (Math.Abs(GetFunction(xNext) - GetFunction(xCurrent)) < e2)
                    {
                        Console.WriteLine($"Минимум найден на итерации {k + 1}");
                        return xNext;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"Конец итерации {k+1}");
                Console.WriteLine($"X = ({xNext.x1}; {xNext.x2})");
                Console.WriteLine($"Значение функции = {GetFunction(xNext)}");
                Console.WriteLine("");
                xCurrent = xNext;
            }
            return xCurrent;
        }
    }
}
