using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _11_Share
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += DataTransferManager_DataRequested;

            // Permet de partager les données via la contrat de partage
            DataTransferManager.ShowShareUI();
        }

        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest req = args.Request;
            req.Data.SetText(tbDataToShare.Text);

            req.Data.Properties.Title = "Exemple de partage";
            req.Data.Properties.Description = "Bonjour de l'app Discover";
        }

        private async void LaunchApp_Click(object sender, RoutedEventArgs e)
        {
            // Utilise le protocol de la seconde app
            var uriString = string.Concat("customapp:Detail/", tbDataToShare.Text);
            var uri = new Uri(uriString);
            // Permet de lancer la 2e app
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }
    }
}
