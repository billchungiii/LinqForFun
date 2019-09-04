using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public enum Gender
    {
        None, Male, Female
    }


    /// <summary>
    /// immmutable
    /// </summary>
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Gender Gender { get; }

        public Person(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

    }
}
