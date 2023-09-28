using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        string user_response;
        do {
            System.Console.WriteLine("Do you want to continue? ");
            user_response = Console.ReadLine();
        } 
        while (user_response == "yes" || user_response == "y");
    }
}