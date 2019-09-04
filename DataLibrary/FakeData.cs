using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class FakeData
    {

        public static List<Person> Create()
        {
            return new List<Person>()
            {
                new Person ("Bill", 23, Gender.Male ),
                new Person ("Tom", 24, Gender.Male ),
                new Person ("Jonh", 25, Gender.Male ),
                new Person ("David", 26, Gender.Male ),
                new Person ("Andy", 23, Gender.Male ),

                new Person ("Mary", 23, Gender.Female ),
                new Person ("Jane", 24, Gender.Female),
                new Person ("Winnie", 25, Gender.Female ),
                new Person ("Lucy", 26, Gender.Female ),
                new Person ("Nico", 23, Gender.Female),

            };
        }

    }


}
