using System;
using System.Collections.Generic;
using System.Text;
using ZTSDemo.Localization;
using Volo.Abp.Application.Services;

namespace ZTSDemo;

/* Inherit your application services from this class.
 */
public abstract class ZTSDemoAppService : ApplicationService
{
    protected ZTSDemoAppService()
    {
        LocalizationResource = typeof(ZTSDemoResource);
    }
}
