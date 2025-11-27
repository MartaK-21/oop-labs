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
namespace Simulator;

public class Animals
{
    private string _description = "";

    public required string Description
    {
        get => _description;
        init => _description = ValidateDescription(value);
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    private static string ValidateDescription(string? raw)
    {
        string baseValue = string.IsNullOrWhiteSpace(raw) ? "Unknown" : raw;

        string s = Validator.Shortener(baseValue, min: 3, max: 15, placeholder: '#');

        if (s.Length > 0 && char.IsLetter(s[0]) && char.IsLower(s[0]))
            s = char.ToUpperInvariant(s[0]) + s[1..];

        return s;
    }
    public override string ToString()
    {
        string typeName = GetType().Name.ToUpperInvariant();
        return $"{typeName}: {Info}";
    }


}