using DBL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kefisinventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly BL bl;
        public ProductController()
        {
            bl = new BL(Util.GetDbConnString());
        }
        public async Task<IActionResult> Productlist()
        {
            var data = await bl.Getallproductslist();
            return View(data);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Makeasale(long id)
        {
            var resp = await bl.Makeasale(id);
            return RedirectToAction("Productlist");
        }

        public async Task<IActionResult> Productreorderunprocessedlist()
        {
            var data = await bl.Productreorderunprocessedlist();
            return View(data);
        }
        public async Task<IActionResult> Productreorderprocessedlist()
        {
            var data = await bl.Productreorderprocessedlist();
            return View(data);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Makeadispatch(long id, long productid,int quantity)
        {
            var resp = await bl.Makeadispatch(id, productid, quantity);
            return RedirectToAction("Productreorderprocessedlist");
        }
    }
}
