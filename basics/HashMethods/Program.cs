using System.Collections.Concurrent;
using System.Collections.Immutable;

DictionaryExample.Run();
HashSetExample.Run();
Run();
ImmutableExample.Run();

static void Run()
{

    var dict = new ConcurrentDictionary<string, int>();

    dict.TryAdd("apple", 10);
    dict.TryAdd("banana", 20);

    // Update the value for "banana" or add it if it doesn't exist
    dict.AddOrUpdate("banana", 1, (key, oldValue) => oldValue + 5);

    Console.WriteLine("banana: " + dict["banana"]);

}

class DictionaryExample
{
    public static void Run()
    {
        Dictionary<string, int> hashTable = new Dictionary<string, int>();

        // Adding key-value pairs
        hashTable["apple"] = 10;
        hashTable["banana"] = 20;
        hashTable["orange"] = 30;

        // Accessing a value by key
        Console.WriteLine("Value associated with 'apple': " + hashTable["apple"]);

        // Iterating through the dictionary
        foreach (var pair in hashTable)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

    }
}


class HashSetExample
{
    public static void Run()
    {
        HashSet<string> fruits = new HashSet<string>();

        fruits.Add("apple");
        fruits.Add("banana");
        fruits.Add("orange");
        fruits.Add("apple"); // duplicate - will be ingored

        Console.WriteLine("Content of set");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        Console.WriteLine("\nDoes set contains 'banana'? " + fruits.Contains("banana"));

    }
}


class ImmutableExample
{
    public static void Run()
    {

        var dict = ImmutableDictionary.Create<string, int>()
            .Add("apple", 10)
            .Add("banana", 20);

        var newDict = dict.SetItem("banana", 25); // Create a new dictionary with updated value

        Console.WriteLine("banana in original: " + dict["banana"]); // 20
        Console.WriteLine("banana in new: " + newDict["banana"]);   // 25
    }
}