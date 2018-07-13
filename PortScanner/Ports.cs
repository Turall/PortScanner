using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PortScanner
{
    public class Ports
    {
        public int PortNum { get; set; }
        public string Local { get; set; }
        public string Remote { get; set; }
        public string State { get; set; }

        public Ports(int pn,string local,string remote,string stat)
        {
            PortNum = pn;
            Local = local;
            Remote = remote;
            State = stat;
        }

        public static List<Ports> GetPortInfo()
        {
            IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endPoints = globalProperties.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnection = globalProperties.GetActiveTcpConnections();

            return tcpConnection.Select(t =>
            {
                return new Ports(
                    pn: t.LocalEndPoint.Port,
                    local: String.Format("{0}:{1}", t.LocalEndPoint.Address, t.LocalEndPoint.Port),
                    remote: String.Format("{0} : {1}", t.RemoteEndPoint.Address, t.RemoteEndPoint.Port),
                    stat: t.State.ToString());
            }).ToList();

        }
    }
}
