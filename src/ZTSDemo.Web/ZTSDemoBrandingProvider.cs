using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ZTSDemo.Web;

[Dependency(ReplaceServices = true)]
public class ZTSDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ZTSDemo";
}
