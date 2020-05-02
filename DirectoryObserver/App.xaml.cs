using DirectoryObserver.Models.Impls;
using DirectoryObserver.Models.Interfaces;
using DirectoryObserver.Views;
using Prism.Ioc;
using System.Windows;

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
                .Register<INotifier, Notifier>()
                .RegisterSingleton<IDirectoryWatcher, DirectoryWatcher>()
                .RegisterSingleton<IDirectoryOpener, DirectoryOpener>()
                .RegisterSingleton<IFilePathInquirer, FilePathInquirer>();
        }
    }
}
