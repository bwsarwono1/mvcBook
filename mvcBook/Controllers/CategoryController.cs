using Microsoft.AspNetCore.Mvc;
using mvcBook.Data;
using mvcBook.Models;

namespace mvcBook.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _db.Categories; 
        return View(objCategoryList);
    }
    //Get
    public IActionResult Create()
    {
        
        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The DisplayOrder cannot be same data with the data Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0) 
        {
            return NotFound(); 
        }
        var categoryFromDB = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (categoryFromDB == null)
        {
            return NotFound();
        }
        return View(categoryFromDB);
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "The DisplayOrder cannot be same data with the data Name.");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDB = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
        if (categoryFromDB == null)
        {
            return NotFound();
        }
        return View(categoryFromDB);
    }
    //Post
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Categories.Find(id);
        if( obj == null)
        {
            return NotFound();
        }
        
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
        return RedirectToAction("Index");
        
        
    }
}
