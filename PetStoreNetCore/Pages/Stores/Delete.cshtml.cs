using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetStore.Data;
using PetStoreNetCore.Core;

namespace PetStoreNetCore.Pages.Stores
{
    public class DeleteModel : PageModel
    {
        private readonly IPetStoreData _storeData;

        public Store StoreToDelete { get; set; }
        public DeleteModel(IPetStoreData storeData)
        {
            _storeData = storeData;
        }
        public IActionResult OnGet(int storeID)
        {
            StoreToDelete = _storeData.GetStoreById(storeID);
            if (StoreToDelete == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int storeID)
        {
            var store = _storeData.Delete(storeID);
            _storeData.Commit();

            if(store == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{store.StoreName} deleted";
            return RedirectToPage("./List");
        }
    }
}
