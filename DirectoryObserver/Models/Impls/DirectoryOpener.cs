using DirectoryObserver.Models.Interfaces;
using System.IO;
using Windows.System;

namespace DirectoryObserver.Models.Impls
{
    public class DirectoryOpener : IDirectoryOpener
    {
        public void Open(string directory)
        {
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException();

            _ = Launcher.LaunchFolderPathAsync(directory);
        }
    }
}
