using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MongoDB.Explorer.ViewModel
{
    public abstract class Node : INotifyPropertyChanged
    {
        bool _IsExpanded = false;
        public Node Parent { get; private set;}

        public Node(Node parent)
        {
            Parent = parent;
            Children = new ObservableCollection<Node>();
            CreateLoadingNode();
        }

        public virtual void CreateLoadingNode()
        {
            Loading = new LoadingNode(this);
            Children.Add(Loading);
        }

        public abstract string Name { get; set; }

        public ObservableCollection<Node> Children
        {
            get;
            private set;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                if (value != _IsExpanded)
                {
                    _IsExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (_IsExpanded && Parent != null)
                    Parent.IsExpanded = true;

                if (this.Loading != null)
                {
                    try
                    {
                        this.LoadChildren();
                    }
                    catch (Exception x)
                    {
                        this.Children.Add(new ExceptionNode(this, x));
                    }
                    this.Children.Remove(Loading);
                    this.Loading = null;
                }
            }
        }

        bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (value != _IsSelected)
                {
                    _IsSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        /// <summary>
        /// Invoked when the child items need to be loaded on demand.
        /// Subclasses can override this to populate the Children collection.
        /// </summary>
        protected virtual void LoadChildren()
        {
        }

        public virtual void Drop()
        {
            Parent.Children.Remove(this);
        }

        public virtual void Refresh()
        {
            Children.Clear();
            Loading = new LoadingNode(this);
            Children.Add(Loading);
            this.IsExpanded = false;
        }

        public virtual void AddChild(string name)
        {
        }

        public LoadingNode Loading { get; private set; }
    }

    public class LoadingNode : Node
    {
        public LoadingNode(Node parent)
            : base(parent)
        {
        }

        public override void CreateLoadingNode()
        {
        }

        public override string Name
        {
            get { return "Loading..."; }
            set { }
        }
    }

    public class ExceptionNode : Node
    {
        public Exception Exception { get; set; }
        public ExceptionNode(Node parent, Exception x)
            : base(parent)
        {
            Exception = x;
        }

        public override void CreateLoadingNode()
        {
        }

        public override string Name
        {
            get 
            {
                return "Error - Click for details"; 
            }
            set { }
        }
    }
}
