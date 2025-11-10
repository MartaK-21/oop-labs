using System;

class Program
{
    static void Main()
    {
        TestCreatures();
        Console.WriteLine();
        TestDirections();

        Console.WriteLine("\nDone. Press any key to exit...");
        Console.ReadKey();
    }

    static void TestCreatures()
    {
        Console.WriteLine("=== TestCreatures ===");

        // default ctor
        var c1 = new Creature();
        c1.SayHi();
        Console.WriteLine("Info: " + c1.Info);
        // Try to change name/level after initialization (should be ignored)
        c1.Name = "NewName";   // ignored
        c1.Level = 9;         // ignored
        Console.WriteLine("After attempt to change (should be same): " + c1.Info);

        // ctor with lowercase name and short name and invalid level
        var c2 = new Creature("sh", -5); // name <3 -> padded, level -5 -> set to 1
        c2.SayHi();
        Console.WriteLine("Info: " + c2.Info);

        // long name
        var longName = "thisnameisdefinitelywaytoolongtobeaccepted";
        var c3 = new Creature(longName, 15); // level >10 -> set to 10
        c3.SayHi();
        Console.WriteLine("Info: " + c3.Info);

        // Upgrade should increase level up to 10
        var hero = new Creature("hero", 9);
        Console.WriteLine("Hero before upgrade: " + hero.Info);
        hero.Upgrade();
        Console.WriteLine("Hero after upgrade: " + hero.Info);
        hero.Upgrade();
        Console.WriteLine("Hero after second upgrade (max10): " + hero.Info);

        // Animals tests
        var a1 = new Animals("dogs", 3);
        Console.WriteLine("Animals Info: " + a1.Info);

        var a2 = new Animals(" x ", 5);
        Console.WriteLine("Animals Info (trim/pad): " + a2.Info);

        var a3 = new Animals("averylongdescriptionthatexceeds", 2);
        Console.WriteLine("Animals Info (trimmed to 15): " + a3.Info);
    }

    static void TestDirections()
    {
        Console.WriteLine("=== TestDirections ===");

        var c = new Creature("Shrek", 3);

        Console.WriteLine("-- Single Go --");
        c.Go(Direction.Left); // "Shrek goes left"

        Console.WriteLine("-- Array Go --");
        c.Go(new Direction[] { Direction.Up, Direction.Right, Direction.Down });

        Console.WriteLine("-- Parse and Go --");
        var parsed = DirectionParser.Parse("URDLXYZr");
        Console.WriteLine("Parsed directions:");
        foreach (var d in parsed)
            Console.WriteLine(d);

        Console.WriteLine("-- Go from string --");
        c.Go("UrrdLx"); // should do U R R D L (ignore x)
    }
}