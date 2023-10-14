using System.Data;
internal class Program
{
    private static void Main(string[] args)
    {
        int n;
        Console.WriteLine("Input how much numbers:");
        string nString = Console.ReadLine();
        if (int.TryParse(nString, out n))
        {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Input number [{i + 1}]");
                string numbersString = Console.ReadLine();
                if (int.TryParse(numbersString, out arr[i]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Wrong number");
                }
            }

            //long x = Zad12(arr);
            //Console.WriteLine($"The production of all numbers in the array which sum of it's pair is not bigger than 120: {x}");

            //int y = Zad13(arr);
            //Console.WriteLine($"The count of equal numbers next to each other is: {y}");


            Console.WriteLine("Input how much rows:");
            string nRows = Console.ReadLine();
            Console.WriteLine("Input how much cols:");
            string nCols = Console.ReadLine();
            if (int.TryParse(nRows, out int rows) && (int.TryParse(nCols, out int cols)))
            {
                int[][] arr2 = new int[rows][];
                for (int i = 0; i < rows; i++)
                {
                    arr2[i] = new int[cols];
                }
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.WriteLine($"Input number [{i + 1}][{j + 1}]");
                        string numbersString = Console.ReadLine();
                        if (int.TryParse(numbersString, out arr2[i][j]))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Wrong number");
                        }
                    }
                }
                //    for (int i = 0; i < rows; i++)
                //    {
                //        for (int j = 0; j < cols; j++)
                //        {
                //            Console.Write($"{arr2[i][j]} ");
                //        }
                //        Console.WriteLine();
                //    }
                //    int s = Zad15(arr2);
                //    Console.WriteLine($"The sum of the numbers across the perimeter is: {s}");
                //    Zad16(arr2);
                //}
                Zad19(arr2);
                
            }
        }
    }

    public static long Zad12(int[] arr)
    {
        long product = 1;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                int sum = arr[i] + arr[j];
                if (sum <= 120)
                {
                    product *= (long)arr[i] * (long)arr[j];
                }
            }
        }
        return product;
    }

    public static int Zad13(int[] arr)
    {
        int count = 0;
        bool flag = false;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == arr[i + 1]) // Setting the flag to true , if the number is the same as the other , and next to it is the same number (площадка)
            {
                if (!flag)
                {
                    flag = true;
                    count++;
                }
            }
            else // Ако не , флага става false и проверява другите числа , докато не стигне до числа , които са еднакви
            {
                flag = false;
            }
        }
        return count;
    }

    public static int Zad15(int[][] arr)
    {
        int s = 0;
        int rows = arr.Length;
        int cols = arr[0].Length;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1) // Преминава през първия и последния ред , първата и последната колона на
                                                                        // масива и сумира елементите
                {
                    s += arr[i][j];
                }
            }
        }
        return s;
    }

    public static void Zad16(int[][] arr)
    {
        int diagonalSum = 0;
        int rows = arr.Length;
        int cols = arr[0].Length;

        int count = 0;
        int[] resultArray = new int[rows + 1];
        List<int> numsLessThanIndex = new List<int>(); // Запазвам всички числа , чийто индекс е по-голям от стойността ; ЗА НАГЛЕДНОСТ И ПРОВЕРКА

        int minDim = Math.Min(rows, cols); // по-малката размерност за да не се стигне до момент , редовете да са 2 , а колоните 3 и да има for цикъл,
                                           // който обхожда елементите до i < (cols) = 3; което ще хвърли грешка , че няма такъв елемент 
        for (int i = 0; i < minDim; i++)
        {
            diagonalSum += arr[i][i];
        }
        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                rowSum += arr[i][j]; // Смята сумата на всеки ред 
                if (j < i && arr[i][j] < i + j) // Проверява числата под главния диагонал (Ако искам числата над диагонала, j > i)
                {
                    numsLessThanIndex.Add(arr[i][j]);
                    count++;
                }
            }
            resultArray[i] = rowSum;
        }
        /*
         * 0 ред 0 колона   1 колона   2 колона    main diagonal   0
         * 1 ред 0 колона   1 колона   2 колона                        1
         * 2 ред 0 колона   1 колона   2 колона                            2
         */

        resultArray[rows] = count;
        Console.WriteLine("Sum of the numbers of the main diagonal " + diagonalSum);
        Console.WriteLine("Sum of the rows and count of numbers under the main diagonal, less than its index:");
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"resultArray[{i}] = {resultArray[i]}");
        }
        Console.WriteLine($"Count: {resultArray[rows]}");
        for (int i = 0; i < numsLessThanIndex.Count; i++)
        {
            Console.WriteLine($"The numbers less than their index: {numsLessThanIndex[i]}");
        }
    }
    public static void Zad19(int[][] arr)
    {
        int secondDiagonalSum = 0;
        int rows = arr.Length;
        int cols = arr[0].Length;
        int[][] arr2 = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            arr2[i] = new int[cols];
            for (int j = cols - 1; j >= 0; j--)
            {
                //Console.Write(arr[i][j] + "\t");
                arr2[i][cols - 1 - j] = arr[i][j];
                if (i == cols - 1 - j)
                {
                    secondDiagonalSum += arr[i][j];
                }
            }
            Console.WriteLine();
        }
        /* 1    2   3   4       1   2   3
         * 5    6   7   8       4   5   6
         * 9    10  11  12      7   8   9
         */

        for (int i = 0; i < arr2.Length; i++) //Възможно и така да се сметне
        {
            for (int j = 0; j < arr2[0].Length; j++)
            {
                Console.Write(arr2[i][cols - 1 - j] + "\t");
                //if(i == j)
                //{
                //    secondDiagonalSum += arr[i][cols - 1 - j];
                //}
            }
            Console.WriteLine();
        }
        Console.WriteLine(secondDiagonalSum);
    }
}
