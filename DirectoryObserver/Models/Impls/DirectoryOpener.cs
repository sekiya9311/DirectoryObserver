using DirectoryObserver.Models.Interfaces;
using System.Diagnostics;
using System.IO;

namespace DirectoryObserver.Models.Impls
{
    public class DirectoryOpener : IDirectoryOpener
    {
        public void Open(string directory)
        {
            if (!Directory.Exists(directory))
                throw new DirectoryNotFoundException();

            Process.Start(new ProcessStartInfo(directory)
            {
                UseShellExecute = true
            });
        }
    }
}
