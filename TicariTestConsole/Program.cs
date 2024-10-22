using System;
using System.IO;
using Ticari.Entities.DBContexts;
using Ticari.Entities.Entities.Concrete;
namespace TicariTestConsole
{
   
    public class Program
    {
        static void Main(string[] args)
        {
            SQLDbContext sqlDb = new();
            Category icecek = new Category
            {
                CategoryName = "Icecek",
                CreateDate = DateTime.Now,
                Description ="Icecek"

            };
            Product ayran = new Product()
            {
                ProductCode = "001.002",
                ProductName = "Sutas Ayran",
                Amount = 100,
                UnitPrice = 50,
                Categories= new List<Category>{icecek}
            };
            sqlDb.Products.Add(ayran);
            sqlDb.SaveChanges();
            


        //    var sr = File.OpenText(@"C:\Users\SABAH\Downloads\veri\116m_gsm.sql");
        //    var flag = false;
        //    Int64 sayac = 0;
        //    List<Gsm116>gsmlist = new List<Gsm116>();

        //    while (sr.Read() > 0)
        //    {
        //        var line = sr.ReadLine();
        //        if (line.Contains("INSERT"))
        //        {
        //            flag = true;
        //            if (flag)
        //            {
        //                var satir = sr.ReadLine();
        //                Gsm116 gsm116 = new Gsm116();
        //                gsm116.Gsm = satir.Split(',')[1].Split("'")[1];
        //                gsm116.TcNo = satir.Split(',')[0].Substring(2, 11);
        //                gsmlist.Add(gsm116);

        //            }

        //        }
                
        //        Console.WriteLine(line);
        //    }
        //    Console.WriteLine("Hello, World!");
        }
    }

}
