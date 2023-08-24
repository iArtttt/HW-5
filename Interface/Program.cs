using Interface.MyCollection;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WatchList<int> ints = new WatchList<int>();

            MyPriorityQueue<int> priorityQueue = new();
            priorityQueue.Enqueue(7);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(6);
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(9);
            priorityQueue.Enqueue(1);
            priorityQueue.Enqueue(8);
            priorityQueue.Enqueue(4);
            var djk = priorityQueue.Filter(n => n > 5).ToArray();
            List<Winner> winnerList = new()
            {
                new Winner() { Country = "Argentina", Years = new[] { 1978, 1986, 2022 } },
                new Winner() { Country = "England  ", Years = new[] { 1966 } },
                new Winner() { Country = "Germany  ", Years = new[] { 1954, 1974, 1990, 2014 } },
            };
            
            var mkk = winnerList.SelectToMany(w => w.Years).ToList();


            MyList<Person> people = new MyList<Person>()
            {
                new Person() { Name = "Tom", LastName = "Lenon", Age = 37 },
                 new Person() { Name = "Bob", LastName = "Harly", Age = 12 },
                 new Person() { Name = "Lofy", LastName = "Libovskiy", Age = 42 },
                 new Person() { Name = "Dog", LastName = "Hoi", Age = 11 },
                 new Person() { Name = "Artur", LastName = "Svech", Age = 3 },
                 new Person() { Name = "Vet", LastName = "Nemirov", Age = 64 },
                 new Person() { Name = "Nik", LastName = "Shushu", Age = 43 },
                 new Person() { Name = "Tom", LastName = "Holand", Age = 25 },
            };


            WatchList<int> myList = new WatchList<int>();
            myList.Add(7);
            myList.Add(17);
            myList.Add(6);
            myList.Add(8);
            myList.Add(14);
            myList.Add(1);
            myList.Add(2);
            myList.Add(12);
            myList.Add(13);
            myList.Add(15);
            myList.Add(11);
            myList.Add(16);
            myList.Add(18);
            myList.Add(4);
            myList.Add(5);
            myList.Add(9);
            myList.Add(10);
            myList.Add(19);
            myList.Add(20);
            myList.Add(3);
            myList.Add(0);
            myList.Add(1);

            var dgr = myList.Any(m => m == 0);
            //myList.Sort();
            //var sdf = myList.BinarySearch(3);
            List<int> list = new List<int>();

            var kf = myList.Last(s => s != 0); 
            var isAll = myList.All(s => s != 0);
            var isAny = myList.Any(s => s > 0);
            //.First();
            //.TakeWhile(s=> s < 5);
            //.Take(6);
            //.SkipWhile(s => s < 16);
            //.Filter(s => s > 3 && s < 16);

            MyList<string> values = new()
            {
                "c",
                "e",
                "h",
                "f",
                "g",
                "b",
                "d",
                "a",
                "i"
            };
            var v = values.BinarySearch("b");
            var x = values.FirstOrDefault(s => s == "f");
                //.TakeWhile(s => s != "g");

            Console.WriteLine("My List");
            //foreach (var item in kf)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine();
            Console.WriteLine("My List 2");
            foreach (var item in x) 
            {
                Console.WriteLine(item); 
            }

        }
        class Person : IComparable<Person>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            public int CompareTo(Person? other)
            {
                return Age - other.Age;
            }
        }
        public class Winner
        {
            public required string Country { get; set; }
            public required int[] Years { get; set; }
        }
        //public class Comp : IComparable<T>
    }
}