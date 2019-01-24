namespace GroupListViewDemo.Models
{
    public class Person
    {
        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public byte Age { get; }
    }
}