/*Задача 41:
Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
*/

static int[] InputArrayByString()
{
    Console.WriteLine("");

NewInput:

    Console.Write("Please, input your numbers (!!! Separate them by commas!!!):");
    Console.WriteLine();

    string str = Console.ReadLine()!;
    string[] strSep = str.Split(',');

    int[] result = new int[strSep.Length];

    for (int i = 0; i < strSep.Length; i++)
    {
        string temp = strSep[i].Trim();

        if (int.TryParse(temp, out int tempInt))
        {
            result[i] = tempInt;
        }
        else
        {
            Console.WriteLine($"ERROR: Incorrect input! (Symbol {i +1})");

            goto NewInput;
        }
    }

    return result;
}

void PositiveNumbersTest(int[] arr)
{
    int count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if(arr[i] > 0)
            count ++;
    }

    int remain = count % 10;

    if(remain == 1)
    {
        Console.WriteLine($"There is {count} positive number (total count: {arr.Length}).");
    }
    else
    {
        Console.WriteLine($"There is {count} positive numbers (total count: {arr.Length}).");
    }
}

int[] array = InputArrayByString();

PositiveNumbersTest(array);