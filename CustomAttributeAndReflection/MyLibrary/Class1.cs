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
    }
}