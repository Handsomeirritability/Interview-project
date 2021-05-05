using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Test t = new Test();
            t.dicAll = new Dictionary<int, List<int>>();
            t.ran = new Random();
            t.GetAllData();
            t.GetTakePoker();
            Console.WriteLine(t.result);
        }

    }
}
