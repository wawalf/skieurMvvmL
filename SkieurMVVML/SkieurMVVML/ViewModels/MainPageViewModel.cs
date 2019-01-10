using GalaSoft.MvvmLight;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Models;
using SkieurMVVML.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using Xamarin.Forms.Navigation;
using GalaSoft.MvvmLight.Messaging;
//using GalaSoft.MvvmLight.Views;

namespace SkieurMVVML.ViewModels
{
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        private ISkieurService _dataService;
        private INavigationService _iNaviagtionService;

        public ObservableCollection<Skieur> Skieurs
        {
            set;
            get;
        }

        private Skieur selectedSkieur;

        public Skieur SelectedSkieur
        {
            get { return selectedSkieur; }
            set
            {
                selectedSkieur = value;
                Set(() => SelectedSkieur, ref selectedSkieur, value);
                //NavigateToDetail();
                //_iNaviagtionService.NavigateTo("DetailPage", selectedSkieur);
            }
        }

        private RelayCommand<Skieur> skieurRelayCommand;

        public RelayCommand<Skieur> SkieurRelayCommand
        {
            get
            {
                return skieurRelayCommand ?? (skieurRelayCommand = new RelayCommand<Skieur>(
                    skieur=> {
                        SelectedSkieur = skieur;
                        _iNaviagtionService.NavigateTo("DetailPage");
                        }));
            }

        }


        public ICommand NavigateToCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        private RelayCommand refreshRelayCommandAno;
        public RelayCommand RefreshRelayCommandAno
        {
            get
            {
                return refreshRelayCommandAno
                    ?? (refreshRelayCommandAno = new RelayCommand(
                        async () =>
                        {
                            await RefreshTask();
                        }));
            }
        }

        public RelayCommand RefreshRelayCommand { get; set; }


        public MainPageViewModel(
            ISkieurService dataService
            ,INavigationService iNavigationService
            )
        {
            _dataService = dataService;
            _iNaviagtionService = iNavigationService;
            //command navigation et parametre
            NavigateToCommand = new Command<String>(NavigateTo);
            //commande refresh
            RefreshCommand = new Command<string>(RefreshMethodeCommand);
            //relay command
            RefreshRelayCommand = new RelayCommand(Refresh);
            Skieurs = new ObservableCollection<Skieur>();
            //refresh on load
            Refresh();
        }

        public async void Refresh()
        {
            Skieurs.Clear();
            var lstSkieurs = await _dataService.Refresh();

            foreach (var item in lstSkieurs)
            {
                Skieurs.Add(item);
            }
        }


        private void NavigateTo(string obj)
        {
            var vm = CommonServiceLocator.ServiceLocator.Current.GetInstance<IDetailPageViewModel>();
            Messenger.Default.Send<Skieur>(SelectedSkieur);

            _iNaviagtionService.NavigateTo("DetailPage");
        }
        public void RefreshMethodeCommand(string obj)
        {
            Refresh();
        }

        public async Task RefreshTask()
        {
            Skieurs.Clear();
            var lstSkieurs = await _dataService.Refresh();

            foreach (var item in lstSkieurs)
            {
                Skieurs.Add(item);
            }
        }

    }
}
