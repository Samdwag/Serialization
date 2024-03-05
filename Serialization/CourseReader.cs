using System;
using System.IO;

namespace Serialization
{
    public static class CourseReader
    {
        public static void ReadAndPrintFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
