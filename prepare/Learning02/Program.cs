using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._jobTitle = "Sofware Engineer";
        job1._company = "Microsoft";
        job1._startYear = "2021";
        job1._endYear = "2022";

        Job job2 = new Job();
        job2._jobTitle = "TECH lead";
        job2._company = "Apple";
        job2._startYear = "2022";
        job2._endYear = "2023";

        //System.Console.WriteLine(job1._company);
        //System.Console.WriteLine(job2._company);
        //job1.Display();
        //job2.Display();

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume._personName = "Allison Rose";

        myResume.Display();

    }
}



