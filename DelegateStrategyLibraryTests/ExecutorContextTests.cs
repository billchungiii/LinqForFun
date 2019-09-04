using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegateStrategyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using ExpectedObjects;

namespace DelegateStrategyLibrary.Tests
{
    [TestClass()]
    public class ExecutorContextTests
    {
        [TestMethod()]
        public void Give_B_24_Male_When_Execute_Then_Bill()
        {
            var expected = new List<Person> { new Person("Bill", 23, Gender.Male) }.ToExpectedObject();
            var give = (name:"B", age:24, gender:Gender.Male);
            var actual = FakeData.Create().Execute((x) => !string.IsNullOrWhiteSpace(x.name), (x, y) => x.Name.Contains(y.name), give)
                                          .Execute((x) => x.age > 0, (x, y) => x.Age < y.age , give)
                                          .Execute((x) => x.gender != Gender.None , (x, y) => x.Gender == y.gender  , give)
                                          .ToList();
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        public void Give_i_27_Male_When_Execute_Then_Bill_David()
        {
            var expected = new List<Person>
            {
                new Person("Bill", 23, Gender.Male),
                new Person ("David", 26, Gender.Male)
            }.ToExpectedObject();

            var give = (name:"i", age:27, gender:Gender.Male);
            var actual = FakeData.Create().Execute((x) => !string.IsNullOrWhiteSpace(x.name), (x, y) => x.Name.Contains(y.name), give)
                                          .Execute((x) => x.age > 0, (x, y) => x.Age < y.age, give)
                                          .Execute((x) => x.gender != Gender.None, (x, y) => x.Gender == y.gender, give)
                                          .ToList();
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        public void Give_null_0_None_When_Excute_Then_SameAsSource()
        {
            var expected = FakeData.Create().ToExpectedObject();
            var give = (name:default(string), age:0, gender:Gender.None);
            var actual = FakeData.Create().Execute((x) => !string.IsNullOrWhiteSpace(x.name), (x, y) => x.Name.Contains(y.name), give)
                                          .Execute((x) => x.age > 0, (x, y) => x.Age < y.age, give)
                                          .Execute((x) => x.gender != Gender.None, (x, y) => x.Gender == y.gender, give)
                                          .ToList();
            expected.ShouldEqual(actual);
        }

        [TestMethod ()]
        public void Give_null_0_Female_When_Excute_Then_Mary_Jane_Winnie_Lucy_Nico()
        {
            var expected = new List<Person>
            {
                new Person ("Mary", 23, Gender.Female ),
                 new Person ("Jane", 24, Gender.Female),
                 new Person ("Winnie", 25, Gender.Female ),
                 new Person ("Lucy", 26, Gender.Female ),
                 new Person ("Nico", 23, Gender.Female),

            }.ToExpectedObject();
            var give = (name:default(string), age:0, gender:Gender.Female);
            var actual = FakeData.Create().Execute((x) => !string.IsNullOrWhiteSpace(x.name), (x, y) => x.Name.Contains(y.name), give)
                                         .Execute((x) => x.age > 0, (x, y) => x.Age < y.age, give)
                                         .Execute((x) => x.gender != Gender.None, (x, y) => x.Gender == y.gender, give)
                                         .ToList();
            expected.ShouldEqual(actual);
        }
    }
}