namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<Person> people1 = new MyList<Person>();
            {
                new Person() { Name = "Tom", LastName = "Lenon", Age = 37 };
                new Person() { Name = "Bob", LastName = "Harly", Age = 12 };
                new Person() { Name = "Loy", LastName = "Libovskiy", Age = 42 };
                new Person() { Name = "Dog", LastName = "Hoi", Age = 11 };
                new Person() { Name = "Artur", LastName = "Svech", Age = 3 };
                new Person() { Name = "Vet", LastName = "Nemirov", Age = 64 };
                new Person() { Name = "Nik", LastName = "Shushu", Age = 43 };
                new Person() { Name = "Tom", LastName = "Holand", Age = 25 };

            }

            var g = people1.Select(p => p.Name).ToList();



            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            myList.Add(7);
            myList.Add(8);
            myList.Add(9);
            myList.Add(10);
            myList.Add(11);
            myList.Add(12);
            myList.Add(13);
            myList.Add(14);
            myList.Add(15);
            myList.Add(16);
            myList.Add(17);
            myList.Add(18);
            myList.Add(19);
            myList.Add(20);
            myList.Add(0);
            myList.Add(1);
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
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i"
            };

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
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

        }
    }
}