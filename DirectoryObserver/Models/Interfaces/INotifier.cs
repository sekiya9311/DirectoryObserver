using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryObserver.Models.Interfaces
{
    public interface INotifier
    {
        event EventHandler ToastClicked;

        void Toast(string title, string message);
    }
}
