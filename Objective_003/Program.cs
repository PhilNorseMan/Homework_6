/*задача 40 - HARD необязательная.
На вход программы подаются три целых положительных числа. Определить, является ли это сторонами треугольника.
Если да, то вывести всю информацию по нему - площадь, периметр, значения углов треугольника в градусах,
является ли он прямоугольным, равнобедренным, равносторонним.*/

bool TriangleTestBySidesValues(int value1, int value2, int value3) // проверка треугольника на существование
{
    bool check = false;

    if (value1 < value2 + value3 && value2 < value1 + value3 && value3 < value1 + value2)
        check = true;

    return check;
}

double TriangleSquare(double side1, double side2, double side3) // нахождение площади треугольника через формулу Герона
{
    double p = (side1 + side2 + side3) / 2;

    double result = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

    return result;
}

int TrianglePerimeter(int side1, int side2, int side3) // нахождение периметра треугольника
{
    int result = side1 + side2 + side3;

    return result;
}

double[] TriangleAngles(int side1, int side2, int side3) // нахождение углов треугольника
{
    double[] result = new double[3];

    double p = (side1 + side2 + side3) / 2;

    double s = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

    result[0] = Math.Asin((2 * s) / (side1 * side2)) * (180 / Math.PI);

    result[1] = Math.Asin((2 * s) / (side2 * side3)) * (180 / Math.PI);

    result[2] = 180 - result[0] - result[1];

    return result;
}

void TriangleType(int side1, int side2, int side3, double angle1, double angle2, double angle3) // определение типа треугольника
{
    if (angle1 == 90 || angle2 == 90 || angle3 == 90) // прямоугольный
    {
        if (side1 == side2 || side1 == side3 || side2 == side3) // равнобедренный прямоугольный
        {
            Console.WriteLine("Isosceles right triangle");
        }
        else                                                    // просто прямоугольный
        {
            Console.WriteLine("Right triangle");
        }
    }
    else
    {
        if (side1 == side2 && side2 == side3) // равносторонний  
        {
            Console.WriteLine("Equilateral triangle");
        }
        else
        {
            if (side1 == side2 || side1 == side3 || side2 == side3) // равнобедренный
            {
                Console.WriteLine("Isosceles triangle");
            }
            else
            {
                Console.WriteLine("Scalene triangle"); // разносторонний
            }
        }
    }
}


//Начало
Console.WriteLine();
Console.WriteLine("The program will determine if a triangle with the given sides values can exist");
Console.WriteLine("(If such a triangle exists, then the program will show you information on this triangle).");
Console.WriteLine();

InputNumber1: //ввод первой стороны

Console.WriteLine("Please, enter first number:");
int number1 = int.Parse(Console.ReadLine()!);

if(number1 < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (Size of side cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber1;
    }

InputNumber2: // ввод второй стороны

Console.WriteLine("Please, enter second number:");
int number2 = int.Parse(Console.ReadLine()!);

if(number2 < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (Size of side cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber2;
    }

InputNumber3: // ввод третьей стороны

Console.WriteLine("Please, enter third number:");
int number3 = int.Parse(Console.ReadLine()!);

if(number3 < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (Size of side cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber3;
    }

// Определение существования треугольника
if (TriangleTestBySidesValues(number1, number2, number3) == false)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("There can't be triangle with such sides.");
    Console.ResetColor();
    Console.WriteLine();

}
else
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("There can be triangle with such sides.");
    Console.ResetColor();
    Console.WriteLine();

    //Площадь трегуольника
    double square = TriangleSquare(number1, number2, number3);

    Console.WriteLine($"The square of triangle is: {Math.Round(square, 2)}.");

    //Периметр треугольника
    Console.WriteLine($"The perimeter of triangle is: {TrianglePerimeter(number1, number2, number3)}");

    //Углы треугольника
    double[] triangleAngles = TriangleAngles(number1, number2, number3);

    Console.WriteLine($"Angle A of triangle is {Math.Round(triangleAngles[0], 2)} degrees.");
    Console.WriteLine($"Angle B of triangle is {Math.Round(triangleAngles[1], 2)} degrees.");
    Console.WriteLine($"Angle C of triangle is {Math.Round(triangleAngles[2], 2)} degrees.");

    //Тип треугольника
    Console.WriteLine();
    Console.WriteLine($"The type of triangle is:");
    TriangleType(number1, number2, number3, triangleAngles[0], triangleAngles[1], triangleAngles[2]);
    Console.WriteLine();
}