using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Peikko.Application.Attributes;
using Peikko.Core.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Peikko.Application.Components
{
    public class MenuViewComponent : ViewComponent
    { 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var types = PAttribute.GetTypesWithAttribute<MenuItemAttribute>()
                .Select(x => new MenuItem
                {
                    Name = x.Name.Replace("Controller", string.Empty).Pluralize(),
                    Controller = x.Name.Replace("Controller", string.Empty)
                });

            return View(types);
        }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public string Controller { get; set; }
    }
}
