using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Santa_Stefania_Lab2.Data;
using Santa_Stefania_Lab2.Models;

namespace Santa_Stefania_Lab2.Pages.Books
{
    public class CreateModel : PageModel
    {
       
        private readonly Santa_Stefania_Lab2.Data.Santa_Stefania_Lab2Context _context;

        public CreateModel(Santa_Stefania_Lab2.Data.Santa_Stefania_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "LastName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            if (!ModelState.IsValid)
            {
                
                return Page();
                
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
