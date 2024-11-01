using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
                                , IManager<Role> roleManager
                                , IHostEnvironment hostEnvironment) : Controller
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
        public async Task<IActionResult> UserInsert(UserInsertVM insertVM)
        {

            if (!ModelState.IsValid)
            {

                notyfService.Error("Düzeltilmesi gereken yerler var");
                return View(insertVM);
            }

            #region Fotograf Kaydetme
            string uploads = "";
            string userImagePAth = "";
            if (insertVM.Picture != null
                && (insertVM.Picture.ContentType.Contains("image/jpeg") || insertVM.Picture.ContentType.Contains("image/png")))
            {
                //Dosya ismin alma 
                var fileName = Path.GetFileName(insertVM.Picture.FileName);
                //Dosya Extension bulma
                var extension = Path.GetExtension(fileName);
                //Birlestirme işlemi 
                var newFileName = string.Concat(Guid.NewGuid().ToString(), extension);
                userImagePAth = $@"/images/{newFileName}";
                uploads = Path.Combine(hostEnvironment.ContentRootPath, $@"wwwroot/images/{newFileName}");
                string filePath = Path.Combine(uploads, newFileName);
                using (var fileStream = new System.IO.FileStream(uploads, FileMode.Create))
                {
                    await fileStream.CopyToAsync(fileStream);
                }
            }
            #endregion
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
            myUser.PhotoPath = userImagePAth;
            #endregion

            //var myUser = mapper.Map<MyUser>(insertVM);
            try
            {
                userManager.Create(myUser);
                myUser.Roller = new List<Role>();

                #region Kullaniciya check edilen rollerin atanmasi
                foreach (var item in insertVM.Roller.Where(p => p.IsChecked == true).ToList())
                {
                    var role = roleManager.GetById(item.Id);
                    myUser.Roller.Add(role);
                }
                // user role db'den cekilir


                userManager.Update(myUser);
            }
            catch (SqlException sqlException)
            {

                notyfService.Error("Hata Olustu :" + sqlException.InnerException);
                return View(insertVM);
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message.Split(".")[2];
                notyfService.Error("Hata Olustu :" + message);
                return View(insertVM);
            }

            #endregion
            notyfService.Success("Islem Basarili");



            // userManager.Create(insertVM);

            return RedirectToAction("Index", "User", new { Area = "Admin" });

        }

        public IActionResult GetUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = userManager.GetAllInclude(p => p.Email == email, p => p.Roller).FirstOrDefault();

            return View(user);
        }
    }
}