using System;

public class Creature
{
    // Backing fields
    private string _name = "Unknown";
    private int _level = 1;

    // Flags to ensure "set only once during initialization"
    private bool _nameSet = false;
    private bool _levelSet = false;

    // Public property Name - can be set only once (during initialization/constructor)
    public string Name
    {
        get => _name;
        set
        {
            if (_nameSet) return; // ignore subsequent sets
            _name = NormalizeName(value, 25); // validation + normalize (max 25)
            _nameSet = true;
        }
    }

    // Public property Level - can be set only once (during initialization/constructor)
    public int Level
    {
        get => _level;
        set
        {
            if (_levelSet) return; // ignore subsequent sets
            _level = NormalizeLevel(value);
            _levelSet = true;
        }
    }

    // Default constructor
    public Creature()
    {
        // set defaults and mark as set
        _name = "Unknown";
        _level = 1;
        _nameSet = true;
        _levelSet = true;
    }

    // Constructor with parameters (level optional)
    public Creature(string name, int level = 1)
    {
        // Use properties so validation is applied and flags set
        Name = name;
        Level = level;
    }

    // SayHi method
    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name} (level {Level}).");
    }

    // Info read-only property
    public string Info => $"{Name} <{Level}>";

    // Upgrade method: increase level by 1 up to max 10
    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
            // Note: upgrading after initialization is allowed even if Level setter is blocked.
        }
    }

    // Go single direction - prints "{Name} goes left" (direction name in lower-case)
    public void Go(Direction dir)
    {
        string dirName = dir.ToString().ToLowerInvariant();
        Console.WriteLine($"{Name} goes {dirName}");
    }

    // Go array of directions
    public void Go(Direction[] dirs)
    {
        if (dirs == null) return;
        foreach (var d in dirs) Go(d);
    }

    // Go from string (uses DirectionParser)
    public void Go(string s)
    {
        var dirs = DirectionParser.Parse(s);
        Go(dirs);
    }

    // --- Helper methods for validation ---

    // Normalize Name: trim, pad to min 3 with '#', maxLen trim, capitalize first letter
    private static string NormalizeName(string input, int maxLen)
    {
        if (input == null) input = "Unknown";

        // trim leading/trailing spaces
        var s = input.Trim();

        // if empty after trim, set to "Unknown"
        if (s.Length == 0) s = "Unknown";

        // ensure min length 3 by appending '#'
        while (s.Length < 3) s += "#";

        // trim to max length
        if (s.Length > maxLen) s = s.Substring(0, maxLen);

        // capitalize first letter if lower-case
        if (char.IsLetter(s[0]) && char.IsLower(s[0]))
        {
            s = char.ToUpperInvariant(s[0]) + s.Substring(1);
        }

        return s;
    }

    // Normalize level to range 1..10
    private static int NormalizeLevel(int lvl)
    {
        if (lvl < 1) return 1;
        if (lvl > 10) return 10;
        return lvl;
    }
}
