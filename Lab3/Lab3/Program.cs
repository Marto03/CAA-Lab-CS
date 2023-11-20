public class Program
{
    public static double zad1(double x,double n)
    {
        double z = Math.Pow(x, n);
        double y = Math.Pow(x, n - 1);
        if (n > 0)
        {
            z = x * y;
        }
        else if(n == 0)
        {
            z = 1;
        }
        else
        {
            z = 1 / -z;
        }
        n -= 1;
        if(n != 0)
        {

            return z;
        }
        return zad1(x, n);
    }
    private static void Main(string[] args)
    {
        double x = zad1(2,5);
        Console.WriteLine(x);
    }
}