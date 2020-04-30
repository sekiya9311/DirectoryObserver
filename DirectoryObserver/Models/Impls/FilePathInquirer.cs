
using DirectoryObserver.Models.Interfaces;

namespace DirectoryObserver.Models.Impls
{
    public class FilePathInquirer : IFilePathInquirer
    {
        public string InqueryDirectoryPath()
        {
            using var dialog = new System.Windows.Forms.FolderBrowserDialog();

            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK
                ? dialog.SelectedPath : "";
        }
    }
}
