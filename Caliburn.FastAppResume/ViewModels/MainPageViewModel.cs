using Caliburn.Micro;

namespace Caliburn.FastAppResume.ViewModels
{
    public class MainPageViewModel: Screen
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void GoToPage2()
        {
            _navigationService.UriFor<Page2ViewModel>().Navigate();
        }
    }
}