using BaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodLibrary
{
    class NameExecutor : ExecutorTemplate<Person, (string name, int age, Gender gender)>
    {
        protected override bool ExecutePostcondition(Person value, (string name, int age, Gender gender) condition)
        {
            return value.Name.Contains(condition.name);
        }

        protected override bool ExecutePrecondition((string name, int age, Gender gender) condition)
        {
            return !string.IsNullOrWhiteSpace(condition.name);
        }
    }

    class AgeEXecutor : ExecutorTemplate<Person, (string name, int age, Gender gender)>
    {
        protected override bool ExecutePostcondition(Person value, (string name, int age, Gender gender) condition)
        {
            return value.Age < condition.age; 
        }

        protected override bool ExecutePrecondition((string name, int age, Gender gender) condition)
        {
            return condition.age > 0;
        }
    }

    class GenderExecutor : ExecutorTemplate<Person, (string name, int age, Gender gender)>
    {
        protected override bool ExecutePostcondition(Person value, (string name, int age, Gender gender) condition)
        {
            return value.Gender == condition.gender;
        }

        protected override bool ExecutePrecondition((string name, int age, Gender gender) condition)
        {
            return condition.gender != Gender.None;
        }
    }

    public static  class ExcutorContext
    {
        public static IEnumerable<Person> Execute(this IEnumerable <Person > source, (string name, int age, Gender gender) condition)
        {
           return new GenderExecutor().Execute(new AgeEXecutor().Execute(new NameExecutor().Execute(source, condition), condition), condition); 
        }
    }
}
