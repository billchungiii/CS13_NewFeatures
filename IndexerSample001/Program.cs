namespace IndexerSample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// indexers
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyClass()
            {
                Number =
                {
                    [0] = 99,
                    [^1] = 100
                }
            };
            Console.WriteLine(string.Join(", ", obj.Number));
        }
    }

    public class MyClass
    {
        public int[] Number { get; }
        public MyClass()
        {
            Number = new int[10];
        }
    }
}
