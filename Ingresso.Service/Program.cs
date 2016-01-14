using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace Ingresso.Service
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceName = new ProjectInstaller().ServiceName;
            var servicePath = Assembly.GetExecutingAssembly().Location;

            ServiceSelfInstaller.Execute(serviceName, servicePath, args.ToList(), () =>
            {
                var servicesToRun = new ServiceBase[] { new IngressoService() };
                ServiceBase.Run(servicesToRun);
            });
        }
    }
}
