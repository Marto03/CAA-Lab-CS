internal class Program
{
    private static void Main()
    {
        int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
        Console.WriteLine("Input money: ");
        _ = int.TryParse(Console.ReadLine(), out int money);
        //List<int> x = GetChange(money, coins);
        int x = GetChange(money, coins);
        //Console.WriteLine($"Amount inputed: {money} -> The change count is : {x.Count} , given coins are : {string.Join(",",x)}");
        Console.WriteLine($"Amount inputed: {money} -> The change count is : {x}");
        List<int> z = GetChangeRecursive(money, coins);
        Console.WriteLine($"Amount inputed: {money} -> The change count is : {z.Count} , given coins are : {string.Join(",", z)}");
    }
    public static int GetChange(int value , int[] coins)
    {
        if (value <= 0)
        {
            return 0;
        }
        List<int> bestChange = null;
        int count = 0;
        for(int i = coins.Length - 1; i >= 0; i--) 
        {
            if (value - coins[i] >= 0)
            {
                count++;
                value -= coins[i];
            }
        }
        return count;
    }

    public static List<int> GetChangeRecursive(int value, int[] coins)
    {
        if (value <= 0)
        {
            return new List<int>();
        }
        List<int> bestChange = null;
        for (int i = 0; i < coins.Length; i++)
        {
            if (value - coins[i] >= 0)
            {
                List<int> change = GetChangeRecursive(value - coins[i], coins);
                if (bestChange == null || change.Count + 1 < bestChange.Count)
                {
                    bestChange = new List<int>(change);
                    bestChange.Add(coins[i]);
                }
            }
        }
        return bestChange;
    }
}