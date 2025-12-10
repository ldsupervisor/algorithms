using System.Text;

using (var obj = new DisposableExample())
{
    obj.WriteText("Hello from MemoryStream!");
}

class DisposableExample : IDisposable
{
    private MemoryStream stream;
    private bool disposed = false;

    public DisposableExample()
    {
        stream = new MemoryStream();
        Console.WriteLine("The new object has been created in memory");
    }

    public void WriteText(string text)
    {
        if (disposed) throw new ObjectDisposedException(nameof(DisposableExample));

        byte[] bytes = Encoding.UTF8.GetBytes(text);
        stream.Write(bytes, 0, bytes.Length);
        Console.WriteLine("The data has been saved to the memory");
    }

    public void Dispose()
    {
        stream.Dispose(); // Dispose the managed resource
        Console.WriteLine("Dispose the (MemoryStream).");
        disposed = true;
    }
}
