using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOpen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process.Start("cmd.exe", "/C " + "ping -t google.com");
        }
    }
}
