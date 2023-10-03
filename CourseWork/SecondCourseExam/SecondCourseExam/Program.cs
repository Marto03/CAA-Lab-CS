internal class Program
{
    public static int countPerim(int[][] arr)
    {
        int count = 0;
        int rows = arr.Length;
        int cols = arr[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
                {
                    if (isPrime(arr[i][j]))
                    {
                        Console.Write(arr[i][j] + " ");
                        count++;
                    }

                    //if (i > 0)
                    //{
                    //for (int k = 1; k < Math.Max(rows, cols); k++)
                    //{
                    //    if (arr[i][j] % k != 0)
                    //    {
                    //        count++;
                    //    }
                    //}
                    //}

                }
            }
        }
        return count;
    }
    public static bool isPrime(int n)
    {
        if (n <= 1)
        {
            return false;
        }
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("How much rows:");
        string rowsString = Console.ReadLine();
        Console.WriteLine("How much cols:");
        string colsString = Console.ReadLine();
        if (int.TryParse(rowsString, out int rows) && int.TryParse(colsString, out int cols))
        {
            int[][] arr = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                arr[i] = new int[cols];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"Input number [{i}][{j}]");
                    string nString = Console.ReadLine();
                    if (int.TryParse(nString, out arr[i][j]))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Wrong number!");
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            int count = countPerim(arr);
            Console.WriteLine($"count = {count}");
        }
    }
}