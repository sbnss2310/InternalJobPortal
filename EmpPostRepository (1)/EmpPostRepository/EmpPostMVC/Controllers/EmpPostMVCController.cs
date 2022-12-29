using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmpPostMVC.Models;
using EmpPostRepository;
namespace EmpPostMVC.Controllers
{
    public class EmpPostMVCController : Controller
    {

        EmpPostClient client = new EmpPostClient();

        // GET: EmpPostMVC
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<EmpPost> posts =await  client.GetAllEmpPost();
            return View(posts);
        }

        // GET: EmpPostMVC/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(string postId)
        {
            EmpPost post = await client.GetEmpByIdAsync(postId);
            
            return View(post);
        }

        // GET: EmpPostMVC/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmpPostMVC/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmpPost empPost)
        {
            try
            {
                await client.InsertEmpAsync(empPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpPostMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpPostMVC/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(string postId, EmpPost empPost)
        {
            try
            {
                await client.UpdateEmpAsync(postId, empPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpPostMVC/Delete/5
        public ActionResult Delete(string postId)
        {
            return View();
        }

        // POST: EmpPostMVC/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(string postId, EmpPost empPost)
        {
            try
            {
                await client.DeleteEmpAsync(postId);
                return RedirectToAction("Index");
            }
            catch { return View();
            }
        }
    }
}
