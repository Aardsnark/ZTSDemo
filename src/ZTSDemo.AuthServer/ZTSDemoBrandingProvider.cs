using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ZTSDemo;

[Dependency(ReplaceServices = true)]
public class ZTSDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ZTSDemo";
}
