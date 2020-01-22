using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Test()
        {
            UserModel data = new UserModel()
            {
                Peroid1 = new List<Model>(),
                Peroid2 = new List<Model>(),
                Peroid3 = new List<Model>(),
                Peroid4 = new List<Model>()
            };
            ListDirectory list= Service.Main();

            //List<Model> users = new List<UserModel>();
            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;
                
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid1.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test2.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid2.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test3.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid3.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}

            //using (var sr = new StreamReader(new FileStream(@"C:\Users\User\source\repos\WebApplication1\WebApplication1\Test4.txt", FileMode.Open, FileAccess.Read, FileShare.Read)))
            //{
            //    string line;

            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        string[] splits = line.Split(',');
            //        if (splits.Length > 1)
            //        {
            //            data.Peroid4.Add(new Model
            //            {
            //                name = splits[0],
            //                song = splits[1]
            //            }
            //            );
            //        }
            //    }
            //}


            return Json(list);
        }
    }

public class UserModel
{
    public List<Model> Peroid1 { get; set; }
    public List<Model> Peroid2 { get; set; }
    public List<Model> Peroid3 { get; set; }
    public List<Model> Peroid4 { get; set; }
}

public class Model
{
    public string name { get; set; }
    public string song { get; set; }
}

}