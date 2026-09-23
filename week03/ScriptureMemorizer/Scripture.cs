using System;
using System.Collections.Generic;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in words)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText.TrimEnd();
    }

    public void Display()
    {
        Console.WriteLine(GetDisplayText());
    }

    public void HideRandomWords(int count)
    {
        List<int> availableIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        if (availableIndexes.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int numberToHide = Math.Min(count, availableIndexes.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[index];
            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
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