using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazy_evaluate
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            //Lottery1();
            //Lottery2();
            //LazyArgument();
            //LazyTest();
            AndOr();

            Console.ReadLine();
        }

        #region LINQ
        static void Lottery1()
        {
            Console.WriteLine("\t로또 1");
            Console.WriteLine("Enumerable.Range(1, 45)를 Take(6)합니다.");
            int i = 0;
            var r = Enumerable.Range(1, 45).OrderBy(o => { i++; return rand.Next(); });
            Console.WriteLine("Take를 하기 전 i의 값 : {0}", i);
            var k = r.Take(6);
            Console.WriteLine(string.Join(", ", k));
            Console.WriteLine("Take를 한 후 i의 값 : {0}", i);
        }

        static void Lottery2()
        { 
            Console.WriteLine("\n\t로또 2");
            Console.WriteLine("Enumerable.Range(1, 6)를 Select(random)합니다.");
            int i = 0;
            var r = Enumerable.Range(1, 6).Select(o => { i++; return rand.Next(46); });
            Console.WriteLine("ToList()를 하기 전 i의 값 : {0}", i);
            var r2 = r.ToList();
            Console.WriteLine("ToList()를 한 후 i의 값 : {0}", i);
            Console.WriteLine(string.Join(", ", r2));
        }
        #endregion

        #region InfiniteArgument
        /// <summary>
        /// https://blogs.msdn.microsoft.com/pedram/2007/06/02/lazy-evaluation-in-c/ 참조
        /// </summary>
        static void LazyArgument()
        {
            Console.WriteLine("\n\tHundred(Infinity()) 를 호출합니다.");
            try
            {
                //만약 Infinity가 아닌 infinityLiteral()을 매개변수로 넘겼다면 SOf가 떴을거임
                Console.WriteLine(Hundred(Infinity()));
            }
            catch(StackOverflowException)
            {
                Console.WriteLine("스택오버플로우");
            }
        }

        static int Hundred(IEnumerable<int> useless)
        {
            return 100;
        }

        static IEnumerable<int> Infinity()
        {
            yield return infinityLiteral();
        }

        static int infinityLiteral() { return infinityLiteral() + 1; }
        #endregion
        
        #region Lazy<>
        class Test {
            int[] array;
            public int Length => array.Length;
            public Test() {
                Console.WriteLine("Test constructor()");
                array = new int[10];
            } }

        /// <summary>
        /// https://www.dotnetperls.com/lazy 참조
        /// </summary>
        static void LazyTest()
        {
            Console.WriteLine("\n\tLazy<test>를 테스트합니다.");
            Lazy<Test> lazy = new Lazy<Test>();
            Console.WriteLine("IsValueCreated : {0}", lazy.IsValueCreated);
            var val = lazy.Value;
            Console.WriteLine("IsValueCreated : {0}", lazy.IsValueCreated);
            Console.WriteLine("Length : {0}", val.Length);
        }
        #endregion

        #region AndOr
        static void AndOr()
        {
            Console.WriteLine("&&, ||를 테스트합니다.");
            int i = 0, j = 0;

            var a = i == 0 || j++ == 1;
            Console.WriteLine("i == 0 || j++ == 1 는 {0}", a);
            Console.WriteLine("j : {0}", j);

            a = i == 0 && j++ == 1;
            Console.WriteLine("i == 0 && j++ == 1 는 {0}", a);
            Console.WriteLine("j : {0}", j);
        }
        #endregion
    }
}
