using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryObserver.Models.Interfaces
{
    public interface IToaster
    {
        void Toast(string title, string message, Action activated);
    }
}
