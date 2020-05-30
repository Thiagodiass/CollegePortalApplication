using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.Views.Administrator;

using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class AdministratorOptionViewModel : BaseViewModel
    {
        private IPageService _pageService;
        public IList<AdmOption> Options { get { return AdmOptionData.Options; } }
        public ICommand ContinueSelected { get; private set; }
        
        AdmOption selectedOption;

        public AdmOption SelectedOption
        {
            get { return selectedOption; }
            set
            {
                
                if(selectedOption != value)
                {
                    selectedOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsButtonEnabled { get; private set; }

        public AdministratorOptionViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ContinueSelected = new Command(async ()=>await SelectedPage());
        }
        
        private async Task SelectedPage()
        {
            var pageChoose = selectedOption.Id;
            

            if (pageChoose.Equals("AO01"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new ActivitiesPage());
            }
            if (pageChoose.Equals("AO02"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new AttendancePage());
            }
            if (pageChoose.Equals("AO03"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new CoursesPage());
            }
            if (pageChoose.Equals("AO04"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new CreditPage());
            }
            if (pageChoose.Equals("AO05"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new ModulePage());
            }
            if (pageChoose.Equals("AO06"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new PaymentStatusPage());
            }
            if (pageChoose.Equals("AO07"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new StaffPage());
            }
            if (pageChoose.Equals("AO08"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new StudentPage());
            }
            if (pageChoose.Equals("AO09"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new StudentOverviewPage());
            }
            if (pageChoose.Equals("AO10"))
            {
                IsButtonEnabled = true;
                await _pageService.PushAsync(new UsersAccountTypePage());
            }
        }
    }
}
