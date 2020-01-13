using System;
using System.Windows;
using PurchaseWeasel_7.ViewModels;

namespace PurchaseWeasel_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = @"Server=192.168.10.3;database=Badger;uid=sa;pwd=Kx09a32x;";
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {           
            InitializeComponent();
            _viewModel  = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }


    
}
