using System.Windows;
using System.ComponentModel;

namespace Wpf_Loading
{
    public class BackgroundWorkerShowBusy
    {
        LoadingPanel Loading_Panel { set; get; }
        Window window { set; get; }
        bool IsLoading
        {
            set
            {
                Loading_Panel.Visable = value;
                window.IsEnabled = !value;
            }
            get => Loading_Panel.Visable;
        }

        public BackgroundWorkerShowBusy(LoadingPanel _Loading_Panel, Window _window)
        {
            Loading_Panel = _Loading_Panel;
            window = _window;
        }

        //
        // 摘要:
        //     Occurs when System.ComponentModel.BackgroundWorker.RunWorkerAsync is called.
        public event DoWorkEventHandler? DoWork;
        //
        // 摘要:
        //     Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32)
        //     is called.
        public event ProgressChangedEventHandler? ProgressChanged;
        //
        // 摘要:
        //     Occurs when the background operation has completed, has been canceled, or has
        //     raised an exception.
        public event RunWorkerCompletedEventHandler? RunWorkerCompleted;
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoWork?.Invoke(sender, e);
        }
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(sender, e);
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompleted?.Invoke(sender, e);
            IsLoading = false;
        }

        BackgroundWorker backgroundWorker { set; get; }
        public void RunWorkerAsync()
        {
            IsLoading = true;


            backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            backgroundWorker.RunWorkerAsync();
        }
    }
}
