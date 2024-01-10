using System;

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {
            string str = "";
            string reverse = "";
            int Length = 0;
            Console.WriteLine("Enter a Word");
            str = Console.ReadLine();
            Length = str.Length - 1;
            while (Length >= 0)
            {
                reverse = reverse + str[Length];
                Length--;
            }
            Console.WriteLine("Reverse of a Word is ", reverse);
            Console.ReadLine();
        }
    }
}
