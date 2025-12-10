SpanExample.Run();
class SpanExample
{
    public static void Run()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        Span<int> slice = numbers.AsSpan(1, 3); // From index 1, length 3 (20, 30, 40)

        Console.WriteLine("Part of array");
        foreach (var n in slice)
        {
            Console.WriteLine(n);
        }

        // We could modify the original array through the span
        slice[0] = 999;

        Console.WriteLine("Original array after modyfication.");
        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
