using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListRazor.Controllers
{
     [Route("api/Employee")]
     [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _db.Employee.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var employeeFromDb = await _db.Employee.FirstOrDefaultAsync(u => u.Id == id);

            if(employeeFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });

            }
            _db.Employee.Remove(employeeFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}