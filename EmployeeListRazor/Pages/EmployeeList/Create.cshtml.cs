using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeListRazor
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] //this binds the employee object below to post so that you don't have to type onPost(Employee employeeOBJ)
        public Employee Employee { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Employee.AddAsync(Employee);
                await _db.SaveChangesAsync(); //this pushes changes to database
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }

        }
    }


}