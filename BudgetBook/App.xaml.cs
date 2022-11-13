using BudgetBook.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace BudgetBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainModel? _mainModel;
        private MainViewModel? _mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            SetCulture(Settings.Default.ApplicationCulture);

            // delete the startupuri tag from your app.xaml
            base.OnStartup(e);

            _mainModel = new MainModel();
            _mainViewModel = new MainViewModel(_mainModel);

            MainWindow = new MainWindow(_mainViewModel);
            MainWindow.Show();
        }

        private void SetCulture(string cultureName = "de-DE")
        {
            CultureInfo culture = new(cultureName);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}
