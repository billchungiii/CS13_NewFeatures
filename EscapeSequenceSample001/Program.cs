namespace EscapeSequenceSample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// Escape sequence
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // 以前你要這樣寫
            Console.WriteLine("\u001b[1;33mThis is a bold yellow text\u001b[0m");

            // 現在你可以這樣寫
            Console.WriteLine("\e[1;33mThis is a bold yellow text\e[0m");
        }
    }
}
