using System;
using System.Collections.Generic;
using CollegePortalApplication.ViewModel;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator
{
    public partial class AdministratorOptionPage : ContentPage
    {
        public AdministratorOptionPage()
        {
            
            var pageService = new PageService();
            ViewModel = new AdministratorOptionViewModel(pageService);
            InitializeComponent();
            
        }
		//protected override void OnAppearing()
		//{
		//	ViewModel.LoadDataCommand.Execute(null);

		//	base.OnAppearing();
		//}

		//void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
		//{
		//	ViewModel.SelectContactCommand.Execute(e.SelectedItem);
		//}

		public AdministratorOptionViewModel ViewModel
		{
			get { return BindingContext as AdministratorOptionViewModel; }
			set { BindingContext = value; }
		}

        async void back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
