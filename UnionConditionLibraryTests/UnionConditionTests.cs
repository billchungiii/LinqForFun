using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnionConditionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLibrary;
using ExpectedObjects;

namespace UnionConditionLibrary.Tests
{
    [TestClass()]
    public class UnionConditionTests
    {

        private IEnumerable<ConditionExpression<(string name, int age, Gender gender), Person>> Create((string name, int age, Gender gender) condition)
        {

            return new List<ConditionExpression<(string name, int age, Gender gender), Person>>
            {                

                 new ConditionExpression<(string name, int age, Gender gender), Person>((x) => !string.IsNullOrWhiteSpace (condition.name),
                                                                              (y) => y.Name.Contains (condition.name )),

                 new ConditionExpression<(string name, int age, Gender gender), Person>((x) => condition.age > 0 ,
                                                                              (y) => y.Age < condition.age),

                 new ConditionExpression<(string name, int age, Gender gender), Person>((x) => condition.gender != Gender.None  ,
                                                                               (y) => y.Gender == condition.gender),


            };



        }

        [TestMethod()]
        public void Give_B_24_Male_When_Excute_Then_Bill()
        {
            var expected = new List<Person> { new Person("Bill", 23, Gender.Male) }.ToExpectedObject();
            var give = ("B", 24, Gender.Male);
            var actual = FakeData.Create().Where((x) => Create(give).NeedExecute(give, x)).ToList();
            expected.ShouldEqual(actual);
           

        }

        [TestMethod()]
        public void Give_i_27_Male_When_Excute_Then_Bill_David()
        {
            var expected = new List<Person>
            {
                new Person("Bill", 23, Gender.Male),
                new Person ("David", 26, Gender.Male)
            }.ToExpectedObject();
            var give = ("i", 27, Gender.Male);
            var actual = FakeData.Create().Where((x) => Create(give).NeedExecute (give, x)).ToList();
            expected.ShouldEqual(actual);
        }
    }
}