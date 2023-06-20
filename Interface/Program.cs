namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            var kf = myList.FirstOrDefault(); 
            //.First();
            //.TakeWhile(s=> s < 5);
            //.Take(6);
            //.SkipWhile(s => s < 16);
            //.Filter(s => s > 3 && s < 16);

            MyList<string> values = new();
            values.Add("a");
            values.Add("b");
            values.Add("c");
            values.Add("d");
            values.Add("e");
            values.Add("f");
            values.Add("g");
            values.Add("h");
            values.Add("i");

            var x = values.FirstOrDefault();
                //.TakeWhile(s => s != "g");

            Console.WriteLine("My List");
            foreach (var item in kf)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("My List 2");
            foreach (var item in x) 
            {
                Console.WriteLine(item); 
            }

        }
    }
}