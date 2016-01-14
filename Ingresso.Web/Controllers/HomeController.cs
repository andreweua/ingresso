using Ingresso.Data.Classes;
using System.Web.Mvc;

namespace Ingresso.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Privados

        private readonly IItemRepository _itemRepository;

        #endregion

        #region Públicos

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public ActionResult Index()
        {
            return View(_itemRepository.GetAllItems());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta aplicação tem o objetivo de demonstrar um pouco do meu conhecimento em desenvolvimento web e boas práticas de desenvolvimento de aplicações.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        #endregion
    }
}