using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeListRazor.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Employee.ToList() });
        }
    }
}