using System;
using System.Linq;
using System.Web.Mvc;
using RecycleCoinMvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;
using RecycleCoin.Entities.Concrete;

namespace RecycleCoinMvc.Controllers
{
    public class TransactionController : Controller
    {
        private BlockchainSchema _blockchainSchema;

        public TransactionController()
        {
            _blockchainSchema = new BlockchainSchema();
        }

        // GET: Transaction
        [Authorize]
        public ActionResult CreateTransaction()
        {
            var _usermanager = new UserManager<AppUser>(new UserStore<AppUser>(new RecycleCoinDbContext()));
            var user = _usermanager.FindByIdAsync(HttpContext.User.Identity.GetUserId()).Result;
            var balanceOfMyAddress = _blockchainSchema.GetBalanceOfAddress(user.PublicKey);
            var totalBalance = balanceOfMyAddress + user.ConvertedCarbon;
            ViewBag.BalanceOfMyAddress = balanceOfMyAddress;
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    var formamount = Request.Form["amount"];
                    var amount = Convert.ToInt32(formamount);
                    _blockchainSchema = _blockchainSchema.GetBlockchain();
                    var fromAddress = user.PrivateKey;
                    var toAddress = Request.Form["toAddress"];
                    if (_usermanager.Users.FirstOrDefault(u => u.PublicKey == toAddress) == null) //göndemek istediği kullanıcı var mı yok mu ?
                    {
                        Session["toast"] = new Toastr("İşlem", "İşleminiz Başarısız! Göndermek istediğiniz adrese ait kullanıcı bulunamadı!", "warning");
                        return View(user);
                    }
                    var balanceOfToAddress = _blockchainSchema.GetBalanceOfAddress(toAddress);

                    if (toAddress.Equals(user.PublicKey)) // kişi kendi adresine mi Rc göndermeye çalışıyor
                    {
                        Session["toast"] = new Toastr("İşlem", "İşleminiz Başarısız! göndermek istediğiniz adres sizin adresiniz!", "warning");
                        return View(user);
                    }

                    if (balanceOfToAddress + amount >= 100000000) //RC miktarı 100M ile sınırlandırıldı.
                    {
                        Session["toast"] = new Toastr("İşlem", "İşleminiz başarısız RC sınırı aşıldı!", "danger");
                        return View(user);
                    }


                    if (amount > totalBalance) // toplam bakiye
                    {
                        Session["toast"] = new Toastr("İşlem", "İşleminiz başarısız RC bakiyesi yetersiz!", "warning");
                        return View(user);

                    }
                    _blockchainSchema.AddTransaction(fromAddress,toAddress,amount.ToString());
                    Session["toast"] = new Toastr("İşlem", "İşleminiz başarıyla gerçekleştirildi", "success");
                }
                catch (Exception)
                {
                    Session["toast"] = new Toastr("İşlem", "İşleminiz Başarısız!", "danger");
                }

            }


            return View(user);
        }

        public ActionResult PendingTransaction()
        {
            try
            {
                _blockchainSchema = _blockchainSchema.GetBlockchain();
                var pendingTransactions = _blockchainSchema.pendingTransactions;
                return View(pendingTransactions);
            }
            catch (Exception)
            {
                Session["toast"] = new Toastr("İşlem", "Bekleyen işlemleri görüntülerken bir hata oluştu! Lütfen daha sonra tekrar deneyin", "danger");
                return RedirectToAction("Index", "Home");
            }
        }
        [Authorize]
        public ActionResult MinePendingTransaction()
        {
            try
            {
                var user = new UserManager<AppUser>(new UserStore<AppUser>(new RecycleCoinDbContext())).FindByIdAsync(User.Identity.GetUserId()).Result;
                _blockchainSchema = _blockchainSchema.GetBlockchain();
                var balance_of_toAddress = _blockchainSchema.GetBalanceOfAddress(user.PublicKey);

                var miningReward = _blockchainSchema.miningReward;

                if ((balance_of_toAddress + miningReward) >= 100000000) //RC miktarı 100M ile sınırlandırıldı.
                {
                    Session["toast"] = new Toastr("Kazı", "Kazı işleminiz başarısız RC sınırı aşıldı!", "danger");
                    return RedirectToAction("PendingTransaction");
                }

                _blockchainSchema.MinePendingTransactions(user.PublicKey);

                Session["toast"] = new Toastr("Kazı", "Kazı işleminiz başarıyla gerçekleştirildi.", "success");

            }
            catch (Exception)
            {
                Session["toast"] = new Toastr("Kazı", "Kazı işleminiz başarısız.", "danger");
                return RedirectToAction("PendingTransaction");
            }



            return RedirectToAction("Index", "Home");
        }

    }
}