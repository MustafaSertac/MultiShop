using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponenetPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
