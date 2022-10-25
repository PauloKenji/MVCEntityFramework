
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
        return View();
    }

    public IActionResult Create(){
                
        return View();
    }

    public IActionResult Creating([FromForm] int id, [FromForm] string number, [FromForm] string name, [FromForm] string sector){
        
        if(_context.Labs.Find(id) == null)
        {
            Lab lab = new Lab(id, number, name, sector);
            _context.Labs.Add(lab);
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Laboratorio já existente, tente outro id");
        }
       
    }

    public IActionResult Update([FromForm] int id, [FromForm] string number, [FromForm] string name, [FromForm] string sector){
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return Content("Laboratorio não existente, tente outro id");
        }
        else
        {
            lab.Number = number;
            lab.Name = name;
            lab.Sector = sector;

            return Content("Atualizado com sucesso");
        }

    }
}