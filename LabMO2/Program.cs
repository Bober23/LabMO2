using LabMO2;
using System.Numerics;

Console.WriteLine("Введите X1");
double x1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите X2");
double x2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите максимальное количество итераций");
int M = Convert.ToInt32(Console.ReadLine());
MyVector xAnswer;
xAnswer = Function.GetMinPoint(x1, x2, M, 0.15, 0.2);
double minFunctionValue = Function.GetFunction(xAnswer);
Console.WriteLine($"Минимальное значение функции = {minFunctionValue}");
Console.WriteLine($"Достигнуто в точке ({xAnswer.x1}; {xAnswer.x2})");