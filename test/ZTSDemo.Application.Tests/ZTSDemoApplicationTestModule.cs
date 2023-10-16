using Volo.Abp.Modularity;

namespace ZTSDemo;

[DependsOn(
    typeof(ZTSDemoApplicationModule),
    typeof(ZTSDemoDomainTestModule)
    )]
public class ZTSDemoApplicationTestModule : AbpModule
{

}
