using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazy_evaluate
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int i = 0;
            var r = Enumerable.Range(1, 45).OrderBy(o => { i++; return rand.Next(); }).Take(6);
            Console.WriteLine(string.Join(", ", r));
            Console.WriteLine(i);

            i = 0;
            var r2 = Enumerable.Range(1, 6).Select(o => { i++; return rand.Next(46); });
            Console.WriteLine(string.Join(", ", r2));
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
