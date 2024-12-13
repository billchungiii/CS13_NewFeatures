namespace PartialPropertySamples
{
    /// <summary>
    /// C# 13.0, .NET 9.0
    /// Partial property
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    public partial class Person
    {
        // 宣告與定義
        public partial string Name { get; set; }
    }

    public partial class Person
    {
        // 實作
        private string _name;
        public partial string Name
        {
            get => _name;
            set =>_name = value;
        }
    }
}
