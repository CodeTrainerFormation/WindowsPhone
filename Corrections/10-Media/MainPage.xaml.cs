using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _10_Media
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MediaCapture MediaCaptureMgr { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.InitCe();
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
            {
                // User cancelled photo capture
                return;
            }
            else
            {
                BitmapImage bitmapImage = new BitmapImage();
                FileRandomAccessStream stream = (FileRandomAccessStream)await photo.OpenAsync(FileAccessMode.Read);
                
                bitmapImage.SetSource(stream);
            }

        }

        private async void InitCe()
        {
            MediaCaptureMgr = new MediaCapture();
            await MediaCaptureMgr.InitializeAsync();

            cePreview.Source = MediaCaptureMgr;

            await MediaCaptureMgr.StartPreviewAsync();
        }

        private async void TakePictureCE_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder picturesFolder = KnownFolders.PicturesLibrary;
            StorageFile photoStorageFile = await picturesFolder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);
            ImageEncodingProperties imageProperties = ImageEncodingProperties.CreateJpeg();
            await MediaCaptureMgr.CapturePhotoToStorageFileAsync(imageProperties, photoStorageFile);

        }
    }
}
