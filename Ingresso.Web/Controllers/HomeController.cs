using Ingresso.Data.Classes;
using System.Web.Mvc;

namespace Ingresso.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Privados

        private readonly IItemRepository _itemRepository;

        #endregion

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }

        #region Públicos

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        //
        // GET: /Index
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("Index", _itemRepository.GetAllItems());
        }

        //
        // GET: /About
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Esta aplicação tem o objetivo de demonstrar um pouco do meu conhecimento em desenvolvimento web e boas práticas de desenvolvimento de aplicações.";

            return View();
        }

        //
        // GET: /Contact
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        #endregion
    }
}
