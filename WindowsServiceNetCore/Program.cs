using System;
using Topshelf;

namespace WindowsServiceNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(service => {
                service.Service<Service>();
                service.EnableServiceRecovery(recover => recover.RestartService(TimeSpan.FromSeconds(10)));
                service.SetServiceName("WindowsServiceNetCore");
                service.SetDescription("An example of a Windows service on Net Core");
                service.StartAutomatically();
            });
        }
    }
}
