using CsvFileProject.Common.Services.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do
            {
                
                    Console.WriteLine("CSV file processing started..");
                    Console.WriteLine("Please enter a valid file path to write values to a csv file..");
                    var filePath = Console.ReadLine();
                    if (string.IsNullOrEmpty(filePath))
                    {
                        Console.WriteLine("The path could not be null or empty!");
                        return;
                    }
            } while (Console.ReadLine()!="");
            
                
            
        }

        private static void WriteValues(string filePath)
        {
            using (var writer = new CsvFileWriterService("WriteTest.csv"))
            {
                // Write each row of data
                for (int row = 0; row < 100; row++)
                {
                    // TODO: Populate column values for this row
                    List<string> columns = new List<string>();
                    writer.WriteRow(columns);
                }
            }
        }

        private static void ReadValues(string filePath)
        {
            List<string> columns = new List<string>();
            using (var reader = new CsvFileReaderService("ReadTest.csv"))
            {
                while (reader.ReadRow(columns))
                {
                    // TODO: Do something with columns' values
                }
            }
        }
    }
}
