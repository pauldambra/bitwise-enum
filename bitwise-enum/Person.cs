using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitwise_enum
{
    public class Person
    {
        public Person() {}

        public Person(PeopleTypes personType)
        {
            PersonType = personType;
        }

        public PeopleTypes PersonType { get; set; }
    }
}
