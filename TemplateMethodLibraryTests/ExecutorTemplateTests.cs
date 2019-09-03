using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateMethodLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseLibrary;
using ExpectedObjects;

namespace TemplateMethodLibrary.Tests
{
    [TestClass()]
    public class ExcutorContextTests
    {
        [TestMethod()]
        public void Give_B_24_Male_When_Excute_Then_Bill()
        {
            var expected = new List<Person> { new Person("Bill", 23, Gender.Male) }.ToExpectedObject();
            var give = ("B", 24, Gender.Male);
            var actual = FakeData.Create().Execute( give).ToList();
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
            var actual = FakeData.Create().Execute(give).ToList();
            expected.ShouldEqual(actual);
        }
    }
}