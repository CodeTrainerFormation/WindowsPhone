using _12_ShareTarget.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer.ShareTarget;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Share Target Contract item template is documented at http://go.microsoft.com/fwlink/?LinkId=234241

namespace _12_ShareTarget
{
    /// <summary>
    /// This page allows other applications to share content through this application.
    /// </summary>
    public sealed partial class ShareTargetPage : Page
    {
        /// <summary>
        /// Provides a channel to communicate with Windows about the sharing operation.
        /// </summary>
        private ShareOperation shareOperation;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public ShareTargetPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when another application wants to share content through this application.
        /// </summary>
        /// <param name="e">Activation data used to coordinate the process with Windows.</param>
        public async void Activate(ShareTargetActivatedEventArgs e)
        {
            this.shareOperation = e.ShareOperation;
            this.shareOperation.ReportStarted();
            var shareProperties = this.shareOperation.Data.Properties;
            this.DefaultViewModel["Title"] = shareProperties.Title;
            this.DefaultViewModel["Description"] = shareProperties.Description;
            this.DefaultViewModel["Text"] = await shareOperation.Data.GetTextAsync();
            Window.Current.Content = this; Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when the user clicks the Share button.
        /// </summary>
        /// <param name="sender">Instance of Button used to initiate sharing.</param>
        /// <param name="e">Event data describing how the button was clicked.</param>
        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
            this.shareOperation.ReportStarted();
            

            this.shareOperation.ReportCompleted();
        }
    }
}
