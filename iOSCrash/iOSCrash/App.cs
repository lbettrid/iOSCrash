using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace iOSCrash
{
	public class App : Application
	{
		public App()
		{
			Image testingImg = new Image
			{
				Source = "ic_logo_white_text_50x50"
			};

			BackgroundView testingBackView = new BackgroundView();

			RelativeLayout testingRelativeLayout = new RelativeLayout();
			testingRelativeLayout.Children.Add(testingImg,
				Constraint.RelativeToParent((parent) => { return parent.Width / 2 - 25; }),
				Constraint.Constant(5.0d),
				Constraint.Constant(50.0d),
				Constraint.Constant(50.0d));

			testingRelativeLayout.Children.Add(testingBackView,
				Constraint.RelativeToParent((parent) => { return parent.Width / 2 - 50; }),
				Constraint.Constant(100.0d),
				Constraint.Constant(100.0d),
				Constraint.Constant(100.0d));

			Button testingButton = new Button
			{
				Text = "Remove image from relative layout"
			};
			testingButton.Clicked += (object sender, EventArgs e) =>
			{
				if (testingRelativeLayout.Children.Contains(testingImg))
				{
					testingRelativeLayout.Children.Remove(testingImg);
				}
			};

			Button testingButton2 = new Button
			{
				Text = "Remove view from relative layout"
			};
			testingButton2.Clicked += (object sender, EventArgs e) =>
			{
				if (testingRelativeLayout.Children.Contains(testingBackView))
				{
					testingRelativeLayout.Children.Remove(testingBackView);
				}
			};

			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.StartAndExpand,
					Children = {
						new Label
						{
							XAlign = TextAlignment.Center,
							Text = "Example app to demonstrate crash when calling RelativeLayout.RemoveAt()"
						},
						testingButton,
						testingButton2,
						testingRelativeLayout
					}
				}
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
