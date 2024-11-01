using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Ticari.BusinessLayer.Managers.Concrete;
using Ticari.Entities.DBContexts;
using Ticari.Entities.Entities.Concrete;
namespace Ticari.TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Thread thread = new Thread(() => { Console.WriteLine("Thread 1"); });

            Thread thread2 = new Thread(() => { Console.WriteLine("Thread 2"); });
            thread2.Start();
            thread.Start();



            //var sr =  File.OpenText(@"c:\Shared\116m_gsm.sql");
            // while (sr.Read()>0)
            // {
            //     var line = sr.ReadLine();
            //     Console.WriteLine(line);
            // }
            // Console.WriteLine("Hello, World!");


            //  AddProductWithCategory();

            //UpdateWithProductCategory();
            //AddUserAndRole();
            //AddNewRole();

            // AddRoleForUser();
            RemoveRoleForUser();
        }
        public static void AddRoleForUser()
        {
            Manager<MyUser> userManager = new Manager<MyUser>();
            Manager<Role> roleManager = new Manager<Role>();
            //aliye admin hakki verme
            var ali = userManager.GetAllInclude(p => p.Ad == "ali", p => p.Roller).FirstOrDefault();
            var admin = roleManager.Get(p => p.RoleAdi == "admin");

            ali.Roller.Add(admin);
            userManager.Update(ali);
        }
        public static void RemoveRoleForUser()
        {
            SQLDbContext sqlDbContext = new SQLDbContext();

            Manager<MyUser> userManager = new Manager<MyUser>();
            Manager<Role> roleManager = new Manager<Role>();
            //aliye admin hakki verme
            var ali = userManager.GetAllInclude(p => p.Ad == "ali", p => p.Roller).FirstOrDefault();
            var admin = roleManager.Get(p => p.RoleAdi == "user");

            ali.Roller.RemoveAll(p => p.RoleAdi == admin.RoleAdi);
            userManager.Update(ali);
        }
        public static void AddNewRole()
        {
            Manager<Role> roleManager = new Manager<Role>();
            Manager<MyUser> userManager = new Manager<MyUser>();
            var ali = userManager.GetAllInclude(p => p.Ad == "ali", p => p.Roller).FirstOrDefault();
            var adminRole = roleManager.Get(p => p.RoleAdi == "admin");
            ali.Roller.Add(adminRole);
            userManager.Update(ali);


        }
        public static void AddUserAndRole()
        {

            MyUser user = new MyUser()
            {
                Ad = "admin",
                Soyad = "admin",
                TcNo = "12312312311",
                Email = "admin@admin.com",
                Password = "qweasd",
                Cinsiyet = false,
                Gsm = "5321112233",
                CreateDate = DateTime.Now

            };
            Manager<Role> roleManager = new Manager<Role>();
            Role role = new Role() { RoleAdi = "admin", CreateDate = DateTime.Now };
            role.Users = new List<MyUser>() { user };

            roleManager.Create(role);


        }
        private static void UpdateWithProductCategory()
        {
            // Varolan bir product'a varolan bir category Ekleme
            //Once Product CEkilir
            SQLDbContext sqlDb = new();

            // Burasi category'leri getirmediginden dolayi hatalidir
            //var product = sqlDb.Products.Where(p => p.ProductName == "Ekmek").FirstOrDefault();
            var product = sqlDb.Products.Include(p => p.Categories).Where(p => p.ProductName == "Ekmek").FirstOrDefault();

            if (product != null)
            {


                //Eklenecek olan category bulunur 
                var category = sqlDb.Categories.Where(p => p.CategoryName == "Icecek").FirstOrDefault();
                if (category != null)
                {
                    product.Categories.Add(category);
                    sqlDb.Products.Update(product);
                    sqlDb.SaveChanges();
                }
            }
        }

        public static void AddProductWithCategory()
        {
            SQLDbContext sqlDb = new();
            Category icecek = new Category
            {
                CategoryName = "Icecek",
                CreateDate = DateTime.Now,
                Description = "Icecek"
            };
            Product ayran = new Product()
            {
                ProductCode = "001.002",
                ProductName = "Sutas Ayran",
                Amount = 100,
                UnitPrice = 50,
                Categories = new List<Category> { icecek }

            };
            sqlDb.Products.Add(ayran);
            sqlDb.SaveChanges();
        }
    }
}