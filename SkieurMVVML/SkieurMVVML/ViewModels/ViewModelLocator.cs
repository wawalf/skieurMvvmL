using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
//using GalaSoft.MvvmLight.Views;
using SkieurMVVML.IViewModel;
using SkieurMVVML.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace SkieurMVVML.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ISkieurService, SkieurService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            SimpleIoc.Default.Register<IMainPageViewModel,MainPageViewModel>();
            SimpleIoc.Default.Register<IDetailPageViewModel, DetailPageViewModel>();

            //Creatoin d'un nouveau messenger 
            // pour meme message sur plusieur messenger pour action diff
            //pas de message en tre messenger





            //NavigationServiceLight nav = new NavigationServiceLight();
            //nav.Configure("firstPage", typeof(MainPage));
        }

        public IMainPageViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IMainPageViewModel>();
            }
        }

        public IDetailPageViewModel Detail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDetailPageViewModel>();
            }
        }




        //SimpleIoc.Default.Register<INavigationService, NavigationService>();
    }
}
