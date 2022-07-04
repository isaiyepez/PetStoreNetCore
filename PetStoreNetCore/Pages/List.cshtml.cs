using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetStore.Data;

namespace PetStoreNetCore.Pages
{
    public class ListModel : PageModel
    {
        private readonly IPetStoreData _petStoreData;

        public ListModel(IPetStoreData petStoreData)
        {
            _petStoreData = petStoreData;
        }

        public void OnGet()
        {
        }
    }
}
