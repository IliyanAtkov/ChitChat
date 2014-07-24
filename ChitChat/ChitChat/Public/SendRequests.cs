using System;
using System.Net;
using System.Text;
using System.IO;
using System.Windows;

namespace ChitChat
{
    public class SendRequests
    {
        public void SendData(string URI, string data)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URI);
                httpRequest.Method = "POST";
                byte[] postBytes = Encoding.ASCII.GetBytes(data);
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.ContentLength = postBytes.Length;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream responseStream = httpResponse.GetResponseStream();

                var sr = new StreamReader(httpResponse.GetResponseStream());
                string responseText = sr.ReadToEnd();
            }
            catch (WebException)
            {
                MessageBox.Show("Please check your internet connection!");
            }
        }
    }
}
