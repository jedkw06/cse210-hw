class Refrence(string book, int chapter, int verse,)
{
    
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endverse;
    GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}-{_endverse}";
    }
}