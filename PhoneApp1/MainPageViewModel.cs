using Caliburn.Micro;

namespace PhoneApp1
{
    public class MainPageViewModel : Caliburn.Micro.Screen
    {
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        public void GoToPage2()
        {
            this._navigationService.UriFor<Page2ViewModel>().Navigate();

        }

}
}