﻿using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using UwpWithMvvmDemo.Common;
using UwpWithMvvmDemo.ViewModels;

namespace UwpWithMvvmDemo
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Configure(Const.MAIN_PAGE_KEY, typeof(MainPage));
            nav.Configure(Const.ABOUT_PAGE_KEY, typeof(AboutPage));


            SimpleIoc.Default.Register<INavigationService>(() => nav);

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<AboutPageViewModel>();
        }

        public MainPageViewModel MainPageVm => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        public AboutPageViewModel AboutPageVm => ServiceLocator.Current.GetInstance<AboutPageViewModel>();
    }
}
