using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Serialization
{
    public static class CourseWriter
    {
        public static void WriteToScreen(List<Course> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"Number: {course.Number}");
                Console.WriteLine($"Name: {course.Name}");
                Console.WriteLine($"Description: {course.Description}");
            }
        }

        public static void WriteToFile(List<Course> courses, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var course in courses)
                {
                    writer.WriteLine($"{course.Number}\t{course.Name}\t{course.Description}");
                }
            }
        }

        public static void WriteToFileBinary(List<Course> courses, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, courses);
            }
        }

        public static void WriteToFileXml(List<Course> courses, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Course>));
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, courses);
            }
        }

        public static void WriteToFileJson(List<Course> courses, string fileName)
        {
            string json = JsonConvert.SerializeObject(courses);
            File.WriteAllText(fileName, json);
        }
    }
}
