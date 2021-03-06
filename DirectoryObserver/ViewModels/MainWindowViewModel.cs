﻿using DirectoryObserver.Models.Interfaces;
using Prism.Mvvm;
using System;
using System.IO;
using System.Reactive.Linq;
using System.Text;

namespace DirectoryObserver.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDirectoryWatcher _watcher;
        private readonly INotifier _toaster;
        private readonly IDirectoryOpener _opener;
        private readonly IFilePathInquirer _filePathInquirer;

        public MainWindowViewModel(
            IDirectoryWatcher watcher,
            INotifier toaster,
            IDirectoryOpener opener,
            IFilePathInquirer filePathInquirer)
        {
            _watcher = watcher;
            _toaster = toaster;
            _opener = opener;
            _filePathInquirer = filePathInquirer;

            var path = _filePathInquirer.InqueryDirectoryPath();

            _watcher.Path = path;
            _watcher.Filter = "*.*";
            _watcher
                .Throttle(TimeSpan.FromMilliseconds(100))
                .Select(e => new StringBuilder()
                    .Append($"{e.Name} ")
                    .Append(e.ChangeType switch
                    {
                        WatcherChangeTypes.Created => "が作られたよ",
                        WatcherChangeTypes.Deleted => "が削除されたよ",
                        WatcherChangeTypes.Changed => "が変更されたよ",
                        WatcherChangeTypes.Renamed => "が改名されたよ",
                        _ => "になんかあったよ"
                    })
                    .ToString())
                .Subscribe(msg =>
                {
                    _toaster
                        .Toast("DirectoryObserver", msg);
                });

            _toaster.ToastClicked
                += (s, e) => _opener.Open(_watcher.Path);
        }
    }
}
