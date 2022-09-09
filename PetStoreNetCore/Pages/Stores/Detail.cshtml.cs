using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetStore.Data;
using PetStoreNetCore.Core;

namespace PetStoreNetCore.Pages.Stores
{
    public class DetailModel : PageModel
    {
        private readonly IPetStoreData _storesData;

        [TempData]
        public string Message { get; set; }
        public Store Store { get; set; }

        public DetailModel(IPetStoreData storesData)
        {
            _storesData = storesData;
        }
        public IActionResult OnGet(int storeId)
        {
            Store = _storesData.GetStoreById(storeId);

            if (Store == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}
