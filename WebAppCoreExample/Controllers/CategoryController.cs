using Microsoft.AspNetCore.Mvc;
using WebAppCoreExample.Data;
using WebAppCoreExample.Models;

namespace WebAppCoreExample.Controllers
{
    public class CategoryController : Controller
    {


        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            //pass it through inumerable
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);

        }


        //here we add get to call create method
        [HttpGet]
        public IActionResult Create()
        {

            //we have to make it empty for create
            
              return View();
              

        }
        [HttpPost]

        //here we add one validation for formsubmit to prevent sss token
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            //for serverside validation we use this
            if (ModelState.IsValid)
            {

                _context.Categories.Add(category);

                //here we add validation messgaae
                TempData["sucess"] = "Category created done";
                //savechanges for update database
                _context.SaveChanges();
            
            //yeh redirect karega action method index ko
            return RedirectToAction("Index");

            }
            return View(category);


        }





        [HttpGet]

       
        public IActionResult Edit(int? Id)
        {
            //for serverside validation we use this
            if (Id==null || Id==0)
            {

                return NotFound();
            }
            var category = _context.Categories.Find(Id);
            if (category == null) 
            {

                return NotFound();
            }
            return View(category);
            

        }


        [HttpPost]
        //here we add one validation for formsubmit to prevent sss token
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            //for serverside validation we use this
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);

                //savechanges for update database
                _context.SaveChanges();
                //here we add validation messgaae
                TempData["sucess"] = "Category Updated done!";

                //yeh redirect karega action method index ko
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }



        //delect section start here



        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            //for serverside validation we use this
            if (Id == null || Id == 0)
            {

                return NotFound();
            }
            var category = _context.Categories.Find(Id);
            if (category == null)
            {

                return NotFound();
            }
            return View(category);


        }


        [HttpPost, ActionName("Delete")]
       
        public IActionResult DeleteDate(int? Id)
        {

            var category = _context.Categories.Find(Id);
            if (category == null) 
            { 
                return NotFound();
            }
            
            _context.Categories.Remove(category);
            _context.SaveChanges();
            //here we add validation messgaae
            TempData["sucess"] = "Category Deleted done!";
            return RedirectToAction("Index");
           

        }

    }
}
