using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Linq;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }
    public List<string> Tags { get; set; }
}

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string prompt, string response, string mood, List<string> tags)
    {
        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now.ToString(),
            Mood = mood,
            Tags = tags
        };

        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Mood: {entry.Mood}");
            Console.WriteLine($"Tags: {string.Join(", ", entry.Tags)}");
            Console.WriteLine();
        }
    }

    public void SaveToCsv(string filename)
    {
        using (var writer = new StreamWriter(filename))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(entries);
        }
    }

    public void LoadFromCsv(string filename)
    {
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var loadedEntries = csv.GetRecords<JournalEntry>().ToList();
            entries.AddRange(loadedEntries);
        }
    }
}

public class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a CSV file");
            Console.WriteLine("4. Load the journal from a CSV file");
            Console.WriteLine("5. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter a prompt: ");
                    string prompt = Console.ReadLine();
                    Console.Write("Enter a response: ");
                    string response = Console.ReadLine();
                    Console.Write("Enter your mood: ");
                    string mood = Console.ReadLine();
                    Console.Write("Enter tags (comma-separated): ");
                    List<string> tags = Console.ReadLine().Split(',').Select(tag => tag.Trim()).ToList();

                    journal.AddEntry(prompt, response, mood, tags);
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter a filename to save the journal (e.g., journal.csv): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToCsv(saveFilename);
                    Console.WriteLine("Journal saved successfully.");
                    break;
                case 4:
                    Console.Write("Enter a filename to load the journal (e.g., journal.csv): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromCsv(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
