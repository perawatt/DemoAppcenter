using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.DeviceInfo;
using Newtonsoft.Json;

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

            if (App.Current.Properties.ContainsKey("CurrentUser"))
            {
                this.LoginBlock.IsVisible = false;
                this.LogoutBlock.IsVisible = true;


                var user = App.Current.Properties["CurrentUser"] as string;
                var userObject = JsonConvert.DeserializeObject<UserData>(user);
                this.CurrentUser.Text = userObject.name + " " + userObject.age;
            }
            else
            {
                this.LoginBlock.IsVisible = true;
                this.LogoutBlock.IsVisible = false;

            }

            this.LoginButton.Clicked += LoginButton_Clicked;
            this.LogoutButton.Clicked += LogoutButton_Clicked;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //var user = this.LoginName.Text;
            var userInfo = new UserData
            {
                name = LoginName.Text,
                age = LoginAge.Text
            };
            var userJson = JsonConvert.SerializeObject(userInfo);

            App.Current.Properties.Add("CurrentUser", userJson);
            this.LoginBlock.IsVisible = false;
            this.LogoutBlock.IsVisible = true;
            var userObject = JsonConvert.DeserializeObject<UserData>(userJson);
            this.CurrentUser.Text = userObject.name+" "+ userObject.age;
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("CurrentUser");
            this.LoginBlock.IsVisible = true;
            this.LogoutBlock.IsVisible = false;
        }
        public class UserData
        {
            public string name;
            public string age; 
        }
    }

}
