using System.Buffers;
using System.Runtime.InteropServices;

namespace AllowRefStructSample001
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// ref struct implements interfaces and allows ref struct 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // 許願
            // Comparer<RefStruct>.Default.Compare(new RefStruct(), new RefStruct());
            // EqualityComparer<RefStruct>.Default.Equals(new RefStruct(), new RefStruct());
            // 現有的泛型介面或泛型類別, 其泛型參數支援 ref struct 還不多 , 目前已知 IEnumerable<T>, Action , Func 支援 ref struct

            int value = 9;
            RefStruct source = new RefStruct(ref value);
            source.Number += 10;
            Console.WriteLine(source.Number);
            RefStruct target = new RefStruct(ref value);
            Console.WriteLine(target.Equals(source));
            int otherValue = 99999;
            RefStruct other = new RefStruct(ref otherValue);
            Console.WriteLine(other.IsBigger(source));
            
          
            Func<RefStruct, int> func = (source) => source.Number;
            Action<RefStruct> action = (source) => Console.WriteLine($"action {source.Number}");
            Console.WriteLine($"func {func(source)}");
            action(source);
        }
    }

    public ref struct RefStruct : IComparable<RefStruct>, IEquatable<RefStruct>
    {
        private ref int _number;

        public RefStruct(ref int number)
        {
            _number = ref number;
        }
        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public int CompareTo(RefStruct other)
        {
            return _number.CompareTo(other._number);
        }

        public bool Equals(RefStruct other)
        {
            return _number.Equals(other._number);
        }
    }
   

    public static class CompareExtension
    {
        public static bool IsBigger<T>(this T source , T other) where T : IComparable<T>, allows ref struct
        {
            return source.CompareTo(other) > 0;
        }
    }

   
}
