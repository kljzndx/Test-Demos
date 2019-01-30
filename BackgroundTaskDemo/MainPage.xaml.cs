using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace BackgroundTaskDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Logger logger = LogManager.GetLogger("main");

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("Start create task");
            var task = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(t => t.Name is App.TaskName);
            if (task != null)
            {
                var dialog = new MessageDialog("Task has been created");
                await dialog.ShowAsync();
                return;
            }

            var builder = new BackgroundTaskBuilder { Name = App.TaskName };
            var b = await BackgroundExecutionManager.RequestAccessAsync();
            if (b == BackgroundAccessStatus.Unspecified || b == BackgroundAccessStatus.DeniedBySystemPolicy || b == BackgroundAccessStatus.DeniedByUser)
            {
                logger.Info("Cannot create task");
                var dialog = new MessageDialog("Cannot create task");
                await dialog.ShowAsync();
                return;
            }
            builder.SetTrigger(new TimeTrigger(30, true));
            builder.Register();
            logger.Info("Task created");
        }

        private async void ViewLog_Button_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchFolderAsync(ApplicationData.Current.TemporaryFolder);
        }
    }
}
