/*
* Sami Alzoubi
* CPSC 23000
* March 4th, 2024
* Serialization
* This was kind of hard, asked my dad for help.
*/



using System;
using System.Collections.Generic;
using System.IO;


namespace Serialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("           COURSE MANAGEMENT TOOL");
            Console.WriteLine("*********************************************");
            Console.WriteLine();

            List<Course> courses = new List<Course>();

            // Prompt user for their first name
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine();

            // Prompt user for the number of courses they will enter
            Console.WriteLine("How many courses will you enter?");
            int numCourses = int.Parse(Console.ReadLine());

            // Input courses from the user
            for (int i = 0; i < numCourses; i++)
            {
                Console.WriteLine($"Enter course number {i + 1}:");
                string number = Console.ReadLine();

                Console.WriteLine($"Enter course title {i + 1}:");
                string title = Console.ReadLine();

                Console.WriteLine($"Enter course description {i + 1}:");
                string description = Console.ReadLine();

                courses.Add(new Course(number, title, description));
            }

            // Print entered courses to the screen
            Console.WriteLine("These are the courses you entered:");
            CourseWriter.WriteToScreen(courses);

            // ask user to enter directory to save the courses
            Console.WriteLine("Enter directory to save the courses to:");
            string directory = Console.ReadLine();

            // Serialization process
            string fileNameText = Path.Combine(directory, $"{firstName}.txt");
            string fileNameBinary = Path.Combine(directory, $"{firstName}.bin");
            string fileNameXml = Path.Combine(directory, $"{firstName}.xml");
            string fileNameJson = Path.Combine(directory, $"{firstName}.json");

            CourseWriter.WriteToFile(courses, fileNameText);
            CourseWriter.WriteToFileBinary(courses, fileNameBinary);
            CourseWriter.WriteToFileXml(courses, fileNameXml);
            CourseWriter.WriteToFileJson(courses, fileNameJson);

            // Read and print courses from each file
            Console.WriteLine("I will now read these files back into four separate lists to prove they were serialized correctly.");
            Console.WriteLine("From the text file:");
            CourseReader.ReadAndPrintFromFile(fileNameText);

            Console.WriteLine("From the binary file:");
            CourseReader.ReadAndPrintFromFile(fileNameBinary);

            Console.WriteLine("From the XML file:");
            CourseReader.ReadAndPrintFromFile(fileNameXml);

            Console.WriteLine("From the JSON file:");
            CourseReader.ReadAndPrintFromFile(fileNameJson);

            Console.WriteLine("Thank you for using this program!");
        }
    }
}
