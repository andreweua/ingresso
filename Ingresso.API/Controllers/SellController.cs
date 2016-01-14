using Ingresso.ViewModel.Classes;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ingresso.API.Controllers
{
    public class SellController : ApiController
    {
        // POST: /Sell
        public HttpResponseMessage Post([FromBody]ItemSoldViewModel value)
        {
            var queue_name = @".\private$\sell";
            MessageQueue queue;

            if (MessageQueue.Exists(queue_name))
            {
                queue = new MessageQueue(queue_name);
            }
            else
            {
                queue = MessageQueue.Create(queue_name);
            }

            queue.Send(value);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
