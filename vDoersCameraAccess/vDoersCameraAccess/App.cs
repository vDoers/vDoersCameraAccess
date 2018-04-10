﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace vDoersCameraAccess
{
	public class App : Application
	{
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new Pages.CameraAccessPage()) { BarBackgroundColor = Color.FromHex("#3f4952") };
        }

		protected override void OnStart ()
		{
            //This is for Sure Nothing
		}

		protected override void OnSleep ()
		{
			//Merge This Commit
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
