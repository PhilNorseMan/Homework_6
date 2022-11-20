/*задача 2 HARD необязательная.
Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры).
Вывести на экран красивенько таблицей. Найти минимальное число и его индекс, найти максимальное число и его индекс, среднее арифметическое.
Вывести эту информацию на экран.*/

void PrintArray(int[,] arr) // Принтер двумерного массива
{
    int count_x = arr.GetLength(0);
    int count_y = arr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(arr[i, j] + "    "); // промежуток TAB
        Console.WriteLine();
    }
}

void PrintArrayIndexOf(int[,] arr) // Принтер для индексов мин макс эл-тов
{
    int count_x = arr.GetLength(0);
    int count_y = arr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
        {
             Console.Write(arr[i,j]);
            
            if (j != count_y - 1)
                Console.Write(",");
        }
        Console.WriteLine();
    }
}

void FillArray(int[,] matr) // Рандомайзер
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

int FindMaxValue(int[,] arr) // Нахождение максимального элемента
{
    int i = 0;
    int j = 0;
    int max = arr[i,j];

    for (i = 0; i < arr.GetLength(0); i++)
    {
        for (j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i,j] > max)
            max = arr[i,j];
        }
    }

    return max;
}

int CountOfMaxValueDoubles(int[,] arr) // Подсчет количества повторений максимального элемента
{
    int count = 0;
    int example = FindMaxValue(arr);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i,j] == example)
            {
                count++;
            }
        }
        
    }
    return count;
}

int[,] ContainerForMaxValueDoubles(int[,] arr) // Вывод массива всех позиций где есть макс значение.
{
    int example = FindMaxValue(arr);
    int[,] maxPositions = new int[CountOfMaxValueDoubles(arr), 2];
    int positionString = 0;
    int positionColumn = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] == example)
            {
                maxPositions[positionString, positionColumn] = i;
                positionColumn++;
                maxPositions[positionString, positionColumn] = j;
                positionString++;
                positionColumn = positionColumn - 1;
            }
        }
        
    }
    return maxPositions;
}

int FindMinValue(int[,] arr) // Нахождение минимального элемента
{
    int i = 0;
    int j = 0;
    int min = arr[i,j];

    for (i = 0; i < arr.GetLength(0); i++)
    {
        for (j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i,j] < min)
                min = arr[i,j];
        }
    }

    return min;
}

int CountOfMinValueDoubles(int[,] arr) // Подсчет количества повторений минимального элемента
{
    int count = 0;
    int example = FindMinValue(arr);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i,j] == example)
            {
                count++;
            }
        }
        
    }
    return count;
}

int[,] ContainerForMinValueDoubles(int[,] arr) // Вывод массива всех позиций где есть мин значение.
{
    int example = FindMinValue(arr);
    int[,] minPositions = new int[CountOfMinValueDoubles(arr), 2];
    int positionString = 0;
    int positionColumn = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] == example)
            {
                minPositions[positionString, positionColumn] = i;
                positionColumn++;
                minPositions[positionString, positionColumn] = j;
                positionString++;
                positionColumn = positionColumn - 1;
            }
        }
        
    }
    return minPositions;
}

double FindArithmeticalMean(int[,] arr) // Подсчет среднего арифметического
{
    double sum = 0;
    int count = 0;

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
        sum += arr[i, j];
        count++;
        }
    }

    double result = sum / count;

    return result;
}

Console.WriteLine();
Console.WriteLine("The program will generate random two-dimensional array, using your information.");
Console.WriteLine();

Console.WriteLine("Please, set the first dimension size of array:");
int firstDimension = int.Parse(Console.ReadLine()!);

Console.WriteLine("Please, set the second dimension size of array:");
int secondDimension = int.Parse(Console.ReadLine()!);
Console.WriteLine();

int[,] matrix = new int[firstDimension, secondDimension];

Console.WriteLine("Generated array is:");

FillArray(matrix);
PrintArray(matrix);
Console.WriteLine();

//Вывод макс элемента
int maxElement = FindMaxValue(matrix);
Console.WriteLine($"Max element is: {maxElement}.");

//Вывод мин элемента
int minElement = FindMinValue(matrix);
Console.WriteLine($"Min element is: {minElement}.");

//Вывод индексов макс элемента
Console.WriteLine();
Console.WriteLine("Indexes of max element:");
int[,] indexMaxValue = ContainerForMaxValueDoubles(matrix);
PrintArrayIndexOf(indexMaxValue);

//Вывод индексов мин элемента
Console.WriteLine();
Console.WriteLine("Indexes of min element:");
int[,] indexMinValue = ContainerForMinValueDoubles(matrix);
PrintArrayIndexOf(indexMinValue);

//Вывод среднего арифметического
Console.WriteLine();
Console.WriteLine($"Arithmetical mean is: {FindArithmeticalMean(matrix)}");
Console.WriteLine();