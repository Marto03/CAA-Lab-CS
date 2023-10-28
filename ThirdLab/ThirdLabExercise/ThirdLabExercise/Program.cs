internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 10,20,20,20 , 30,30, 50, 50};
        int temp = 0;
        for(int i =0; i < arr.Length; i++)
        {
                temp = FindGCD(temp, arr[i]);
        }
        Console.WriteLine(temp);
        int count = 0;
        bool flag = false;
        int countFlags = 1;
        for(int i = 0; i < arr.Length; i++)
        {
            if (flag == true)
            {
                countFlags++;
                continue;
            }
            if (arr[i] == arr[i + 1])
            {
                flag = true;
                count++;
            }
            else if (arr[i] == arr[i + 1] && flag == true)
            {
                flag = false;
            }
        }
        Console.WriteLine(count);
        Console.WriteLine(countFlags);
    }
    public static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

}