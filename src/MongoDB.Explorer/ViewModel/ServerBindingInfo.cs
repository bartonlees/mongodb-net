using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.ComponentModel;

namespace MongoDB.Explorer.ViewModel
{
    public class ServerBindingInfo : IDataErrorInfo
    {
        public ServerBindingInfo()
        {
            IServerBinding serverBinding = MongoDB.Driver.Mongo.DefaultServerBinding;
            HostName = serverBinding.HostName;
            Port = DBBinding.DefaultPort.ToString();
        }

        public string Port { get; set; }
        public string HostName { get; set; }
        public bool ReadOnly { get; set; }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get 
            {
                string error = null;
                switch (columnName)
                {
                    case "HostName":
                        try
                        {
                            ServerBinding s = new ServerBinding(HostName, DBBinding.DefaultPort);
                        }
                        catch
                        {
                            error = "Cannot parse host name";
                        }
                        break;
                    case "Port":
                        int port;
                        
                        if (!int.TryParse(Port, out port))
                        {
                            error="Please enter a valid integer";
                        }
                        else
                        {
                            if (port < 0)
                                error = "Invalid port number";
                        }
                        break;
                }
                return error;
            }

            
        }
        public IServerBinding GetServerBinding()
        {
            return new ServerBinding(HostName, int.Parse(Port), ReadOnly);
        }
    }
}
