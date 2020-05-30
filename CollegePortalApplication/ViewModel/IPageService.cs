using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollegePortalApplication.ViewModel
{
	public interface IPageService
	{
		Task PushAsync(Page page);
		Task<Page> PopAsync();
		Task<Page> PopModalAsync();
		Task PushModalAsync(Page page);
		Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
		Task DisplayAlert(string title, string message, string ok);
	}
}
