public class Animals
{
    // Backing field for Description
    private string _description = "Unknown";

    // Description - init only, with validation similar to Creature.Name but max length 15
    public string Description
    {
        get => _description;
        init
        {
            _description = NormalizeDescription(value, 15);
        }
    }

    // Size with default value
    public int Size { get; set; } = 3;

    // Constructors
    public Animals()
    {
        _description = "Unknown";
    }

    public Animals(string description, int size = 3)
    {
        Description = description;
        Size = size;
    }

    // Info property, e.g. "Dogs <3>"
    public string Info => $"{Description} <{Size}>";

    // Helper: similar normalization but maxLen param
    private static string NormalizeDescription(string input, int maxLen)
    {
        if (input == null) input = "Unknown";
        var s = input.Trim();
        if (s.Length == 0) s = "Unknown";

        while (s.Length < 3) s += "#";

        if (s.Length > maxLen) s = s.Substring(0, maxLen);

        if (char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s.Substring(1);

        return s;
    }
}
