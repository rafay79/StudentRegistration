using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // CREATE
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    // READ - LIST
    [HttpGet]
    public async Task<IActionResult> Index(string? search)
    {
        var query = _context.Students
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();

            query = query.Where(s =>
                s.FirstName.Contains(search) ||
                s.LastName.Contains(search) ||
                s.Email.Contains(search) ||
                s.StudentId.Contains(search) ||
                s.Course.Contains(search));
        }

        var students = await query
            .OrderBy(s => s.FirstName)
            .ToListAsync();

        ViewBag.Search = search;

        return View(students);
    }


    // READ - DETAILS
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }


    // EDIT - GET
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }


    // EDIT - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        _context.Students.Update(student);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    // DELETE - GET
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }


    // DELETE - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Students.FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}