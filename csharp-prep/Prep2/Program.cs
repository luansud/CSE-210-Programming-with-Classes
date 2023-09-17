using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please Type your Grade:");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        string letter = "";

        if (grade >= 90){letter="A";}
        else if (grade >= 80){letter="B";}
        else if (grade >= 70){letter="C";}
        else if (grade >= 60){letter="D";}
        else {letter="F";}
        Console.WriteLine($"Your grade is: {letter}");

        if (grade>=70){System.Console.WriteLine("Congratulations, You passed!");}
        else {System.Console.WriteLine("I'm sorry, Better luck next time!");}
    }
}