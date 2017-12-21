using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.DeviceInfo;

namespace DemoAppcenter
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            ModelID.Text = "Model: " + Plugin.DeviceInfo.CrossDeviceInfo.Current.Model;
            DeviceID.Text = "DeviceID: " + Plugin.DeviceInfo.CrossDeviceInfo.Current.Id;
            PlatformOS.Text = "Platform: " + Plugin.DeviceInfo.CrossDeviceInfo.Current.Platform;
        }

    }

}
