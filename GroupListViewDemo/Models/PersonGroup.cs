using System.Collections.Generic;
using System.Linq;

namespace GroupListViewDemo.Models
{
    public class PersonGroup
    {
        public PersonGroup(string name, IEnumerable<Person> people)
        {
            Name = name;
            People = people.ToList();
        }

        public string Name { get; }
        public List<Person> People { get; }
    }
}