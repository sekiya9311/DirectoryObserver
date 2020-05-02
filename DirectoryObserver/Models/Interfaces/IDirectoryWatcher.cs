using System;
using System.IO;

namespace DirectoryObserver.Models.Interfaces
{
    public interface IDirectoryWatcher : IObservable<FileSystemEventArgs>
    {
        string Path { get; set; }
        string Filter { get; set; }
    }
}
