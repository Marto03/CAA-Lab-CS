internal class Program
{


    private static void Main(string[] args)
    {
        string n;
        //int a = 2;
        //int b = 3;
        //a *= b; // a = 6
        //b = a/b; // b = 2
        //a = a/b; // a = 3
        //Console.WriteLine($"a = {a} b = {b}");
        Console.WriteLine("Input a three digit number");
        n = Console.ReadLine();
        if (int.TryParse(n, out int number))
        {
            int Sum = Zad2(number);
            Console.WriteLine(Sum);
        }
        else
        {
            Console.WriteLine("Wrong number!");
        }

        string aString;
        string bString;
        Console.WriteLine("Input a:");
        aString = Console.ReadLine();
        if(int.TryParse(aString, out int a))
        {
            Console.WriteLine("Input b:");
            bString = Console.ReadLine();
            if(int.TryParse(bString, out int b))
            {
                Zad4(a, b);
            }
        }

        else
        {
            Console.WriteLine("Wrong number");
        }
        Zad9();
        int arrN;
        string arrNString;
        string numbersString;
        Console.WriteLine("Input how much elements: ");
        arrNString = Console.ReadLine();
        if (int.TryParse(arrNString, out arrN))
        {
            int[] arr = new int[arrN];

            for (int i = 0; i < arrN; i++)
            {
                Console.WriteLine($"Input number[{i + 1}]:");
                numbersString = Console.ReadLine();
                if (int.TryParse(numbersString, out arr[i]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Wrong number");
                }
            }

            int c = Zad11(arr);

            Console.WriteLine($"The count is : {c}");
        }

        

    }
    public static int Zad2(int x)
    {
        string xString = x.ToString();
        int s = 0;
        for (int i = 0; i < xString.Length; i++)
        {
            int temp;
            temp = x % 10;
            x /= 10;
            s += temp;
        }
        return s;
    }

    public static void Zad4(int a, int b)
    {
        a += b;
        b = a - b;
        a -= b;
        Console.WriteLine($"a = {a} b = {b}");
    }

    public static void Zad9()
    {
        int x = 2;
        int n = 0;
        while (x < 100)
        {
            x = 2 * x + 10;
            n++;
        }
        Console.WriteLine($"The first x > 100 is at index {n} , the number is : {x}");
    }

    public static int Zad11(int[] arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Length-1; i++)
        {
            if((arr[i] > 0 && arr[i+1] < 0) || (arr[i] < 0 && arr[i+1] > 0))
            {
                count++;
            }
        }
        return count;
    }

}