using System;
using RecycleCoin.Business.Concrete;
using RecycleCoin.DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecycleCoin.Entities.Concrete;
using RecycleCoinMvc.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using RecycleCoin.DataAccess.Concrete.EntityFramework.Contexts;

namespace RecycleCoinMvc.Areas.Admin.Controllers
{
    public class RecycleCenterController : Controller
    {
        // GET: Admin/RecycleCenter
        private readonly CategoryManager _categoryManager;
        private readonly ProductManager _productManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly UserRecycleItemManager _userRecycleItemManager;

        public RecycleCenterController()
        {
            _categoryManager = new CategoryManager(new EfCategoryDal());
            _productManager = new ProductManager(new EfProductDal());
            _userRecycleItemManager = new UserRecycleItemManager(new EfUserRecycleItemDal());
            var userStore = new UserStore<AppUser>(new RecycleCoinDbContext());
            _userManager = new UserManager<AppUser>(userStore);

        }
        public ActionResult Index()
        {
            ViewBag.categories = _categoryManager.GetList();
            return View();
        }


        public ActionResult GetProductsByCategory(int categoryId)
        {
            Session["products"] = _productManager.GetListByCategory(categoryId);

            return PartialView("_productsPartial");
            //return productManager.GetListByCategory(categoryId);
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = _productManager.GetById(productId);
            var list = Session["cartItems"] as List<CartItem>;
            list ??= new List<CartItem>();
            list.Add(new CartItem(product, quantity));
            Session["cartItems"] = list;
            return PartialView("_cartPartial");
            //return productManager.GetListByCategory(categoryId);
        }

        public ActionResult RemoveFromCart(int productId, int amount)
        {
            var cartItems = Session["cartItems"] as List<CartItem>;

            foreach (var cartItem in cartItems)
            {
                if (cartItem.product.Id == productId && cartItem.amount == amount)
                {
                    cartItems.Remove(cartItem);
                    break;
                }
            }

            Session["cartItems"] = cartItems;

            return PartialView("_cartPartial");

        }

        public ActionResult RecyleItems(string toAddress, int totalCarbon)
        {
            var cartitems = Session["cartItems"] as List<CartItem>;
            var user = _userManager.Users.FirstOrDefault(u => u.PublicKey == toAddress);
            if (cartitems == null) return RedirectToAction("Index");
            if (user != null)
            {
                user.Carbon += totalCarbon;
                _userManager.Update(user);

                if (Session["cartItems"] is List<CartItem> cartlist)
                    foreach (var cartItem in cartlist)
                    {
                        _userRecycleItemManager.Add(new UserRecycleItem()
                        {
                            ProductId = cartItem.product.Id,
                            Amount = cartItem.amount,
                            UserId = user.Id,
                            RecycleCarbon = cartItem.product.Carbon * cartItem.amount,
                            RecycleDate = DateTime.Now,
                        });
                    }
                Session["toast"] = new Toastr("Geri Dönüşüm", $"{user.Name} {user.Lastname} kullanıcısına {totalCarbon} karbon eklemesi yapıldı.!", "warning");
                Session.Remove("cartItems");
            }
            else
            {
                Session["toast"] = new Toastr("Geri Dönüşüm", $"Kullanıcı bulunamadı lütfen kullanıcı adresini kontrol ediniz!", "danger");
            }

            return RedirectToAction("Index");
        }

        public ActionResult QrCodeGetResult(string response)
        {


            var findsProducts = _productManager.GetList()
                .FindAll(p => p.Name.ToLower().Contains(response.ToLower()));

            Session["products"] = findsProducts;
            return RedirectToAction("Index", "RecycleCenter");

        }

        public ActionResult GetUserFromAddress(string toAddress)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.PublicKey == toAddress);
            return PartialView("_getUserFromAddressPartial", user);
        }
    }
}