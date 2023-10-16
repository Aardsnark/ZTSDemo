using ZTSDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ZTSDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ZTSDemoController : AbpControllerBase
{
    protected ZTSDemoController()
    {
        LocalizationResource = typeof(ZTSDemoResource);
    }
}
