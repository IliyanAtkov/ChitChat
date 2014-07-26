using System;
using System.Net;
using System.IO;

namespace ChitChat.Private
{
    public static class Misc
    {
        public static string GetCurrentIPAddr()
        {
            string uri = Constants.IPCHECK_URI;
            WebRequest req = WebRequest.Create(uri);
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
        }
    }
}
