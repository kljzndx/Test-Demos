using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Media;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace BlurBackgroundTest
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Brush _blurBrush;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 3))
            {
                _blurBrush = new BackdropBlurBrush();

                Blur_Rectangle.Fill = _blurBrush;
            }
        }

        private void BlurDegree_Slider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (_blurBrush is null)
                return;

            var brush = (BackdropBlurBrush) _blurBrush;
            brush.Amount = e.NewValue;
        }
    }
}
