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

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 年龄
        /// </summary>
        public byte Age { get; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
    }
}