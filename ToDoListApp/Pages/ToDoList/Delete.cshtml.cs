using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoListApp.Data;

namespace ToDoListApp.Pages.ToDoList
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoListApp.Data.ApplicationDbContext _context;

        public DeleteModel(ToDoListApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoItem = await _context.ToDoItem.FirstOrDefaultAsync(m => m.ID == id);

            if (ToDoItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ToDoItem = await _context.ToDoItem.FindAsync(id);

            if (ToDoItem != null)
            {
                _context.ToDoItem.Remove(ToDoItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
