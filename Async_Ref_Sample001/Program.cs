namespace Async_Ref_Sample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// ref in async method
    /// </summary>
    internal class Program
    {
        static int[] storage = new int[10] {21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        async static Task Main(string[] args)
        {
            await Task.Delay(100);
            ref int source = ref GetValue();
            source *= 2;
            Console.WriteLine(storage[0]);
        }
        static ref int GetValue()
        {            
            return ref storage[0];
        }
    }
}
