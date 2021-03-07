using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTP.Test.JDM.BackEnd.API.Models;

namespace BTP.Test.JDM.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly BTPJDMContext _context;

        public StudentsController(BTPJDMContext context)
        {
            _context = context;
        }

        // GET: Students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _context.Students.ToList();
        }

        // GET: Students/Details/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _context.Students.FirstOrDefault(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Post([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return new CreatedAtRouteResult(new { id = student.Id }, student);
        }


        //// POST: Students
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birth")] Student student)
        //{
        //    if (id != student.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(student);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentExists(student.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(student);
        //}

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    _context.Students.Remove(student);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Id == id);
        //}
    }
}
