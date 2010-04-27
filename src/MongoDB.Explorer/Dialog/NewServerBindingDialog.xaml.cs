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
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Explorer.ViewModel;

namespace MongoDB.Explorer.Dialog
{
    /// <summary>
    /// Interaction logic for NewBinding.xaml
    /// </summary>
    public partial class NewServerBindingDialog : Window
    {
        public ServerBindingInfo Info { get; private set;}

        public NewServerBindingDialog()
        {
            Info = new ServerBindingInfo();
            InitializeComponent();
            this.DataContext = Info;
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        
    }
}
