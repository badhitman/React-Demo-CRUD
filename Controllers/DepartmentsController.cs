using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleSPA.Models;

namespace SimpleSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDataBaseContext _context;

        public DepartmentsController(AppDataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> GetDepartmentModel(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            return departmentModel;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(int id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
            _context.Departments.Add(departmentModel);
            await _context.SaveChangesAsync();

            return departmentModel;
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModel>> DeleteDepartmentModel(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(departmentModel);
            await _context.SaveChangesAsync();

            return departmentModel;
        }

        private bool DepartmentModelExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}