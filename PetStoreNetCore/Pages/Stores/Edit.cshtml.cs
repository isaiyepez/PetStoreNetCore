using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Data;
using PetStoreNetCore.Core;
using System.Collections.Generic;
using static PetStoreNetCore.Core.Store;

namespace PetStoreNetCore.Pages.Stores
{
    public class EditModel : PageModel
    {
        private readonly IPetStoreData _petStoreData;
        //We are injecting the IHtmlHelper in the constructor to be able to render
        //the select options with the information inside our enumerable object for countries.
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Store Store { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        public EditModel(IPetStoreData petStoreData,
                         IHtmlHelper htmlHelper)
        {
            _petStoreData = petStoreData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? storeId)
        {
            Countries = _htmlHelper.GetEnumSelectList<Countries>();

            if (storeId.HasValue)
            {
                Store = _petStoreData.GetStoreById(storeId.Value);

                if (Store == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Store = new Store();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Countries = _htmlHelper.GetEnumSelectList<Countries>();
                return Page();             
            }

            if (Store.Id > 0)
            {
                _petStoreData.Update(Store);
            }
            else
            {
                _petStoreData.Add(Store);
            }
            
            _petStoreData.Commit();
            TempData["Message"] = "Store Saved!";
            return RedirectToPage("./Detail", new { storeId = Store.Id });
        }
    }
}
