using DataLibrary;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyImplementLibrary;
using StrategyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyLibrary.Tests
{
    [TestClass()]

    public class ExcutorContextTests
    {
        [TestMethod()]
        public void Give_B_24_Male_When_Excute_Then_Bill()
        {
            var expected = new List<Person> { new Person("Bill", 23, Gender.Male) }.ToExpectedObject();
            var give = ("B", 24, Gender.Male);
            var actual = FakeData.Create().Execute(give, new NameExecutor()).Execute(give, new AgeExecutor()).Execute(give, new GenderExecutor()).ToList();
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
            var actual = FakeData.Create().Execute(give, new NameExecutor()).Execute(give, new AgeExecutor()).Execute(give, new GenderExecutor()).ToList();
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
        public void Give_null_0_None_When_Excute_Then_SameAsSource()
        {
            var expected = FakeData.Create().ToExpectedObject();
            var give = (default(string), 0, Gender.None);
            var actual = FakeData.Create().Execute(give, new NameExecutor()).Execute(give, new AgeExecutor()).Execute(give, new GenderExecutor()).ToList();
            expected.ShouldEqual(actual);
        }

        [TestMethod()]
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
            var give = (default(string), 0, Gender.Female);
            var actual = FakeData.Create().Execute(give, new NameExecutor()).Execute(give, new AgeExecutor()).Execute(give, new GenderExecutor()).ToList();
            expected.ShouldEqual(actual);
        }
    }
}
