using System;
using System.Collections.Generic;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Administrator;
using Xamarin.Forms;

namespace CollegePortalApplication.Views.Administrator.Add
{
    public partial class AddUsersAccountTypePage : ContentPage
    {
        UsersAccountTypeViewModel vm;

        public AddUsersAccountTypePage()
        {
            InitializeComponent();
        }
        async void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public async void add_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.UsersAccountTypeRepo.AddNewUserAccountTypeAsync(accountType.Text, accountName.Text);
        }
    }
}
