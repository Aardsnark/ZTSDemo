using Volo.Abp.Settings;

namespace ZTSDemo.Settings;

public class ZTSDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ZTSDemoSettings.MySetting1));
    }
}
