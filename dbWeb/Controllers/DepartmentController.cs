using dbWeb.Data;
using dbWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly DatabaseAPIContext _context;

        public DepartmentController(DatabaseAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department != null)
            {
                return Ok(department);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Insert([Bind("Name,Budget")] Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return Ok(department);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, Department department)
        {
            var dbDepartment = await _context.Departments.FindAsync(id);

            if (dbDepartment != null)
            {
                dbDepartment.Name = department.Name;
                dbDepartment.Budget = department.Budget;

                await _context.SaveChangesAsync();

                return Ok(department);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department != null)
            {
                _context.Remove(department);
                await _context.SaveChangesAsync();
                return Ok(department);
            }

            return NotFound();
        }
    }
}
