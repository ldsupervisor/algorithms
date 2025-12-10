Dictionary<int, string> numberNames = new Dictionary<int, string>();
numberNames.Add(1, "One"); //adding a key/value using the Add() method
numberNames.Add(2, "Two");
numberNames.Add(3, "Three");

// The following throws run-time exception: key already added.
// numberNames.Add(3, "Three"); 

foreach (KeyValuePair<int, string> kvp in numberNames)
    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

// Creating a dictionary using collection-initializer syntax
var cities = new Dictionary<string, string>(){
    {"UK", "London, Manchester, Birmingham"},
    {"USA", "Chicago, New York, Washington"},
    {"India", "Mumbai, New Delhi, Pune"}
};


foreach (var kvp in cities)
    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);

string text = "hello world hello";
Dictionary<string, int> counter = new Dictionary<string, int>();

foreach (var word in text.Split(' '))
{
    if (counter.ContainsKey(word))
    {
        counter[word]++;
    }
    else
    {
        counter.Add(word, 1);
    }
}

foreach (var pair in counter)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}