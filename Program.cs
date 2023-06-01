//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по 
//убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

int[,] CreateArray(int m, int n, int start, int finish)
{
    int[,] array = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Random random = new Random();
            array[i, j] = random.Next(start, finish + 1);
        }
    }
    return array;
}


void PrintArray(int[,] array)
{
    Console.Write("[");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if ((i != array.GetLength(0) - 1) || (j != array.GetLength(1) - 1))
                Console.Write($"{array[i, j]}; ");
            else
                Console.WriteLine($"{array[i, j]}]");
        }
        Console.WriteLine();
    }
}


void QuickSort(int[] sortArr, int begin, int end)
{
    if (sortArr.Length == 0 || begin >= end) return;

    int middle = begin + (end - begin) / 2;
    int border = sortArr[middle];

    int i = begin, j = end;
    while (i <= j)
    {
        while (sortArr[i] > border) i++;
        while (sortArr[j] < border) j--;
        if (i <= j)
        {
            int temp = sortArr[i];
            sortArr[i] = sortArr[j];
            sortArr[j] = temp;
            i++;
            j--;
        }
    }

    if (begin < j) QuickSort(sortArr, begin, j);
    if (end > i) QuickSort(sortArr, i, end);
}

int[] RowArray(int[,] arr, int row)
{
    int[] rowArr = new int[arr.GetLength(1)];
    for (int col = 0; col < arr.GetLength(1); col++)
    {
        rowArr[col] = arr[row, col];
    }
    return rowArr;
}

void BuildArray(int[] rowArr, int[,] arr, int row)
{
    for (int col = 0; col < rowArr.Length; col++)
    {
        arr[row, col] = rowArr[col];
    }
}

Console.Write("Введите количество строк массива m= ");
int m = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов массива n= ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите начало диапозона start= ");
int start = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите окончание диапазона finish= ");
int finish = Convert.ToInt32(Console.ReadLine());
if (finish < start)
{
    int temp = finish;
    finish = start;
    start = temp;
}


int[,] arr = CreateArray(m, n, start, finish);
PrintArray(arr);

for (int row = 0; row < arr.GetLength(0); row++)
{
    int[] rowArr = RowArray(arr, row);
    QuickSort(rowArr, 0, arr.GetLength(1) - 1);
    BuildArray(rowArr, arr, row);
}
PrintArray(arr);
