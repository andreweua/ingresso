using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Windows.Forms;

namespace Ingresso.Service
{
    public static class ServiceSelfInstaller
    {
        #region Privados

        private static readonly string _msg01 = "Realmente deseja desinstalar o serviço \"{0}\"?";
        private static readonly string _msg02 = "Aviso";
        private static readonly string _msg03 = "O serviço \"{0}\" foi desinstalado com sucesso.";
        private static readonly string _msg04 = "Informação";
        private static readonly string _msg05 = "Realmente deseja instalar o serviço \"{0}\"?";
        private static readonly string _msg06 = "O serviço \"{0}\" foi instalado com sucesso.";

        private static bool InstallService(string serviceName)
        {
            var ret = true;

            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { serviceName });
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        private static bool UninstallService(string serviceName)
        {
            var ret = true;

            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", serviceName });
            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        #endregion

        #region Públicos

        public static void Execute(string serviceName, string serviceFileName, List<string> argumentList, Action execToStart)
        {
            var installed = false;
            var started = false;
            var silence = false;

            #region Passo 1: Verifica argumentos de linha de comandos

            if (argumentList != null && argumentList.Count > 0)
            {
                foreach (var item in argumentList)
                {
                    if (item.ToUpper() == "/S")
                    {
                        silence = true;
                    }
                }
            }

            #endregion

            #region Passo 2: Verifica se o serviço já está em execução

            var serviceList = ServiceController.GetServices();

            foreach (var service in serviceList)
            {
                if (service.ServiceName.Equals(serviceName))
                {
                    installed = true;

                    if (service.Status == ServiceControllerStatus.StartPending) // O serviço foi iniciado pelo SCM.
                    {
                        started = true;
                    }

                    break;
                }
            }

            #endregion

            #region Passo 3: Instala/Desinstala o serviço

            if (!started)
            {
                if (installed)
                {
                    var confirmed = (silence ||
                        MessageBox.Show(string.Format(_msg01, serviceName), _msg02, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
                    if (confirmed)
                    {
                        UninstallService(serviceFileName);
                        if (!silence)
                        {
                            MessageBox.Show(string.Format(_msg03, serviceName), _msg04, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    var confirmed = (silence ||
                        MessageBox.Show(string.Format(_msg05, serviceName), _msg02, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
                    if (confirmed)
                    {
                        InstallService(serviceFileName);
                        if (!silence)
                        {
                            MessageBox.Show(string.Format(_msg06, serviceName), _msg04, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

            #endregion

            #region Passo 4: Inicia o serviço pelo SCM

            else if (execToStart != null)
            {
                execToStart();
            }

            #endregion
        }

        #endregion
    }
}
