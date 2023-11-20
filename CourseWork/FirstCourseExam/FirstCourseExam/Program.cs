using System;

public class TreeNode
{
    public int Value { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
public class TreeEx
{
    public static int SumEvenNums(TreeNode tree)
    {
        if(tree == null) return 0;
        int sum = 0;
        if (tree.Value % 2 == 0)
        {
            sum += tree.Value;
        }
        sum += SumEvenNums(tree.Left);
        sum += SumEvenNums(tree.Right);

        return sum;
    }
    public static int SumOddNums(TreeNode tree)
    {
        if(tree == null) return 0;
        int sum = 0;
        if (tree.Value % 2 != 0)
        {
            sum += tree.Value;
        }
        sum += SumOddNums(tree.Left);
        sum += SumOddNums(tree.Right);
        return sum;
    }
}

class Program
{
    static void Main()
    {
        TreeNode root = new(10);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(35);
        root.Left.Left = new TreeNode(20);
        root.Right.Right = new TreeNode(40);
        root.Left.Left.Left = new TreeNode(32);
        root.Left.Left.Left.Right = new TreeNode(45);
        int sumEven = TreeEx.SumEvenNums(root);
        int sumOdd = TreeEx.SumOddNums(root);
        Console.WriteLine($"The sum of even nums is : {sumEven}");
        Console.WriteLine($"The sum of odd nums is : {sumOdd}");
    }
}
