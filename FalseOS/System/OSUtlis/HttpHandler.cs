using Cosmos.System.Network.IPv4.UDP.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using CosmosHttp.Client;

namespace FalseOS.System.OSUtlis
{
    public class HttpHandler
    {
        private static string GetPathFromURL(String url)
        {
            int start;
            if (url.Contains("://"))
                start = url.IndexOf("://") + 3;
            else
                start = 0;

            int ios = url.IndexOf('/',start);
            if (ios != -1) return url.Substring(ios);
            else return "/";
        }

        public static String GetDomainNameFromURL(String url)
        {
            int start;
            if (url.Contains("://"))
                start = url.IndexOf("://") + 3;
            else
                start = 0;

            int end = url.IndexOf("/",start);
            if (end != -1)
                end = url.Length;
            return url[start..end];
        }

        public static string downloadFile(String url)
        {
            if (url.StartsWith("https"))
            {
                WriteMessage.writeError("HTTPS protocol not supported yet!");
                return "";
            }

            string path = GetPathFromURL(url);
            string domainName = GetDomainNameFromURL(url);

            var dns = new DnsClient();
            dns.Connect(DNSConfig.DNSNameservers[0]);
            dns.SendAsk(domainName);
            Address addres = dns.Receive();
            dns.Close();

            HttpRequest rq = new();
            rq.IP = addres.ToString();
            rq.Domain = domainName;
            rq.Path = path;
            rq.Method = "GET";
            rq.Send();

            return rq.Response.Content;
        }
    }
}
