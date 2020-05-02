using System;

namespace DirectoryObserver.Models.Interfaces
{
    public interface INotifier
    {
        event EventHandler ToastClicked;

        void Toast(string title, string message);
    }
}
