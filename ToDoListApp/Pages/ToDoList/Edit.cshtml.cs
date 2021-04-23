using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoListApp.Data;

namespace ToDoListApp.Pages.ToDoList
{
    public class EditModel : PageModel
    {
        private readonly ToDoListApp.Data.ApplicationDbContext _context;

        public EditModel(ToDoListApp.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(ToDoItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoItemExists(int id)
        {
            return _context.ToDoItem.Any(e => e.ID == id);
        }
    }
}
