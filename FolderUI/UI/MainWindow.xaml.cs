using Repository;
using Repository.Interface;
using System.Windows;
using ViewModel;

namespace FolderUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var folderViewModel = new FolderViewModel(new FolderService());
            this.DataContext = folderViewModel;            
        }
    }
}

