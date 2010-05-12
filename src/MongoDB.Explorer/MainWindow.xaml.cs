using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Explorer.ViewModel;

namespace MongoDB.Explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Main _ViewModel = new Main();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter == null)
            {
                _ViewModel.AddNewServer();
            }
            else
            {
                _ViewModel.SelectedNode.AddChild(new Random().Next().ToString());
            }
        }

        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _ViewModel.SelectedNode != null;
        }

        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _ViewModel.SelectedNode.Drop();
        }

        private void Refresh_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _ViewModel.SelectedNode != null;
        }

        private void Refresh_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _ViewModel.SelectedNode.Refresh();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _ViewModel;
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _ViewModel.SelectedNode = e.NewValue as Node;
        }
    }
}
