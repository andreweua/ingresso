using System.ComponentModel;
using System.Configuration.Install;

namespace Ingresso.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public const string AppTitle = "Serviço de Ingressos";

        public string ServiceName
        {
            get
            {
                return IngressoServiceInstaller.ServiceName;
            }
        }

        public ProjectInstaller()
        {
            InitializeComponent();

            this.IngressoServiceInstaller.Description = AppTitle;
            this.IngressoServiceInstaller.DisplayName = AppTitle;
        }
    }
}
