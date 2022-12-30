using System;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RecycleCoin.Business.Concrete;
using RecycleCoin.DataAccess.Concrete.EntityFramework;
using RecycleCoinMvc.Models;

namespace RecycleCoinMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly BlockchainSchema _blockchainSchema;

        public HomeController()
        {
            
            _blockchainSchema = new BlockchainSchema();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Listener()
        {
            BlockchainSchema blockchain = null;
            try
            {
                blockchain = _blockchainSchema.GetBlockchain();
                if (Session["blockByHash"] != null)
                {
                    ViewBag.blockByHash = Session["blockByHash"];
                }

            }
            catch (Exception)
            {
                // ignored
            }

            return PartialView("_blcoksListenerPartial", blockchain);

        }
        
    }
}