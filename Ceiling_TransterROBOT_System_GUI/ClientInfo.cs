using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ceiling_TransterROBOT_System_GUI
{
    public class ClientInfo
    {
        public Socket TcpClient { get; set; }
        public int ClientId { get; set; }

        public ClientInfo(Socket tcpClient)
        {
            this.TcpClient = tcpClient;
            this.ClientId = 0;
        }
    }
}
