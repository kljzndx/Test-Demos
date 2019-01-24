namespace GroupListViewDemo.Models
{
    public class Person
    {
        public Person(string name, byte age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }

        public string Name { get; }
        public byte Age { get; }
        public string Position { get; set; }
    }
}