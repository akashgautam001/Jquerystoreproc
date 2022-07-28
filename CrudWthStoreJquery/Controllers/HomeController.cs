using CrudWthStoreJquery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CrudWthStoreJquery.Controllers
{
    public class HomeController : Controller
    {
        DBhelper Db = new DBhelper();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contect()
        {
            List<Employess> Emplist = Db.Selectalldata().ToList();
            return View(Emplist);             
        }
        [HttpPost]
        public ActionResult Contect(Employess Emp ,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                string fu = Path.Combine(Server.MapPath("/Content/Pic"), Image.FileName);
                Emp.Image = Image.FileName;
                Image.SaveAs(fu);
                Db.InsertData(Emp, Image);
                ModelState.Clear();
                Response.Write("<script>alert('Data SuccessFully')</script>");
            }
            return RedirectToAction("Contect", "Home");

        }
        public ActionResult Delete(int Id)
        {
            Db.DeleteData(Id);
            Response.Write("<script>alert('Are You Sure You Want TO Delete')</script>");
            return RedirectToAction("Contect", "Home");
        }

    }
}
