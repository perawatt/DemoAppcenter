﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DemoAppcenter
{
	public partial class App : Application
	{
        public static App Instant;

        public App ()
		{
            if (Instant == null)
            {
                Instant = this;
            }
            InitializeComponent();

			MainPage = new DemoAppcenter.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
