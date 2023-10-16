using ZTSDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ZTSDemo.Web.Pages;

public abstract class ZTSDemoPageModel : AbpPageModel
{
    protected ZTSDemoPageModel()
    {
        LocalizationResourceType = typeof(ZTSDemoResource);
    }
}
