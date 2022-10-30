// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// int[,] array = GetArray(5, 5, 1, 9);
// PrintArray(array);
// Console.WriteLine("");
// int[,] NewArray = SortFromMaxArray(array);
// Console.WriteLine("Отсортированный массив");
// PrintArray(NewArray);


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// int[,] array = GetArray(6, 4, 1, 9);
// PrintArray(array);
// Console.WriteLine("");
// FindMinSumRow(array, 999);


int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue+1);
        }
    }
    return result;
}
void PrintArray(int [,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]}; ");
        }
        Console.WriteLine();
    }
}
int[,] SortFromMaxArray(int[,] array)
{
    int step;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int a = j+1; a < array.GetLength(1); a++)
            {
                if (array[i,j] < array[i,a])
                {
                    step = array[i,j];
                    array[i,j] = array[i,a];
                    array[i,a] = step;
                }
            }
        }
    }
    return array;
}

double FindMinSumRow(int [,] array, int maxValue)
{
    double sum = 0;
    double minsum = maxValue;
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    { 
        for (int j = 0; j < array.GetLength(1); j++) 
        { 
        sum += (double)array[i, j];
        }
        if (sum < minsum) 
        {
        minsum = sum;
        row = i+1;
        }        
        sum = 0;
      }
    Console.Write($"Минимальная сумма элементов массива равна {minsum}, строка {row}.");
    return row;
}

//Задача 58: Задайте две матрицы. Напишите программу, 
//которая будет находить произведение двух матриц.

// int[,] a = GetArray(3, 3, 1, 3);
// PrintArray(a);
// Console.WriteLine("");
// int[,] b = GetArray(3, 3, 1, 3);
// PrintArray(b);
// Console.WriteLine("");
// int[,] c = MultiplicationOfMatrix(a, b);
// Console.WriteLine($"При умножении матрицы a на матрицу b получаем:");
// PrintArray(c);

int [,] MultiplicationOfMatrix(int [,] a, int [,] b)
{
    int[,] res = new int[a.GetLength(0), a.GetLength(1)];
    for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                for (int x = 0; x < b.GetLength(0); x++)
                {
                    res[i,j] += a[i,x] * b[x,j];
                }
            }
        }
    return res;
}


// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// int[,,] array = GetArray3D(2, 2, 2, 10,99);
// PrintArray3D(array);
// Console.WriteLine("");

int[,,] GetArray3D(int m, int n, int z, int minValue, int maxValue)
{
    int[,,] result = new int[m, n, z];
    
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            int k = 0;
            while (k < z)
            {
                int NewElement = new Random().Next(minValue, maxValue + 1);
                if (ChangeElement(result, NewElement)) continue;
                result[i, j, k] = NewElement;
                k++;
            }
        }
    }
    return result;
}

void PrintArray3D(int [,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
            Console.Write($"{array[i,j,k]} ");
            Console.Write($"({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        
    }
    
}

bool ChangeElement(int[,,] Array, int element)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            for (int k = 0; k < Array.GetLength(2); k++)
            {
                if (Array[i, j, k] == element) return true;
            }
        }
    }
    return false;
}
