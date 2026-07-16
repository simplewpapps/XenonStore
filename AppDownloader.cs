using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace XenonStore
{
    public class AppDownloader
    {
        private DownloadOperation downloadOperation;
        private CancellationTokenSource cts;

        public async Task<StorageFile> DownloadAsync(string downloadUrl, ProgressBar progressBar = null)
        {
            cts = new CancellationTokenSource();

            var uri = new Uri(downloadUrl);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            StorageFolder downloadsFolder;
            try
            {
                StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
                downloadsFolder = await picturesFolder.CreateFolderAsync("XenonStore Packages", CreationCollisionOption.OpenIfExists);
            }
            catch
            {
                downloadsFolder = ApplicationData.Current.TemporaryFolder;
            }

            StorageFile file = await downloadsFolder.CreateFileAsync(filename, CreationCollisionOption.GenerateUniqueName);

            var downloader = new BackgroundDownloader();
            downloadOperation = downloader.CreateDownload(uri, file);

            var progressCallback = new Progress<DownloadOperation>(op =>
            {
                if (progressBar == null) return;

                var progress = op.Progress;
                if (progress.TotalBytesToReceive > 0)
                {
                    double percent = (double)progress.BytesReceived / progress.TotalBytesToReceive * 100;

                    var ignored = progressBar.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        {
                            progressBar.IsIndeterminate = false;
                            progressBar.Value = percent;
                        });
                }
                else
                {
                    var ignored = progressBar.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => progressBar.IsIndeterminate = true);
                }
            });

            await downloadOperation.StartAsync().AsTask(cts.Token, progressCallback);

            if (progressBar != null)
            {
                await progressBar.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        progressBar.IsIndeterminate = false;
                        progressBar.Value = 100;
                    });
            }

            return file;
        }
    }
}
