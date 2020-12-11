using System.Windows;

namespace Wpf_Loading
{
    public partial class LoadingPanel
    {
        public LoadingPanel()
        {
            InitializeComponent();

            Visable = false;
        }

        public bool Visable
        {
            get => Visibility == Visibility.Visible;
            set => Visibility = value ? Visibility.Visible : Visibility.Hidden;
        }
    }
}