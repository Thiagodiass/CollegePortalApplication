using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class ActivitiesDetailViewModel
    {
        private readonly IActivitiesStore _activitiesStore;
        private readonly IPageService _pageService;

        public event EventHandler<Activities> ActivityAdded;
        public event EventHandler<Activities> ActivityUpdated;

        public Activities Activities { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ActivitiesDetailViewModel(ActivitiesTableViewModel viewModel, IActivitiesStore activitiesStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _activitiesStore = activitiesStore;

            SaveCommand = new Command(async () => await Save());

            Activities = new Activities
            {
                id = viewModel.Id,
                studentID = viewModel.StudentID,
                moduleID = viewModel.ModuleID,
                dueDate = viewModel.DueDate,
                grade = viewModel.Grade,
                type = viewModel.Type,
                weight = viewModel.Weight
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Activities.studentID)
                && String.IsNullOrWhiteSpace(Activities.moduleID)
                && String.IsNullOrWhiteSpace(Activities.type))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }
            if (Activities.id == 0)
            {
                await _activitiesStore.AddActivity(Activities);

                ActivityAdded?.Invoke(this, Activities);
            }
            else
            {
                await _activitiesStore.UpdateActivity(Activities);

                ActivityUpdated?.Invoke(this, Activities);
            }
            await _pageService.PopModalAsync();
        }
    }
}
