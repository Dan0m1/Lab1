namespace Lab1 {
    class Program
    {
        public static void Main(string[] args)
        {
            string path = "/*path to the 'Files' directory*/";

          //  List<string> C1 = Task1(path);

           // Dictionary<string, List<string>> dictionary = Task2(path);

            Console.WriteLine(Task3(path));
        }

        static List<string> Task1(string path)
        {
            List<string> C1 = new List<string>();

            using (StreamReader reader = new StreamReader(path + "Addresses.txt"))
            {
                int i = 0;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    C1.Add(line + ":" + i++);
                }
            }

            //C1 = C1.DistinctBy(p => p.Split(':')[0]).ToList();

            List<string> temp = new List<string>();
            foreach (string line in C1)
            {
                if (!temp.Exists(p => p.Split(':')[0] == line.Split(':')[0]))
                {
                    temp.Add(line);
                }
            }

            return temp;
        }

        static Dictionary<string, List<string>> Task2(string path)
        {
            List<string> list1 = new List<string>();
            using (StreamReader reader = new StreamReader(path + "List1.txt"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    list1.Add(line);
                }
            }

            List<string> list2 = new List<string>();
            using (StreamReader reader = new StreamReader(path + "List2.txt"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    list2.Add(line);
                }
            }

            if (list1.Count() != list2.Count())
            {
                Console.WriteLine("Files \"List1.txt\" and \"List2.txt\" don't meet the requirements: amount of elements in each file must be the same!");
            }

            Dictionary<string, List<string>> dict =  new Dictionary<string, List<string>>();

            foreach (string line in list1)
            {
                if (!dict.ContainsKey(line))
                {
                    dict.Add(line, list2);
                }
            }
            return dict;
        }

        static int Task3(string path)
        {
            
            List<int> sequence = new List<int>();
            int temp = -1;
            using (StreamReader reader = new StreamReader(path + "Sequence.txt"))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(int.TryParse(line, out temp)){
                        sequence.Add(temp);
                    }
                }
            }
            

            // string[] sequence = File.ReadAllLines(path + "Sequence.txt");

            try
            {
                return sequence.Where(p => p > 0).Min();
            }
            catch
            {
                return 0;
            }

        }
    }
}