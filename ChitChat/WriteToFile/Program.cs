using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter(null, UTF8Encoding);

            string path = "test.txt";
            int ln = 1;
            string writing = "App started..";

            using (writer)
            {
                writer.WriteLine(writing, path);
            }
        }
    }
}
