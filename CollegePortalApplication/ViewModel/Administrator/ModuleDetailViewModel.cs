using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class ModuleDetailViewModel
    {
        private readonly IModule _moduleStore;
        private readonly IPageService _pageService;

        public event EventHandler<Module> ModuleAdded;
        public event EventHandler<Module> ModuleUpdated;

        public Module Module { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ModuleDetailViewModel(ModuleTableViewModel viewModel, IModule moduleStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _moduleStore = moduleStore;

            SaveCommand = new Command(async () => await Save());

            Module = new Module
            {
                id = viewModel.Id,
                creditID = viewModel.CreditID,
                moduleID = viewModel.ModuleID,
                courseID = viewModel.CourseID,
                moduleName = viewModel.ModuleName,
                staffID = viewModel.StaffID
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Module.moduleID)
                && String.IsNullOrWhiteSpace(Module.creditID)
                && String.IsNullOrWhiteSpace(Module.staffID)
                && String.IsNullOrWhiteSpace(Module.moduleName)
                && String.IsNullOrWhiteSpace(Module.courseID))
            {
                await _pageService.DisplayAlert("Error", "Please enter All the Fields", "OK");
                return;
            }
            if (Module.id == 0)
            {
                await _moduleStore.AddModule(Module);

                ModuleAdded?.Invoke(this, Module);
            }
            else
            {
                await _moduleStore.UpdateModule(Module);

                ModuleUpdated?.Invoke(this, Module);
            }
            await _pageService.PopModalAsync();
        }
    }
}
