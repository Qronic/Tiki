using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace tikiServer
{
    class serverClient
    {
        string ipAddy = "";
        string userName = "";
        int permissionLevel = -5;
        public int connectionID = -11;
        public TcpClient myClientInfo { get; private set; }

        public serverClient(TcpClient clientInfo, int connID)
        {
            myClientInfo = clientInfo;
            connectionID = connID;
        }
       

    }
}
