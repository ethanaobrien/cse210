
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _isSymbol;
    
    public Word(string text)
    {
        _text = text;
    }
    
    public void Hide()
    {
        _isHidden = true;
    }
    
    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public bool IsSymbol()
    {
        return _isSymbol;
    }
    
    public string GetDisplayText()
    {
        List<string> symbols = [",", ";", ":", ".", "?", "'", "\"", "[", "]"];
        
        if (!_isHidden) return _text;
        
        var hasStartSymbol = symbols.Any(symbol => _text.StartsWith(symbol));
        var hasEndSymbol = symbols.Any(symbol => _text.EndsWith(symbol));
        var text = new StringBuilder(new string('_', _text.Length));
        if (hasEndSymbol)
        {
            text[^1] = _text[^1];
        }

        if (hasStartSymbol)
        {
            text[0] = _text[0];
        }
        
        return text.ToString();
    }
}