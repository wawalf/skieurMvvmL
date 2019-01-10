using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
//using GalaSoft.MvvmLight.Views;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace SkieurMVVML.ViewModels
{
    public class DetailPageViewModel : ViewModelBase, IDetailPageViewModel
    {
        private INavigationService _iNavivationService;

        private Skieur skieur;

        public Skieur Skieur
        {
            get { return skieur; }
            set
            {
                skieur = value;
                Set(() => skieur, ref skieur, value);
            }
        }

        public string CurrentPageKey => throw new NotImplementedException();

        public DetailPageViewModel(INavigationService iNavigationService)
        {
            _iNavivationService = iNavigationService;
            //skieur = iNavigationService.GetParameters().GetValue<Skieur>(nameof(skieur));
            Messenger.Default.Register<Skieur>(this, skieur => { Skieur = skieur; });
        }

        //déclencher lorsque l'on arrive sur la vue

    }
}
