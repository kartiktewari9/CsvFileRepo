using System;

namespace CsvTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing of csv service started..");

            TestHarness testHarness = new TestHarness();
            testHarness.RunTests();

            Console.WriteLine("All test cases passed successfully..");
            Console.WriteLine("Testing of csv service end..");
            Console.ReadKey();
        }
    }
}
