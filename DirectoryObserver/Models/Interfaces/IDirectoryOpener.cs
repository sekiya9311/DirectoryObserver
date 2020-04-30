using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryObserver.Models.Interfaces
{
    public interface IDirectoryOpener
    {
        void Open(string directory);
    }
}
