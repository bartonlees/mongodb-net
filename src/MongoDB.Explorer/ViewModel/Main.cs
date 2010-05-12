using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MongoDB.Explorer.Dialog;

namespace MongoDB.Explorer.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Main : INotifyPropertyChanged
    {
        public Main()
        {
            ServerNodes = new ObservableCollection<ServerNode>();
            ServerNodes.Add(new ServerNode(Mongo.DefaultServer));
        }

        Node _SelectedNode;
        public Node SelectedNode
        {
            get { return _SelectedNode; }
            set
            {
                if (value != _SelectedNode)
                {
                    _SelectedNode = value;
                    OnPropertyChanged("SelectedNode");
                    OnPropertyChanged("ServerActionVisibility");
                    OnPropertyChanged("DatabaseActionVisibility");
                    OnPropertyChanged("CollectionActionVisibility");
                    OnPropertyChanged("IndexActionVisibility");
                }
            }
        }

        public Visibility ServerActionVisibility { get { return (_SelectedNode != null && _SelectedNode is ServerNode)? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility DatabaseActionVisibility { get { return (_SelectedNode != null && _SelectedNode.GetType() == typeof(DatabaseNode)) ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility CollectionActionVisibility { get { return (_SelectedNode != null && _SelectedNode.GetType() == typeof(CollectionNode)) ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility IndexActionVisibility { get { return (_SelectedNode != null && _SelectedNode.GetType() == typeof(IndexNode)) ? Visibility.Visible : Visibility.Collapsed; } }

        public ObservableCollection<ServerNode> ServerNodes
        {
            get;
            private set;
        }

        public void AddNewServer()
        {
            NewServerBindingDialog dlg = new NewServerBindingDialog();
            bool? result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                ServerNode newNode = new ServerNode(Mongo.GetServer(dlg.Info.GetServerBinding()));
                ServerNodes.Add(newNode);
                SelectedNode = newNode;
            }
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
