using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GroupListViewDemo.Models;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace GroupListViewDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<PersonGroup> _source;
        private CollectionViewSource _dataSource;

        public MainPage()
        {
            this.InitializeComponent();
            _source = new List<PersonGroup>();

            List<Person> people = new List<Person>
            {
                new Person("Tom", 22, "Program"),
                new Person("jarry", 22, "Manager"),
                new Person("张三", 22, "Designer"),
                new Person("李四", 22, "Program"),
                new Person("王五", 22, "Designer"),
                new Person("Tim", 22, "Program"),
                new Person("Tom", 22, "Manager"),
                new Person("Tom", 22, "Program"),
                new Person("Tom", 22, "Program"),
                new Person("Tom", 22, "Manager"),
                new Person("Tom", 22, "Designer"),
                new Person("Tom", 22, "Program"),
                new Person("Tom", 22, "Designer"),
            };

            // 分组过程
            {
                Dictionary<string, List<Person>> allGroups = new Dictionary<string, List<Person>>();
                foreach (var person in people)
                {
                    if (!allGroups.ContainsKey(person.Position))
                        allGroups[person.Position] = new List<Person>();

                    allGroups[person.Position].Add(person);
                }

                foreach (var group in allGroups)
                    _source.Add(new PersonGroup(group.Key, group.Value));
            }

            _dataSource = new CollectionViewSource
            {
                IsSourceGrouped = true,
                ItemsPath = new PropertyPath("People")
            };

            _dataSource.SetValue(CollectionViewSource.SourceProperty, new Binding {Source = _source});
        }
    }
}
