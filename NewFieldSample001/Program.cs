using System.ComponentModel;

namespace NewFieldSample001
{
    /// <summary>
    /// C# preview , .NET 9.0
    /// filed keyword
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.PropertyChanged += Person_PropertyChanged;
            person.Age = 100;
        }

        private static void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           Console.WriteLine($"{e.PropertyName} changed");
        }
    }

    public class Person : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /* 以前你要這樣寫 */
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /* 現在你可以這樣寫 */
        public int Age
        {
            get;
            set
            {
                if (field != value)
                {
                    field = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

    }
}
