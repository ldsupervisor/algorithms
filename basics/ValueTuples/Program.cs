// Tuple creation with two elements
(string name, int age) person = ("Alice", 30);

// Accessing tuple elements by name
Console.WriteLine($"Name: {person.name}, Age: {person.age}");

// Accessing using default names
var unnamedTuple = ("Bob", 25);
Console.WriteLine($"Item1: {unnamedTuple.Item1}, Item2: {unnamedTuple.Item2}");

// Returning multiple values from a method
var result = GetDimensions();
Console.WriteLine($"Width: {result.width}, Height: {result.height}");

// Destructuring a tuple
var (x, y) = GetCoordinates();
Console.WriteLine($"X: {x}, Y: {y}");


static (int width, int height) GetDimensions()
{
    return (1920, 1080);
}

static (double x, double y) GetCoordinates()
{
    return (12.5, 33.7);
}

