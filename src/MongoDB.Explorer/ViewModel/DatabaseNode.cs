using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MongoDB.Explorer.ViewModel
{
    public class DatabaseNode : Node
    {
        public IDatabase Database { get; private set;}

        public DatabaseNode(IDatabase database, ServerNode parent) : base(parent)
        {
            Database = database;
        }

        public override string Name
        {
            get { return Database.Name; }
            set
            {
                //Database. = value;
            }
        }

        public override void Drop()
        {
            Database.Drop();
            base.Drop();
        }


        public override void Refresh()
        {
            Database.ClearCollectionCache();
            base.Refresh();
        }

        public override void AddChild(string name)
        {
        }

        protected override void LoadChildren()
        {
            foreach (IDBCollection collection in Database.Collections)
            {
                Children.Add(new CollectionNode(collection, this));
            }
            base.LoadChildren();
        }
    }
}
