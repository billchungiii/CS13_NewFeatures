using System.Runtime.CompilerServices;

namespace ParamsModifierSample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// params collections
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Display("1", "2", "3");
            Display(["1", "2", "3"]); // CS 12.0
            var list = new List<string> { "1", "2", "3" };
            Display(list);
            var array = new string[] { "1", "2", "3" };
            Display(array);
        }

        [OverloadResolutionPriority(2)]
        public static void Display<T>(List<T> args)
        {
            Console.WriteLine($"List<T>");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
       // [OverloadResolutionPriority(-1)]
        public static void Display<T>(params T[] args)
        {
            Console.WriteLine($"params T[]");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        public static void Display<T>(params IEnumerable<T> args)
        {
            Console.WriteLine($"params IEnumerable<T>");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        public static void Display<T>(params Span<T> args)
        {
            Console.WriteLine($"params Span<T>");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        [OverloadResolutionPriority(1)]
        public static void Display<T>(params ReadOnlySpan<T> args)
        {
            Console.WriteLine($"params ReadOnlySpan<T>");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
