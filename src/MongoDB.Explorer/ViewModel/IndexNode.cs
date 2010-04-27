using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.ComponentModel;

namespace MongoDB.Explorer.ViewModel
{
    public class IndexNode : Node
    {
        public IDBIndex Index { get; private set; }

        public IndexNode(IDBIndex index, CollectionNode parent) : base(parent)
        {
            Index = index;
        }

        public override string Name
        {
            get { return Index.Name; }
            set { }
            //set
            //{
            //    _Index.Name = value;
            //}
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public override void Drop()
        {
            (Parent as CollectionNode).Collection.DropIndex(Index);
            base.Drop();
        }

        public override void AddChild(string name)
        {
        }
    }
}
