using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTP.Test.JDM.BackEnd.API.Models;

namespace BTP.Test.JDM.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly BTPJDMContext _context;

        public AssignmentsController(BTPJDMContext context)
        {
            _context = context;
        }

        // GET: Assignments
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> Get()
        {
            return _context.Assignments.ToList();
        }

        // GET: Assignment/Details/5
        [HttpGet("{id}")]
        public ActionResult<Assignment> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments.Include(x => x.AssignmentsStudents).FirstOrDefault(m => m.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Post([FromBody] Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
            return new CreatedAtRouteResult(new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Assignment> Delete(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(x => x.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            _context.Remove(assignment);
            _context.SaveChanges();
            return assignment;
        }
    }
}
