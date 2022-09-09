using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetStore.Data;
using PetStoreNetCore.Core;
using System.Collections;
using System.Collections.Generic;

namespace PetStoreNetCore.Pages
{
    public class ListModel : PageModel
    {
        private readonly IPetStoreData _petStoreData;
        public IEnumerable<Store> Stores { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IPetStoreData petStoreData)
        {
            _petStoreData = petStoreData;
        }

        public void OnGet(string SearchTerm)
        {
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Stores = _petStoreData.GetPetStores();
            } else
            {                
                Stores = _petStoreData.GetStoresByName(SearchTerm);
            }
        }
    }
}
