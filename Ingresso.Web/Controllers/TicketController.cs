using Ingresso.Data.Classes;
using Ingresso.ViewModel.Classes;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ingresso.Web.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        #region Privados

        private readonly IItemRepository _itemRepository;

        private string _urlNewTicket
        {
            get
            {
                string ret;
                try
                {
                    ret = ConfigurationManager.AppSettings["UrlNewTicket"];
                }
                catch
                {
                    ret = string.Empty;
                }

                return ret;
            }
        }

        #endregion

        #region Públicos

        public TicketController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        //
        // GET: /Ticket/New
        public ActionResult New(Guid id)
        {
            if (id != Guid.Empty)
            {
                ViewBag.Item = _itemRepository.GetItem(id);
                return View();
            }

            return View("Index");
        }

        //
        // POST: /Ticket/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New(ItemSoldViewModel itemSold)
        {
            if (ModelState.IsValid)
            {
                var ok = true;

                #region Envia a requisição

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "utf-8");
                        client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Ingresso");
                        client.Timeout = TimeSpan.FromSeconds(30);

                        var jsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                        var body = JsonConvert.SerializeObject(itemSold, jsonSerializerSettings);

                        var resposta = await client.PostAsync(_urlNewTicket, new StringContent(body, Encoding.UTF8, "application/json"));
                        ok = (resposta.StatusCode == System.Net.HttpStatusCode.OK);
                    }
                }
                catch
                {
                }

                #endregion
            }

            return View("NewConfirmation");
        }

        //
        // GET: /Ticket/NewConfirmation
        [AllowAnonymous]
        public ActionResult NewConfirmation()
        {
            return View();
        }

        #endregion
    }
}
