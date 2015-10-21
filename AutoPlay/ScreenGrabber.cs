using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace AutoPlay
{
    static class ScreenGrabber
    {
        public static async Task TakeSnapshotAsync(FrameworkElement element, string filePath, StorageFolder folder)
        {
            var file = await folder.CreateFileAsync(filePath, CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                await CaptureToStreamAsync(element, stream);
            }
        }

        static async Task CaptureToStreamAsync(FrameworkElement element, IRandomAccessStream stream)
        {
            var renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(element, (int)element.ActualWidth, (int)element.ActualHeight);
            var pixels = await renderTargetBitmap.GetPixelsAsync();
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;

            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight,
                logicalDpi, logicalDpi, pixels.ToArray());

            await encoder.FlushAsync();
        }
    }
}
