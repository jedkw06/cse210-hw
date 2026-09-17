class Scripture
{
    private Refrence _refrence;
    private List<Word> _words;
    GetDisplayText()
    {
        string displayText = _refrence.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }
    HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count && hiddenCount < _words.Count)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }
    IsCompletelyHidden()
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