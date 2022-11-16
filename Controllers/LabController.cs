
using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController (LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Labs);

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return RedirectToAction("Index"); 
        }

        return View(lab);
    }

    public IActionResult Delete(int id){
        _context.Labs.Remove(_context.Labs.Find(id));
        _context.SaveChanges();
        return View();  
    }

    public IActionResult Create(){
                
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] int id, [FromForm] string number, [FromForm] string name, [FromForm] string sector){
        
        if(!ModelState.IsValid){
            return View();
        }
        if(_context.Labs.Find(id) == null)
        {
            Lab lab = new Lab(id, number, name, sector);
            _context.Labs.Add(lab);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        else
        {
           return Content("Laboratorio já existente, tente outro id");
        }
       
    }

    
    public IActionResult Update(int id){
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return Content("Laboratorio não existente, tente outro id");
        }
        else
        {
            return View(lab);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] int id, [FromForm] string number, [FromForm] string name, [FromForm] string sector){
        if(!ModelState.IsValid){
            return View();
        }
        
        Lab lab = _context.Labs.Find(id);
        
        lab.Number = number;
        lab.Name = name;
        lab.Sector = sector;
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
}