using System;

namespace Serialization
{
    [Serializable]
    public class Course
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Course() { }

        public Course(string number, string name, string description)
        {
            Number = number;
            Name = name;
            Description = description;
        }
    }
}
