using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.Storage;
using Windows.ApplicationModel;
using Windows.System;

namespace HolodeskDemo
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage ()
		{
			this.InitializeComponent();
		}

		private async void office_Click (object sender, RoutedEventArgs e)
		{
			Button on = (Button)sender;
			string nameDoc = on.Content.ToString();
			StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(nameDoc);
			await Launcher.LaunchFileAsync(file);
		}

		private async void word_Click (object sender, RoutedEventArgs e)
		{
			Button on = (Button)sender;
			string nameDoc = on.Content.ToString();
			var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(nameDoc);

			if (file != null)
			{
				// Set the option to show the picker
				var options = new Windows.System.LauncherOptions();
				options.DisplayApplicationPicker = true;

				// Launch the retrieved file
				bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
				if (success)
				{
					// File launched
				}
				else
				{
					// File launch failed
				}
			}
			else
			{
				// Could not find file
			}
		}

		private void link_click (object sender, RoutedEventArgs e)
		{
			HyperlinkButton h = (HyperlinkButton)sender;
			string strTest = h.NavigateUri.AbsoluteUri;
			if (strTest != "HyperlinkButton")
			{
				h.NavigateUri = new Uri(strTest);
			}
		}

		private void button_Click (object sender, RoutedEventArgs e)
		{

		}
	}
}
