using ZTSDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ZTSDemo.Permissions;

public class ZTSDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ZTSDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ZTSDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ZTSDemoResource>(name);
    }
}
