using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nScripture completely hidden.");
    }
}

public class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public string GetDisplayText()
    {
        return $"{reference.GetReference()} {string.Join(" ", words.Select(w => w.GetDisplayText()))}";
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = Math.Min(3, words.Count(w => !w.IsHidden())); // Hide up to 3 words
        for (int i = 0; i < wordsToHide; i++)
        {
            List<Word> unhiddenWords = words.Where(w => !w.IsHidden()).ToList();

            if (unhiddenWords.Count > 0)
            {
                int index = random.Next(unhiddenWords.Count);
                unhiddenWords[index].Hide();
            }

        }
    }

    public bool IsCompletelyHidden()
    {
        return words.All(w => w.IsHidden());
    }
}

public class ScriptureReference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int? endVerse;

    public ScriptureReference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = null;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReference()
    {
        if (endVerse.HasValue)
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}";
        }
    }
}

public class Word
{
    private string text;
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        if (isHidden)
        {
            return new string('_', text.Length);
        }
        else
        {
            return text;
        }
    }
}