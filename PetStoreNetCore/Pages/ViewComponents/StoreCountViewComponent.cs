using Microsoft.AspNetCore.Mvc;
using PetStore.Data;

namespace PetStoreNetCore.Pages.ViewComponents
{
    public class StoreCountViewComponent : ViewComponent
    {
        private readonly IPetStoreData _petStoreData;

        public StoreCountViewComponent(IPetStoreData petStoreData)
        {
            _petStoreData = petStoreData;
        }

        public IViewComponentResult Invoke()
        {
            int count = _petStoreData.GetCountOfStores();

            return View(count);
        }
    }
}
