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
    public class IndexModel : PageModel
    {
        private readonly ToDoListApp.Data.ApplicationDbContext _context;

        public IndexModel(ToDoListApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToDoItem> ToDoItem { get;set; }

        public async Task OnGetAsync()
        {
            ToDoItem = await _context.ToDoItem.ToListAsync();
        }
    }
}
