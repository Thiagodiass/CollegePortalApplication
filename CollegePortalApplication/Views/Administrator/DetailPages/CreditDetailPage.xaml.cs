using System;
using System.Collections.Generic;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator.DetailPages
{
    public partial class CreditDetailPage : ContentPage
    {
        public CreditDetailPage(CreditDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        async void back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
