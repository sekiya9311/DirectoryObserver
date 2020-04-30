using DirectoryObserver.Models.Interfaces;
using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace DirectoryObserver.Models.Impls
{
    public class Toaster : IToaster
    {
        public void Toast(string title, string message, Action activated)
        {
            var xml =
                $@"<toast>
                       <visual>
                           <binding template='ToastGeneric'>
                               <text>{title}</text>
                               <text>{message}</text>
                           </binding>
                       </visual>
                   </toast>";

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var toast = new ToastNotification(doc);
            toast.Activated += (s, args) => activated?.Invoke();

            ToastNotificationManager
                .CreateToastNotifier()
                .Show(toast);
        }
    }
}
