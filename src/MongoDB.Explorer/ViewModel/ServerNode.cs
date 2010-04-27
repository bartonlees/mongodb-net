using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MongoDB.Explorer.ViewModel
{
    public class ServerNode : 
        Node
    {
        IServer _Server;
        public ServerNode(IServer server) : base(null)
        {
            _Server = server;
        }

        public override string Name { get { return _Server.Binding.ToString(); } set { } }

        public override void Drop()
        {
        }

        public override void AddChild(string name)
        {
            base.AddChild(name);
        }

        protected override void LoadChildren()
        {    
            foreach (IDatabase database in _Server.Databases)
            {
                Children.Add(new DatabaseNode(database, this));
            }
            base.LoadChildren();
        }
    }
}
