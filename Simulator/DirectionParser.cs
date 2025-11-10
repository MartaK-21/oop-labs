using System;
using System.Collections.Generic;

public static class DirectionParser
{
    // Parse: map letters U R D L (case-insensitive) to Directions
    public static Direction[] Parse(string s)
    {
        if (string.IsNullOrEmpty(s)) return Array.Empty<Direction>();

        var list = new List<Direction>();
        foreach (char c in s)
        {
            switch (char.ToUpperInvariant(c))
            {
                case 'U': list.Add(Direction.Up); break;
                case 'R': list.Add(Direction.Right); break;
                case 'D': list.Add(Direction.Down); break;
                case 'L': list.Add(Direction.Left); break;
                default:
                    // ignore other chars
                    break;
            }
        }
        return list.ToArray();
    }
}
