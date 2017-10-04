using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magic;
using System.Diagnostics;

namespace AntiAfk
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackMagic wow = new BlackMagic();
            Console.WriteLine("Let the window remain open as long as you dont want to be flagged as AFK");
            while (true)
            {
                Process[] p = Process.GetProcessesByName("WoW");
                foreach (Process x in p)
                {
                    wow.OpenProcessAndThread(x.Id);
                    string version = wow.ReadASCIIString(0x00837C04, 6);
                    if (version == "1.12.1")
                    {
                        wow.WriteInt(0x00CF0BC8, Environment.TickCount);
                    }
                }
                System.Threading.Thread.Sleep(10000);
            }
        }
    }
}
