using System;
//public class HelloWorld
//{
//    public static void Main(string[] args)
//    {
//        string str = "";
//        string reverse = "";
//        int Length = 0;
//        Console.WriteLine("Enter a Word");

//        str = Console.ReadLine();

//        Length = str.Length - 1;
//        while (Length >= 0)
//        {
//            reverse = reverse + str[Length];
//            Length--;
//        }
//        Console.WriteLine("Reverse word is {0}", reverse);
//        Console.ReadLine();
//    }
//}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        int reverse = 0, rem, temp;

        
        Console.WriteLine("Enter a Number");
        int num = int.Parse(Console.ReadLine());
        temp = num;

        while (temp != 0)
        {
            rem = temp % 10;
            reverse = reverse * 10 + rem;
            temp /= 10;
        }

       
        if (num == reverse)
            Console.WriteLine(num + " is Palindrome");
        else
            Console.WriteLine(num + " is not Palindrome");
    }
}