using DirectoryObserver.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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
