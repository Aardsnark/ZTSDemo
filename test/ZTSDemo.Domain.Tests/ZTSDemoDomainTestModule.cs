using ZTSDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ZTSDemo;

[DependsOn(
    typeof(ZTSDemoEntityFrameworkCoreTestModule)
    )]
public class ZTSDemoDomainTestModule : AbpModule
{

}
