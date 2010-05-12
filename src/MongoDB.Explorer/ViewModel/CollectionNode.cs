using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MongoDB.Explorer.ViewModel
{
    public class CollectionNode : Node
    {
        public IDBCollection Collection { get; private set; }

        public CollectionNode(IDBCollection collection, DatabaseNode parent) : base(parent)
        {
            Collection = collection;
        }

        public override string Name
        {
            get { return Collection.Name; }
            set { }
            //set
            //{
            //    _Collection.Name = value;
            //}
        }

        public override void Drop()
        {
            Collection.Drop();
            base.Drop();
        }

        public override void Refresh()
        {
            Collection.ClearIndexCache();
            base.Refresh();
        }

        protected override void LoadChildren()
        {
            foreach (IDBIndex index in Collection.Indexes)
            {
                Children.Add(new IndexNode(index, this));
            }
            base.LoadChildren();
        }

        public override void AddChild(string name)
        {
            
        }
    }
}
