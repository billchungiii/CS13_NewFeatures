namespace Async_Ref_Sample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// ref in async / iterator method
    /// </summary>
    internal class Program
    {
        static int[] numbers = new int[10] {21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        async static Task Main(string[] args)
        {
            await Task.Delay(100);
            ref int source = ref GetValue();
            source *= 2;
            Console.WriteLine(numbers[0]);            
            Console.WriteLine(string.Join(",", GetNumbers()));
        }
        static ref int GetValue()
        {            
            return ref numbers[0];
        }

        static IEnumerable<int> GetNumbers()
        {
            ref int x = ref numbers[0];
            yield return x;
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
