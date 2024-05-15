using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    public class Servers
    {
        private static Servers instance;
        private static readonly object lockObject = new object();

        private List<string> serverList;

        private Servers()
        {
            serverList = new List<string>();
        }

        // Ленивый синглтон
        public static Servers Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Servers();
                        }
                    }
                }
                return instance;
            }
        }

        public bool AddServer(string server)
        {
            if (string.IsNullOrWhiteSpace(server) || (!server.StartsWith("http://") && !server.StartsWith("https://")))
            {
                return false;
            }

            lock (lockObject)
            {
                if (!serverList.Contains(server))
                {
                    serverList.Add(server);
                    return true;
                }
            }

            return false;
        }

        public List<string> GetHttpServers()
        {
            List<string> httpServers = new List<string>();
            lock (lockObject)
            {
                foreach (string server in serverList)
                {
                    if (server.StartsWith("http://"))
                    {
                        httpServers.Add(server);
                    }
                }
            }
            return httpServers;
        }

        public List<string> GetHttpsServers()
        {
            List<string> httpsServers = new List<string>();
            lock (lockObject)
            {
                foreach (string server in serverList)
                {
                    if (server.StartsWith("https://"))
                    {
                        httpsServers.Add(server);
                    }
                }
            }
            return httpsServers;
        }
    }
}
