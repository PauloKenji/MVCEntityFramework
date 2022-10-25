
using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController (LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Computers);

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return RedirectToAction("Index");
        }

        return View(computer);
    }

    public IActionResult Delete(int id){
        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();
        return View();
    }

    public IActionResult Create(){
                
        return View();
    }

    public IActionResult Creating([FromForm] int id, [FromForm] string ram, [FromForm] string processor){
        
        if(_context.Computers.Find(id) == null)
        {
            Computer computer = new Computer(id,ram,processor);
            _context.Computers.Add(computer);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
           return Content("Computador já existente, tente outro id");
        }
       
    }

    public IActionResult Update(int id){
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return Content("Computador não existente, tente outro id");
        }
        else
        {
            return View(computer);
        }

    }

    public IActionResult Updating([FromForm] int id, [FromForm] string ram, [FromForm] string processor){
        Computer computer = _context.Computers.Find(id);
        
        computer.Ram = ram;
        computer.Processor = processor;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}