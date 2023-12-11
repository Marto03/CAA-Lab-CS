using System;
using System.Xml.Linq;

public class Tree
{
    public int Value { get; set; }
    public Tree? Left { get; set; }
    public Tree? Right { get; set; }

    public Tree(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
public class TreeEx
{
    public static int SumEvenNums(Tree tree)
    {
        if (tree == null) return 0;
        int sum = 0;
        if (tree.Value % 2 == 0)
        {
            sum += tree.Value;
            Console.Write(tree.Value + " ");
        }
        sum += SumEvenNums(tree.Left);
        sum += SumEvenNums(tree.Right);

        return sum;
    }
    public static int SumOddNums(Tree tree)
    {
        if (tree == null) return 0;
        int sum = 0;
        if (tree.Value % 2 != 0)
        {
            sum += tree.Value;
            Console.Write(tree.Value + " ");
        }
        sum += SumOddNums(tree.Left);
        sum += SumOddNums(tree.Right);
        return sum;
    }
}

class Program
{
    static Tree ReadTreeFromUser()
    {
        Console.WriteLine("Enter a value for the node (or type 'exit' to finish): ");
        string input = Console.ReadLine();

        if (input.ToLower() == "exit")
        {
            return null;
        }
        if (int.TryParse(input, out int value))
        {
            Console.WriteLine("Enter Left tree(1) or Right tree(2):");
            string choice = Console.ReadLine();

            Tree node = new Tree(value);

            if (int.TryParse(choice, out int choiceI))
            {
                switch (choiceI)
                {
                    case 1:
                        Console.WriteLine("Enter number for the left tree:");
                        node.Left = ReadTreeFromUser();
                        return node;
                    case 2:
                        Console.WriteLine("Enter number for the right tree:");
                        node.Right = ReadTreeFromUser();
                        return node;
                    default:
                        Console.WriteLine("Wrong input! Input 'exit' or proper whole number!");
                        return ReadTreeFromUser();
                }
            }
            else
            {
                return node;
            }
        }
        Console.WriteLine("Wrong input! Input 'exit' or proper whole number!");
        return ReadTreeFromUser();

    }
    static void Main()
    {
        Tree root = ReadTreeFromUser();
        //Tree root = new(10);
        //root.Left = new Tree(5);
        //root.Right = new Tree(35);
        //root.Left.Left = new Tree(20);
        //root.Right.Right = new Tree(40);
        //root.Left.Left.Left = new Tree(32);
        //root.Left.Left.Left.Right = new Tree(45);
        Console.Write("Even nums => ");
        int sumEven = TreeEx.SumEvenNums(root);
        Console.Write("\nOdd nums => ");
        int sumOdd = TreeEx.SumOddNums(root);
        Console.WriteLine($"\nThe sum of even nums is : {sumEven}");
        Console.WriteLine($"The sum of odd nums is : {sumOdd}");
    }
}
