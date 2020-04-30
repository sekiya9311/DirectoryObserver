using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirectoryObserver.Models.Interfaces
{
    public interface IDirectoryWatcher : IObservable<FileSystemEventArgs>
    {
        string Path { get; set; }
        string Filter { get; set; }
    }
}
