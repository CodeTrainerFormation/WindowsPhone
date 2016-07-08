using _9_Mvvm.Models;
using _9_Mvvm.Services.DataServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace _9_Mvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public const string ClockPropertyName = "Clock";
        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        private string clock = "Démarrage";

        private readonly IDataService dataService;
        private readonly INavigationService navigationService;


        private int counter;
        private string welcomeTitle = string.Empty;
        private bool clockRunning;

        private RelayCommand showDialogCommand;
        private RelayCommand incrementCommand;
        private RelayCommand<string> navigateCommand;
        private RelayCommand sendMessageCommand;

        public string Clock
        {
            get
            {
                return clock;
            }
            set
            {
                Set(ClockPropertyName, ref clock, value);
            }
        }

        public RelayCommand IncrementCommand
        {
            get
            {
                return incrementCommand ??
                    (incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Compteur de clic = {0}", ++counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return navigateCommand ??
                       (navigateCommand = new RelayCommand<string>(
                           p => navigationService.NavigateTo(ViewModelLocator.DetailKey, p),
                           p => !string.IsNullOrEmpty(p)));
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return sendMessageCommand
                    ?? (sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Test",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return showDialogCommand
                       ?? (showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello World depuis une Universal App !", "Ca marche !");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return welcomeTitle;
            }

            set
            {
                Set(ref welcomeTitle, value);
            }
        }

        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            this.dataService = dataService;
            this.navigationService = navigationService;
            Task.Run(() => initialize()).Wait();
        }

        public void RunClock()
        {
            clockRunning = true;

            Task.Run(async () =>
            {
                while (clockRunning)
                {
                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    {
                        Clock = DateTime.Now.ToString("HH:mm:ss");
                    });

                    await Task.Delay(1000);
                }
            });
        }

        public void StopClock()
        {
            clockRunning = false;
        }

        private async Task initialize()
        {
            try
            {
                var item = await dataService.GetData();
                WelcomeTitle = item.Title;
            }
            catch (Exception ex)
            {
                WelcomeTitle = ex.Message;
            }
        }
    }
}