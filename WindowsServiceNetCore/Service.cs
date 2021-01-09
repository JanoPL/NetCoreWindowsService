using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using Topshelf;

namespace WindowsServiceNetCore
{
    public class Service : ServiceControl
    {
        Timer timer = new Timer();
        public void Log(string message)
        {
            WriteToFile(message);
            
        }
        
        public bool Start(HostControl hostControl)
        {
            Log($"Start service at: {DateTime.Now}");

            timer.Elapsed += new ElapsedEventHandler((sender, e) => OnElapsedTime(sender, e, $"Service recall at: {DateTime.Now}"));
            timer.Interval = 5000;
            timer.Enabled = true;

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Log($"Stop service at: {DateTime.Now}");
            return true;
        }

        public void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\log.txt";
            if (!File.Exists(filePath)) {
                using(StreamWriter sw = File.CreateText(filePath)) {
                    sw.WriteLine(message);
                }
            } else {
                using (StreamWriter sw = File.AppendText(filePath)) {
                    sw.WriteLine(message);
                }
            }
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e, string message)
        {
            WriteToFile(message);
        }
    }
}
