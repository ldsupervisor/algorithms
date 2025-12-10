LinkedList<int> linkedList = new LinkedList<int>();

// Add to the end
linkedList.AddLast(10);
linkedList.AddLast(20);
linkedList.AddLast(30);

// Add to the beginning
linkedList.AddFirst(5); 

LinkedListNode<int>? node30 = linkedList.Find(30)!;
linkedList.AddBefore(node30, 25); // Before 30
linkedList.AddAfter(node30, 35);  // After 30

Console.WriteLine("Content of the list");
foreach (int item in linkedList)
{
    Console.WriteLine(item);
}

Console.WriteLine("\nFirst " + linkedList.First!.Value);
Console.WriteLine("Last " + linkedList.Last!.Value);

// Checking if the list contains a concrete value
Console.WriteLine("\nIs list containing 10 " + linkedList.Contains(10));

linkedList.Remove(20); // Delete specific value
linkedList.RemoveFirst();
linkedList.RemoveLast();

Console.WriteLine("\nAfter removal:");
foreach (int item in linkedList)
{
    Console.WriteLine(item);
}
