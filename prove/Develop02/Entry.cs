// This class represents a single journal entry with a date, prompt, and user response.
using System;

// Properties for the date of the entry, the prompt, and the user's response.
public class Entry
{
// Properties for the date of the entry, the prompt, and the user's response.    public string Date { get; set; }
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Constructor to initialize a new Entry object.
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // This method overrides the default ToString() to format the entry display.
    public override string ToString()
    {
        return $"Date: {Date} | Prompt: {Prompt} | Response: {Response}";
    }
}
