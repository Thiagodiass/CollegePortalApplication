using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CollegePortalApplication.Model;
using CollegePortalApplication.ViewModel.Interfaces;
using CollegePortalApplication.ViewModel.ViewModelTables;
using CollegePortalApplication.Views.Administrator.DetailPages;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel.Administrator
{
    public class ModuleViewModel : BaseViewModel
    {
        private ModuleTableViewModel _selectedModule;
        private IModule _moduleStore;
        private IPageService _pageService;
        private bool _isDataLoaded;

        public ObservableCollection<ModuleTableViewModel> Modules { get; private set; } = new ObservableCollection<ModuleTableViewModel>();

        public ModuleTableViewModel SelectedModule
        {
            get { return _selectedModule; }
            set { SetValue(ref _selectedModule, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddModule { get; private set; }
        public ICommand SelectModule { get; private set; }
        public ICommand DeleteModule { get; private set; }

        public ModuleViewModel(IModule moduleStore, IPageService pageService)
        {
            _moduleStore = moduleStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddModule = new Command(async () => await AddModules());
            SelectModule = new Command<ModuleTableViewModel>(async c => await SelectModules(c));
            DeleteModule = new Command<ModuleTableViewModel>(async c => await DeleteModules(c));
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var module = await _moduleStore.GetModulesAsync();

            foreach (var m in module)
                Modules.Add(new ModuleTableViewModel(m));
        }

        private async Task AddModules()
        {
            var viewModel = new ModuleDetailViewModel(new ModuleTableViewModel(), _moduleStore, _pageService);

            viewModel.ModuleAdded += (source, module) =>
            {
                Modules.Add(new ModuleTableViewModel(module));
            };

            await _pageService.PushModalAsync(new ModuleDetailPage(viewModel));
        }

        private async Task SelectModules(ModuleTableViewModel module)
        {
            if (module == null)
                return;

            SelectedModule = null;

            var viewModel = new ModuleDetailViewModel(module, _moduleStore, _pageService);
            viewModel.ModuleUpdated += (source, updateModule) =>
            {
                module.Id = updateModule.id;
                module.ModuleID = updateModule.moduleID;
                module.ModuleName = updateModule.moduleName;
                module.StaffID = updateModule.staffID;
                module.CourseID = updateModule.courseID;
                module.CreditID = updateModule.creditID;
            };

            await _pageService.PushModalAsync(new ModuleDetailPage(viewModel));
        }

        private async Task DeleteModules(ModuleTableViewModel module)
        {
            var a = "";
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete{module.ModuleID}?", "Yes", "No"))
            {
                Modules.Remove(module);
                var userModule = await _moduleStore.GetModules(module.Id);
                await _moduleStore.DeleteModule(userModule);
            }
        }
    }
}
