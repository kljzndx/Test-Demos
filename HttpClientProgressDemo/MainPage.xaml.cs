using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace HttpClientProgressDemo
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly HttpClient _http = new HttpClient();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void StartDownload_Button_OnClick(object sender, RoutedEventArgs e)
        {
            Download_ProgressBar.Value = 0;
            if (!String.IsNullOrWhiteSpace(Url_TextBox.Text))
                await _http.GetAsync(new Uri(Url_TextBox.Text)).AsTask(new Progress<HttpProgress>(Http_Progress));
            Download_ProgressBar.Value = 100;
        }

        private void Http_Progress(HttpProgress obj)
        {
            Received_Run.Text = obj.BytesReceived.ToString();
            if (obj.TotalBytesToReceive.HasValue)
            {
                ReceiveTotal_Run.Text = obj.TotalBytesToReceive.ToString();
                double d = obj.BytesReceived * 100D / obj.TotalBytesToReceive.Value;
                
                Download_ProgressBar.Value = d;
            }
        }
    }
}
