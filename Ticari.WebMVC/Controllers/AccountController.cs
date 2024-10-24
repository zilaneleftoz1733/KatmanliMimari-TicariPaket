﻿using Microsoft.AspNetCore.Mvc;
using System.Data;
using Ticari.Entities.Entities.Concrete;
using Ticari.WebMVC.Models.VMs.Account;
using Ticari.BusinessLayer.Managers.Abstract;

namespace Ticari.WebMVC.Controllers
{
    public class AccountController(IManager<Role> roleManager, IManager<MyUser> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = userManager.GetAllInclude(null, p => p.Roller).ToList();
            return View(users);
        }

        public IActionResult UserInsert()
        {

            UserInsertVM userInsertVM = new UserInsertVM();
            return View(userInsertVM);
        }
        [HttpPost]
        public IActionResult UserInsert(UserInsertVM insertVM)
        {

            if (!ModelState.IsValid)
            {
                return View(insertVM);
            }
            // Burada insertvm MyUser sinifina çevrilmesi lazim

            #region Amele Yontemi

            MyUser myUser = new MyUser();
            myUser.Cinsiyet = insertVM.Cinsiyet;
            myUser.Ad = insertVM.Ad;
            myUser.Soyad = insertVM.Soyad;
            myUser.Email = insertVM.Email;
            myUser.TcNo = insertVM.TcNo;
            myUser.Gsm = insertVM.Gsm;
            myUser.CreateDate = DateTime.Now;
            myUser.Password = insertVM.Password;
            var role = roleManager.Get(p => p.RoleAdi == "user");

            myUser.Roller = new List<Role>();


            userManager.Create(myUser);
            myUser.Roller.Add(role);
            userManager.Update(myUser);


            #endregion

            // userManager.Create(insertVM);

            return RedirectToAction("Index", "Account");

        }
    }
}   