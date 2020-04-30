using Prism.Ioc;
using DirectoryObserver.Views;
using System.Windows;
using DirectoryObserver.Models;
using DirectoryObserver.Models.Interfaces;
using DirectoryObserver.Models.Impls;

namespace DirectoryObserver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry
                .RegisterSingleton<IToaster, Toaster>()
                .RegisterSingleton<IDirectoryWatcher, DirectoryWatcher>()
                .RegisterSingleton<IDirectoryOpener, DirectoryOpener>()
                .RegisterSingleton<IFilePathInquirer, FilePathInquirer>();
        }
    }
}
