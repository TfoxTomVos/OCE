using System;
using OCE;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
           EventManager.initTest();
           EventManager.callEvent(new TestEvent("Test"));

           Console.ReadKey();

        }
    }
}