using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating a new Scripture object for Philippians 4:13
        Scripture scripture = new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.");

        // Continue looping until all words are hidden
        while (!scripture.IsAllHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2);  // Hides 2 words at a time
        }

        Console.WriteLine("All words are hidden. Good job!");
    }
}

// Reference class to store and display the scripture reference details
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    // Single Verse Constructor
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Method to return formatted reference text
    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}

// Word class to manage individual words and their visibility
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        return _isHidden ? "___" : _text;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}

// Scripture class to represent the entire scripture with reference and text
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the provided text into words and create Word objects
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    // Method to hide a random number of words
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    // Method to display the complete scripture text with hidden words
    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} - {scriptureText.Trim()}";
    }

    // Method to check if all words are hidden
    public bool IsAllHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
