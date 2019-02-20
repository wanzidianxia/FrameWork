using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCF_HostService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServerHost.RunServer.Run();
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
    }
}
