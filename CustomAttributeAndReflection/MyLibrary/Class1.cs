using MyAttribute;

namespace MyLibrary
{
    public class Class1
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1");
        }

        [ExecuteMe(-45)]
        [ExecuteMe(-1)]
        [ExecuteMe(0)]
        [ExecuteMe(1)]
        [ExecuteMe(45)]
        public void M2(int a)
        {
            Console.WriteLine("M2 a = {0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        [ExecuteMe("s1", "s2")]
        [ExecuteMe("kevin", "john")]
        public void M3(string s1, string s2)
        {
            Console.WriteLine("M3 s1 = {0} s2 = {1}", s1, s2);
        }

        [ExecuteMe(false)]
        [ExecuteMe(true)]
        public void M4(bool b)
        {
            Console.WriteLine("M4 {0}",b ? "Bye bye!" : "Hello!");
        }

        [ExecuteMe(typeof(object))]
        public void M5(Type type)
        {
            Console.WriteLine("M5 type = {0}", type.Name);
        }

        [ExecuteMe(new[] {1, 2, 3})]
        public void M6(int[] numbers)
        {
            Console.Write("M6 ");
            foreach (var number in numbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }
    }

    public class Class2
    {
        private int Number { get; }
        public Class2(int number)
        {
            Number = number;
        }

        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine(this.Number);
        }
    }

    public class Class3
    {
        public int Number { get; init; } = 14;

        //public Class3()
        //{
        //    Number = 14;
        //}

        //public Class3(int number)
        //{
        //    Number = number;
        //}

        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine(this.Number);
        }
    }

    public class Class4
    {
        [ExecuteMe("fourteen")]
        public void M1(int a)
        {
            Console.WriteLine("M1 number = {0}", a);
        }

        [ExecuteMe(true, false)]
        public void M2(bool b)
        {
            Console.WriteLine("M2 b = {0}", b);
        }

        [ExecuteMe]
        public void M1024()
        {
            Console.WriteLine("M1024");
        }

        [ExecuteMe("class3_instance")]
        [ExecuteMe("")]
        public void M2048(string objId)
        {
            Class3? c = GetObjectById(objId);
            if (c != null) Console.WriteLine("M2048 c.number = {0}", c.Number);
            else Console.WriteLine("2048 c = null");
        }

        private Class3? GetObjectById(string id)
        {
            return id.Equals("class3_instance") ? new Class3() : null;
        }
    }
}