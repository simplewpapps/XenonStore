using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using Windows.System;
using Windows.Storage;

namespace XenonStore
{
    public sealed partial class AppDetails : Page
    {
        private StoreApplication currentApp;
        private readonly AppDownloader downloader = new AppDownloader();

        public AppDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is StoreApplication)
            {
                currentApp = e.Parameter as StoreApplication;
                DataContext = currentApp;
            }
        }

        private void Button_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void Button_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            //LoadingRing.Visibility = Windows.UI.Xaml.Visibility.Visible;
            InstallButton.IsEnabled = false;
            DownloadProgress.Visibility = Windows.UI.Xaml.Visibility.Visible;
            DownloadProgress.Value = 0;

            try
            {
                StorageFile file = await downloader.DownloadAsync(currentApp.DownloadUrl, DownloadProgress);
                await Launcher.LaunchFileAsync(file);
            }
            catch (OperationCanceledException)
            {
                ShowMessage("Downloading has been canceled.");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                //LoadingRing.Visibility = Visibility.Collapsed;
                InstallButton.IsEnabled = true;
                DownloadProgress.Visibility = Visibility.Collapsed;
            }
        }

        private async void ShowMessage(string msg)
        {
            var dlg = new Windows.UI.Popups.MessageDialog(msg);
            await dlg.ShowAsync();
        }
    }
}
