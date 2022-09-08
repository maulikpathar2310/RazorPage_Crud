using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrud.Data;
using RazorCrud.Data.ViewModel;

namespace RazorCrud.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public DeleteModel(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        public string ErrorMessage { get; set; }
        public CakeVm? CakeVm { get; set; }
        public async Task<IActionResult> OnGetAsync(int id, bool? saveChangesError)
        {
            CakeVm = await _myWorldDbContext.Cake
                    .Where(_ => _.Id == id)
                    .Select(_ =>
                    new CakeVm
                    {
                        Description = _.Description,
                        Id = _.Id,
                        Name = _.Name,
                        Price = _.Price
                    }).FirstOrDefaultAsync();

            if (CakeVm == null)
            {
                return NotFound();
            }
            if (saveChangesError ?? false)
            {
                ErrorMessage = $"Error to delete the record id - {id}";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var recordToDelete = await _myWorldDbContext.Cake.FindAsync(id);

            if (recordToDelete == null)
            {
                return Page();
            }

            try
            {
                _myWorldDbContext.Cake.Remove(recordToDelete);
                await _myWorldDbContext.SaveChangesAsync();
                return Redirect("./home");
            }
            catch
            {
                return Redirect($"./delete?id={id}&saveChangesError=true");
            }
        }
    }
}
