using DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectSolutionLibrary
{
    public static class DirectSolution
    {
        public static IEnumerable<Person> Execute(this IEnumerable<Person> source, string name, int age, Gender gender)
        {
            return source.Where((x) =>  
                                        (string.IsNullOrWhiteSpace(name) || x.Name.Contains(name))
                                     && (age < 1 || x.Age < age)
                                     && ((gender == Gender.None) || (x.Gender == gender)));
                                
        }
    }
}
