
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ticari.BusinessLayer.Managers.Abstract;
using Ticari.Entities.Entities.Concrete;
using Ticari.WebMVC.Models.VMs.Account;

namespace Ticari.WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController(IManager<MyUser> userManager
                                , INotyfService notyfService
                                , IMapper mapper
                                , IManager<Role> roleManager) : Controller
    {
        public IActionResult Index()
        {
            var users = userManager.GetAllInclude(null, p => p.Roller).ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult UserInsert()
        {

            UserInsertVM userInsertVM = new UserInsertVM();
            var roller = roleManager.GetAll();
            foreach (var role in roller)
            {
                CheckBoxVM checkBoxVM = new CheckBoxVM()
                {
                    Id = role.Id,
                    LabelName = role.RoleAdi,
                    IsChecked = false
                };
                userInsertVM.Roller.Add(checkBoxVM);

            }
            return View(userInsertVM);
        }
        [HttpPost]
        public IActionResult UserInsert(UserInsertVM insertVM)
        {

            if (!ModelState.IsValid)
            {

                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(insertVM);
            }
            // Burada insertvm MyUser sinifina çevrilmesi lazim

            #region Amele Yontemi

            //MyUser myUser = new MyUser();
            //myUser.Cinsiyet=insertVM.Cinsiyet;
            //myUser.Ad=insertVM.Ad;
            //myUser.Soyad=insertVM.Soyad;
            //myUser.Email=insertVM.Email;
            //myUser.TcNo=insertVM.TcNo;
            //myUser.Gsm=insertVM.Gsm;
            //myUser.CreateDate=DateTime.Now;
            //myUser.Password=insertVM.Password;
            #endregion

            var myUser = mapper.Map<MyUser>(insertVM);
            userManager.Create(myUser);

            #region Kullaniciya Default olarak user rolü eklenir


            var role = roleManager.Get(p => p.RoleAdi == "user"); // user role db'den cekilir
            myUser.Roller = new List<Role>();
            myUser.Roller.Add(role);
            userManager.Update(myUser);
            #endregion
            notyfService.Success("Islem Basarili");



            // userManager.Create(insertVM);

            return RedirectToAction("Index", "Account", new { Area = "Admin" });

        }

        public IActionResult GetUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = userManager.GetAllInclude(p => p.Email == email, p => p.Roller).FirstOrDefault();

            return View(user);
        }
    }
}
