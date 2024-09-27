using System;
using System.Collections.Generic;
using System.IO;

// The Journal class manages a collection of journal entries and provides functionality
// to add new entries, display the entire journal, and save/load entries to/from a file.
public class Journal
{
    // A list to store all journal entries.
    public List<Entry> Entries { get; set; } = new List<Entry>();

    // Adds a new Entry object to the journal.
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        // Using a StreamWriter to write each entry to the file in a custom format.
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                outputFile.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        Entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
    }
}
