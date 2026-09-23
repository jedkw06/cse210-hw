using System;

public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verse;
    private readonly int _endVerse;
    private readonly bool _hasRange;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
        _hasRange = startVerse != endVerse;
    }

    public string GetDisplayText()
    {
        if (_hasRange)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }

        return $"{_book} {_chapter}:{_verse}";
    }
}