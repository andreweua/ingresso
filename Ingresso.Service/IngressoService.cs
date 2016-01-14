using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using Ingresso.ViewModel.Classes;
using Newtonsoft.Json;
using System;
using System.Messaging;
using System.Net;
using System.ServiceProcess;
using System.Text;

namespace Ingresso.Service
{
    public partial class IngressoService : ServiceBase
    {
        #region Privados

        private const string _queue_name = @".\private$\sell";

        #endregion

        #region Protegidos

        protected override void OnStart(string[] args)
        {
            MainTimer.Start();
        }

        protected override void OnStop()
        {
            MainTimer.Stop();
        }

        #endregion

        #region Públicos

        public IngressoService()
        {
            InitializeComponent();
        }

        public void StartService(string[] args)
        {
            this.OnStart(args);
        }

        public void StopService()
        {
            this.OnStop();
        }

        public void RestartService(string[] args)
        {
            this.OnStop();
            this.OnStart(args);
        }

        public void PauseService()
        {
            this.OnPause();
        }

        public void ContinueService()
        {
            this.OnContinue();
        }

        #endregion

        private void MainTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MainTimer.Stop();

            // Recupera a última mensagem da fila.
            var queue = new MessageQueue(_queue_name);
            var message = queue.Receive().Body.ToString();

            // Deserializa o conteúdo da mensagem.
            var jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var dt = JsonConvert.DeserializeObject<ItemSoldViewModel>(message, jsonSerializerSettings);

            // Envia a mensagem para a MundiPagg.
            if (dt != null)
            {
                var transaction = new CreditCardTransaction()
                {
                    AmountInCents = (long)(dt.Value * 100),
                    CreditCard = new CreditCard()
                    {
                        CreditCardNumber = dt.CardNumber1 + dt.CardNumber2 + dt.CardNumber3 + dt.CardNumber4,
                        CreditCardBrand = CreditCardBrandEnum.Visa,
                        ExpMonth = dt.ExpMonth,
                        ExpYear = dt.ExpYear,
                        SecurityCode = dt.SecurityCode,
                        HolderName = dt.HolderName
                    }
                };

                var ok = true;

                try
                {
                    var serviceClient = new GatewayServiceClient();
                    var httpResponse = serviceClient.Sale.Create(transaction);

                    var createSaleResponse = httpResponse.Response;
                    if (httpResponse.HttpStatusCode == HttpStatusCode.Created)
                    {
                        foreach (var creditCardTransaction in createSaleResponse.CreditCardTransactionResultCollection)
                        {
                            //SendEmailOK();
                        }
                    }
                    else
                    {
                        if (createSaleResponse.ErrorReport != null)
                        {
                            foreach (ErrorItem errorItem in createSaleResponse.ErrorReport.ErrorItemCollection)
                            {
                                ok = false;
                            }
                        }
                    }
                }
                catch
                {
                    ok = false;
                }

                if (!ok)
                {
                    //SendEmailError();
                }
            }

            MainTimer.Start();
        }
    }
}
