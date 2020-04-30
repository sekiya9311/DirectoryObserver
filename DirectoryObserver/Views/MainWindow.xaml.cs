using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace DirectoryObserver.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly ContextMenuStrip _contextMenu;

        public MainWindow()
        {
            InitializeComponent();

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
                "baseline_folder_open_black_48dp.ico"
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

        protected override void OnClosed(EventArgs e)
        {
            _notifyIcon?.Dispose();
            _contextMenu?.Dispose();

            base.OnClosed(e);
        }
    }
}
