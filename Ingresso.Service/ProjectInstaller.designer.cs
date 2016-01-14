namespace Ingresso.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IngressoServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.IngressoServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // IngressoServiceInstaller
            // 
            this.IngressoServiceInstaller.ServiceName = "IngressoService";
            this.IngressoServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServiceProcessInstaller
            // 
            this.IngressoServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.IngressoServiceProcessInstaller.Password = null;
            this.IngressoServiceProcessInstaller.Username = null;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.IngressoServiceInstaller,
            this.IngressoServiceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller IngressoServiceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller IngressoServiceProcessInstaller;

    }
}
