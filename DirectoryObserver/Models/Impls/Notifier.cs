using DirectoryObserver.Models.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DirectoryObserver.Models.Impls
{
    public class Notifier : INotifier
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenu;

        public event EventHandler ToastClicked
        {
            add { _notifyIcon.BalloonTipClicked += value; }
            remove { _notifyIcon.BalloonTipClicked -= value; }
        }

        public Notifier()
        {
            _notifyIcon = CreateNotifyIcon();
            _contextMenu = CreateContextMenu();

            _notifyIcon.ContextMenuStrip = _contextMenu;
        }

        private NotifyIcon CreateNotifyIcon()
        {
            var executeDirPath = Path.GetDirectoryName(
                Assembly.GetEntryAssembly().Location
            );
            var imgPath = Path.Combine(
                executeDirPath,
                "Resources",
                "MaterialIcons",
                "baseline_folder_open_white_48dp.ico"
            );

            var res = new NotifyIcon
            {
                Visible = true,
                Text = "DirectoryObserver",
                Icon = new Icon(imgPath)
            };
            return res;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            var exitMenu = new ToolStripMenuItem
            {
                Text = "終了"
            };
            exitMenu.Click += (s, e) =>
            {
                System.Windows.Application.Current.Shutdown();
            };

            var res = new ContextMenuStrip();
            res.Items.Add(exitMenu);
            return res;
        }

        public void Toast(string title, string message)
        {
            _notifyIcon.ShowBalloonTip(
                2000, title, message, ToolTipIcon.Info);
        }
    }
}
