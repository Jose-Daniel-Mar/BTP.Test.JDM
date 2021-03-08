using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            //var studentA = new StudentA();
            //var assignments = _context.Assignments.ToList();

            //var assignmentsStudents = _context.AssignmentsStudents.Where(x => x.IdStudent == id).ToList();

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

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student student)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Remove(student);
            _context.SaveChanges();
            return student;
        }
    }
}
