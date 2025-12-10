// Create a regular list
List<int> list = new List<int>();
// Adding elements
list.Add(10);
list.Add(20);
list.Add(30);

list.Insert(0, 5);    // Add to the beginning
list.Insert(3, 25);   // Insert 25 before the element at index 3 (which is 30)
list.Insert(5, 35);   // Insert 35 after 30 (now 35 has index 5)

// Print the content of the list
Console.WriteLine("Content of the list:");
foreach (int item in list)
{
    Console.WriteLine(item);
}

// Get the index of specific elements
int index10 = list.IndexOf(10);
int index30 = list.IndexOf(30);
int index99 = list.IndexOf(99); // Element not present, returns -1

Console.WriteLine($"\nIndex of 10: {index10}");
Console.WriteLine($"Index of 30: {index30}");
Console.WriteLine($"Index of 99: {index99}"); // Element not present, returns -1

// Remove elements
list.Remove(20);      // Remove the value 20
list.RemoveAt(0);     // Remove the first element
list.RemoveAt(list.Count - 1); // Remove the last element

// Print the list after removal
Console.WriteLine("\nAfter removal:");
foreach (int item in list)
{
    Console.WriteLine(item);
}

