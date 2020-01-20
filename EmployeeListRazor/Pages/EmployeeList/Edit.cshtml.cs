using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeListRazor
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]  
        public Employee Employee { get; set; }
        public async Task OnGet(int id)
        {
            Employee = await _db.Employee.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()  //using iactionresult because of redirection
        {
            if (ModelState.IsValid)
            {
                var EmployeeFromDb = await _db.Employee.FindAsync(Employee.Id);
                EmployeeFromDb.Name = Employee.Name;
                EmployeeFromDb.Department = Employee.Department;
                EmployeeFromDb.Position = Employee.Position;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}