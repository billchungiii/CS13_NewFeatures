namespace LinqSamples
{
    /// <summary>
    /// .NET 9.0
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = GetPersons();
            #region CountBy
            // 以前你會這樣寫
            var oldCountByCity = persons.GroupBy(p => p.City)
                                     .Select(g => new { City = g.Key, Count = g.Count() });
            var oldCountResult = string.Join(", ", oldCountByCity.Select(c => $"{c.City} has {c.Count} persons"));

            // 現在可以這樣寫
            var newCountByCity = persons.CountBy(p => p.City);
            var newCountResult = string.Join(", ", newCountByCity.Select(c => $"{c.Key} has {c.Value} persons"));

            Console.WriteLine($"old: {oldCountResult}{Environment.NewLine}new: {newCountResult}");
            #endregion CountBy
            Console.WriteLine("==========================");
            #region AgrerateBy
            // 以前你會這樣寫
            var oldAggregateByCity = persons.GroupBy(p => p.City)
                                     .Select(g => new { City = g.Key, Age = g.Sum(p => p.Age) });
            var oldAggregateResult = string.Join(", ", oldAggregateByCity.Select(c => $"{c.City} has {c.Age} years old in total"));

            // 現在可以這樣寫
            var newAggregateByCity = persons.AggregateBy(p => p.City, 0, (acc, p) => acc + p.Age);
            var newAggregateResult = string.Join(", ", newAggregateByCity.Select(c => $"{c.Key} has {c.Value} years old in total"));
            Console.WriteLine($"old: {oldAggregateResult}{Environment.NewLine}new: {newAggregateResult}");
            #endregion AgrerateBy
            Console.WriteLine("==========================");
            #region Index
            // 以前你會這樣寫
            var oldIndex = persons.Select((p, index) => (p, index));
            foreach (var item in oldIndex)
            {
                Console.WriteLine($"{item.p.Name} is at index {item.index}");
            }
            Console.WriteLine("**************");
            // 現在可以這樣寫
            var newIndex = persons.Index();
            foreach (var item in newIndex)
            {
                Console.WriteLine($"{item.Item.Name} is at index {item.Index}");
            }
            #endregion Index

        }

        static List<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person { Name = "Bill", City = "Seattle" , Age = 18},
                new Person { Name = "Mark", City = "Taipei" , Age= 21},
                new Person { Name = "Steve", City = "New York" , Age= 32},
                new Person { Name = "James", City = "Taipei", Age= 16 },
                new Person { Name = "John", City = "Seattle", Age= 52 },
                new Person { Name = "Tom", City = "Taipei" , Age=37},
                new Person { Name = "David", City = "New York" , Age= 26},
                new Person { Name = "Peter", City = "Seattle", Age = 23 },
                new Person { Name = "Paul", City = "Taipei" , Age=45},
                new Person { Name = "Mary", City = "New York", Age= 38 }
            };
        }
    }


    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }

        public int Age { get; set; }
    }
}
