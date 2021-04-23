using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Models;
using ToDoListApp.Data;

namespace ToDoListApp.Pages.ToDoList
{
    public class CreateModel : PageModel
    {
        private readonly ToDoListApp.Data.ApplicationDbContext _context;

        public CreateModel(ToDoListApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoItem.Add(ToDoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
