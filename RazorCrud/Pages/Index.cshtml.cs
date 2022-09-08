using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Data.Entities;

namespace RazorCrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public IndexModel(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public List<Cake> AllCakes = new List<Cake>();

        public async Task<IActionResult> OnGetAsync()
        {
            AllCakes = await _myWorldDbContext.Cake.ToListAsync();
            return Page();
        }
    }
}