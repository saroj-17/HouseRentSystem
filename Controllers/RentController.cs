using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

public class RentController : Controller
{
    private readonly ApplicationDbContext _context;
    private RentController(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public IActionResult Index()
    {
        var rents = _context.Rents.ToList();
        return View(rents);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Rent rent)
    {
        if (ModelState.IsValid)
        {
            _context.Rents.Add(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(rent);

    }

    //For Edit 

    public IActionResult Edit(int id)
    {
        var rent = _context.Rents.Find(id);
        if (rent == null) return NotFound();

        return View(id);
    }


    [HttpPost]
    public IActionResult Edit(Rent rent)
    {
        if (ModelState.IsValid)
        {
            _context.Rents.Update(rent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(rent);
    }

    public IActionResult Delete(int id)
    {
        var rent = _context.Rents.Find(id);
        if (rent != null)
        {
            _context.Rents.Remove(rent);
            _context.SaveChanges();

        }
        return RedirectToAction("Index");
    }
}