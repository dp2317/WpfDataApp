using System.Windows;
using WpfDataApp.ViewModels;

namespace WpfDataApp
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
