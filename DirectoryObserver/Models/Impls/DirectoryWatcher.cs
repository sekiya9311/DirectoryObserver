using DirectoryObserver.Models.Interfaces;
using System;
using System.IO;
using System.Reactive.Linq;

namespace DirectoryObserver.Models.Impls
{
    public class DirectoryWatcher : IDirectoryWatcher
    {
        private readonly FileSystemWatcher _watcher;

        public string Path
        {
            get => _watcher.Path;
            set
            {
                _watcher.Path = value;
                _watcher.EnableRaisingEvents = !string.IsNullOrEmpty(value);
            }
        }

        public string Filter
        {
            get => _watcher.Filter;
            set => _watcher.Filter = value;
        }

        public DirectoryWatcher()
        {
            _watcher = new FileSystemWatcher();
        }

        public IDisposable Subscribe(IObserver<FileSystemEventArgs> observer)
        {
            return Observable.Merge(
                _watcher.CreatedAsObservable(),
                _watcher.ChangedAsObservable(),
                _watcher.DeletedAsObservable(),
                _watcher.RenamedAsObservable()
            ).Subscribe(observer);
        }
    }
}
