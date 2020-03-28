////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPADemoCRUD.Models;
using SPADemoCRUD.Models.view;

namespace SPADemoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AccessMinLevelAdmin")]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDataBaseContext _context;

        public DepartmentsController(AppDataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments([FromQuery] PaginationParameters pagingParameters)
        {
            pagingParameters.Init(_context.Departments.Count());
            IQueryable<DepartmentModel> departments = _context.Departments.OrderBy(x => x.Id);
            if (pagingParameters.PageNum > 1)
                departments = departments.Skip(pagingParameters.Skip);

            HttpContext.Response.Cookies.Append("rowsCount", pagingParameters.CountAllElements.ToString());
            return await departments.Take(pagingParameters.PageSize).ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetDepartmentModel(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);

            if (departmentModel == null)
            {
                return NotFound();
            }

            List<UserModel> usersByDepartment = await _context.Users.Where(x => x.DepartmentId == id).ToListAsync();

            return new { departmentModel.Id, departmentModel.Name, departmentModel.isDisabled, Users = usersByDepartment.Select(x => new { x.Id, x.Name, x.isDisabled }).ToList() };
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentModel(int id, DepartmentModel departmentModel)
        {
            if (!ModelState.IsValid)
            {
                return new ObjectResult(ModelState);
            }

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

            return new ObjectResult(new ServerActionResult()
            {
                Success = true,
                Info = "Изменения сохранены",
                Status = StylesMessageEnum.success.ToString(),
                Tag = departmentModel
            });
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> PostDepartmentModel(DepartmentModel departmentModel)
        {
            if (!ModelState.IsValid)
            {
                return new ObjectResult(ModelState);
            }

            _context.Departments.Add(departmentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartmentModel), new { id = departmentModel.Id }, departmentModel); ;
        }

        // PATCH: api/Departments/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchDepartmentModel(int id)
        {
            var departmentModel = await _context.Departments.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            departmentModel.isDisabled = !departmentModel.isDisabled;
            _context.Departments.Update(departmentModel);
            await _context.SaveChangesAsync();

            return new ObjectResult(new ServerActionResult()
            {
                Success = true,
                Info = "Объекту установлено новое состояние",
                Status = StylesMessageEnum.success.ToString(),
                Tag = departmentModel.isDisabled
            });
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentModel>> DeleteDepartmentModel(int id)
        {
            DepartmentModel departmentModel = await _context.Departments.FindAsync(id);
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
