internal class Program
{
    private static void Main(string[] args)
    {
        int n;

        Console.WriteLine("Input how much numbers:");
        string nString = Console.ReadLine();
        if(int.TryParse(nString, out n))
        {
            int[] arr = new int[n];
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Input number [{i+1}]");
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

            long x = Zad12(arr);
            Console.WriteLine($"The production of all numbers in the array which sum of it's pair is not bigger than 120: {x}");

            int y = Zad13(arr);
            Console.WriteLine($"The count of equal numbers next to each other is: {y}");


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
                        Console.WriteLine($"Input number [{i + 1}][{j+1}]");
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
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write($"{arr2[i][j]} ");
                    }
                    Console.WriteLine();
                }
                int s = Zad15(arr2);
                Console.WriteLine(s);
                Zad16(arr2);
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
                    product *= (long)arr[i] * arr[j];
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
            if (arr[i] == arr[i + 1])
            {
                if (!flag)
                {
                    flag = true;
                    count++;
                }
            }
            else
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
        //for(int i = 0 ; i < rows; i++)
        //{
        //    s += arr[i][0];
        //    s += arr[i][cols-1];
        //}
        //for (int j = 0; j < cols; j++)
        //{
        //    s += arr[0][j];
        //    s += arr[rows-1][j];
        //}
        //s -= arr[0][0] + arr[0][cols - 1] + arr[rows - 1][0] + arr[rows - 1][cols - 1];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
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
        int[] resultArray = new int[rows+1];
        int minDim = Math.Min(rows, cols); // по-малката размерност
        for (int i = 0; i < minDim; i++)
        {
            diagonalSum += arr[i][i];
        }
        for (int i = 0; i < rows; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < cols; j++)
            {
                rowSum += arr[i][j];
                if (j<i && arr[i][j] < i + j)
                {
                    count++;
                }
            }
            resultArray[i] = rowSum;

        }

        resultArray[rows] = count;
        Console.WriteLine("Sum of the numbers of the main diagonal " + diagonalSum);
        Console.WriteLine("Sum of the rows and count of numbers under the main diagonal, less than its index:");
        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"resultArray[{i}] = {resultArray[i]}, Count: {resultArray[rows]}");
        }
    }
}
