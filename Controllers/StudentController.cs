using DACA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DACA.Controllers
{
    [Route("/students")]
    public class StudentController : Controller
    {
        private readonly EduBD_context _context;
        public StudentController(EduBD_context context)
        {
            _context = context;
        }
        [HttpGet("")]       
        
        public async Task<IActionResult> Index()
        {
            var student = await _context.Students.ToArrayAsync();
            return View(student);
        }
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([Bind("id,StudentName")] Students @students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // nameof dùng để chuyển giá trị truyền vào thành string
            }
            return View(@students);
        }
        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (@student == null)
            {   
                return NotFound();
            }
            return View(@student);
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, StudentName")] Students @students)
        {
            if (id != @students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(@students.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@students);
        }
        private bool StudentExists(int id)
        {
            return _context.Classes.Any(e => e.id == id);
        }
    }   
}
