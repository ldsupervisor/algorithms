
RecordExample.Run();
record Person(string Name, int Age); // Record with the named properties

class RecordExample
{
    public static void Run()
    {
        var person1 = new Person("Alice", 30);
        var person2 = new Person("Alice", 30);
        var person3 = person1 with { Age = 31 }; // Copy with modification

        Console.WriteLine($"Person1: {person1}");
        Console.WriteLine($"Person2: {person2}");
        Console.WriteLine($"Person3 (copy): {person3}");

        Console.WriteLine("Czy person1 == person2? " + (person1 == person2)); // True
    }
}
