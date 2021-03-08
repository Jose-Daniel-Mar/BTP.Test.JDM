using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTP.Test.JDM.BackEnd.API.Models;

namespace BTP.Test.JDM.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsStudentsController : ControllerBase
    {
        private readonly BTPJDMContext _context;

        public AssignmentsStudentsController(BTPJDMContext context)
        {
            _context = context;
        }

        // GET: Assignments
        [HttpGet]
        public ActionResult<IEnumerable<AssignmentsStudent>> Get()
        {
            return _context.AssignmentsStudents.ToList();
        }

        // GET: Assignment/Details/5
        [HttpGet("{id}")]
        public ActionResult<AssignmentsStudent> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var assignmentsStudent = _context.AssignmentsStudents.FirstOrDefault(m => m.Id == id);
            if (assignmentsStudent == null)
            {
                return NotFound();
            }

            return assignmentsStudent;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AssignmentsStudent assignmentsStudent)
        {
            _context.AssignmentsStudents.Add(assignmentsStudent);
            _context.SaveChanges();
            return new CreatedAtRouteResult(new { id = assignmentsStudent.Id }, assignmentsStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult<AssignmentsStudent> Delete(int id)
        {
            var assignmentsStudent = _context.AssignmentsStudents.FirstOrDefault(x => x.Id == id);

            if (assignmentsStudent == null)
            {
                return NotFound();
            }

            _context.Remove(assignmentsStudent);
            _context.SaveChanges();
            return assignmentsStudent;
        }
    }
}
