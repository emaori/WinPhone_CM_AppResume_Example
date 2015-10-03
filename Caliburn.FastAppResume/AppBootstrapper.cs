using System.Windows.Navigation;
using Caliburn.FastAppResume.ViewModels;

namespace Caliburn.FastAppResume
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using Microsoft.Phone.Controls;
    using Caliburn.Micro;

    public class AppBootstrapper : PhoneBootstrapperBase
    {
        private PhoneContainer container;
        private PhoneApplicationFrame rootFrame;
        private bool reset;

        public AppBootstrapper()
        {

        }

        protected override PhoneApplicationFrame CreatePhoneApplicationFrame()
        {
            rootFrame = new PhoneApplicationFrame();
            return rootFrame;
        }

        protected override void Configure()
        {
            container = new PhoneContainer();
            if (!Execute.InDesignMode)
                container.RegisterPhoneServices(RootFrame);

            container.PerRequest<MainPageViewModel>();
            container.PerRequest<Page2ViewModel>();

            AddCustomConventions();

            rootFrame.Navigated += rootFrame_Navigated;
            rootFrame.Navigating += rootFrame_Navigating;
        }

        void rootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (reset && e.IsCancelable && e.Uri.OriginalString == "/Views/MainPage.xaml")
            {
                e.Cancel = true;
                reset = false;
            }
        }

        void rootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            reset = e.NavigationMode == NavigationMode.Reset;
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        private static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<Pivot>(Pivot.ItemsSourceProperty, "SelectedItem", "SelectionChanged")
                .ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof (ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Pivot.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Pivot.HeaderTemplateProperty, null, viewModelType);
                        return true;
                    }

                    return false;
                };

            ConventionManager.AddElementConvention<Panorama>(Panorama.ItemsSourceProperty, "SelectedItem",
                "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof (ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Panorama.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Panorama.HeaderTemplateProperty, null, viewModelType);
                        return true;
                    }

                    return false;
                };
        }
    }
}