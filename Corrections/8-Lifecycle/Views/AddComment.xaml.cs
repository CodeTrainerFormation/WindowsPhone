using _8_Lifecycle.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _8_Lifecycle.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddComment : Page
    {


        public AddComment()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            bool suspending = ((App)App.Current).IsSuspending;

            if(suspending)
            {
                var composite = new ApplicationDataCompositeValue();
                composite["author"] = tbAuthor.Text;
                composite["comment"] = tbComment.Text;
                ApplicationData.Current.LocalSettings.Values["unsaved_data"] = composite;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.NavigationMode != NavigationMode.New && ApplicationData.Current.LocalSettings.Values.ContainsKey("unsaved_data"))
            {
                var composite = (ApplicationDataCompositeValue)ApplicationData.Current.LocalSettings.Values["unsaved_data"];

                ((AddCommentViewModel)this.DataContext).Author = (string)composite["author"];
                ((AddCommentViewModel)this.DataContext).Comment = (string)composite["comment"];

                ApplicationData.Current.LocalSettings.Values.Remove("unsaved_data");
            }
            
        }
    }
}
