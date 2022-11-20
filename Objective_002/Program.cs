/*Задача 43:
Напишите программу, которая найдёт точку пересечения двух прямых,
заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*/
// Для себя x = (b2-b1) / (k1-k2), a y считаем по второму уравнению.
//при k1=k2 прямые параллельны


void IntersectionPointByEquation(double k1, double b1, double k2, double b2)
{
    if(k1 == k2)
    {
        Console.WriteLine();
        Console.WriteLine($"Lines are parallel.");
    }
    else
    {
        double x = (b2 - b1) / (k1 - k2);
        double y = k2 * x + b2;

        Console.WriteLine();
        Console.WriteLine($"The point of intersection of two lines is:");
        Console.WriteLine($"{x}, {y}");
    }
}

Console.WriteLine("Programm will find the point of intersection of two lines given by the equations Y = K * X + B.");
Console.WriteLine();

// Ввод параметров первой прямой
Console.WriteLine("Please, set parameters for first line:");

Console.WriteLine("Enter value for K1:");
double k1 = double.Parse(Console.ReadLine()!);

Console.WriteLine("Enter value for B1:");
double b1 = double.Parse(Console.ReadLine()!);

//Ввод параметров второй прямой
Console.WriteLine();
Console.WriteLine("Please, set parameters for second line:");

Console.WriteLine("Enter value for K2:");
double k2 = double.Parse(Console.ReadLine()!);

Console.WriteLine("Enter value for B2:");
double b2 = double.Parse(Console.ReadLine()!);

//Вывод результата

IntersectionPointByEquation(k1, b1, k2, b2);