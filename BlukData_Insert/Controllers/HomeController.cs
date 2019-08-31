using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlukData_Insert.Models;
using BlukData_Insert.Models.DemoContaxt;

namespace BlukData_Insert.Controllers
{
    public class HomeController : Controller
    {
        private readonly DmContext _context;

        public HomeController(DmContext dmContext)
        {
            this._context = dmContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BulkData()
        {

            //This is only show by defualt, one for insert the data to the Database


            List<ContactInfo> model = new List<ContactInfo>()
            {
                new ContactInfo
                {
                     ID=0, Address="", Name=""
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BulkData(List<ContactInfo>ci)
        {
            if(ModelState.IsValid)
            {
                using(_context)
                {
                    foreach (var i in ci)
                    {
                        _context.ContactInfos.Add(i);
                    }
                    _context.SaveChanges();

                    ViewBag.Message = "Data Saved Successfully";
                    ModelState.Clear();

                    ci =new List<ContactInfo>{new ContactInfo { ID=0, Address="", Name=""}};
                }  
            }
            return View(ci);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
