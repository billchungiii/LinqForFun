using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using StrategyLibrary;

namespace StrategyImplementLibrary
{
    public class NameExecutor : IExecutor<Person, (string name, int age, Gender gender)>
    {
        public bool ExecutePostcondition(Person source, (string name, int age, Gender gender) condition)
        {
            return source.Name.Contains(condition.name);
        }

        public bool ExeutePrecondition((string name, int age, Gender gender) condition)
        {
            return !string.IsNullOrWhiteSpace(condition.name);
        }
    }


    public class AgeExecutor : IExecutor<Person, (string name, int age, Gender gender)>
    {
        public bool ExecutePostcondition(Person source, (string name, int age, Gender gender) condition)
        {
            return source.Age < condition.age;
        }

        public bool ExeutePrecondition((string name, int age, Gender gender) condition)
        {
            return condition.age > 0;
        }
    }

    public class GenderExecutor : IExecutor<Person, (string name, int age, Gender gender)>
    {
        public bool ExecutePostcondition(Person source, (string name, int age, Gender gender) condition)
        {
            return source.Gender == condition.gender;
        }

        public bool ExeutePrecondition((string name, int age, Gender gender) condition)
        {
            return condition.gender != Gender.None;
        }
    }


}
