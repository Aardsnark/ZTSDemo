using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ZTSDemo.Data;

/* This is used if database provider does't define
 * IZTSDemoDbSchemaMigrator implementation.
 */
public class NullZTSDemoDbSchemaMigrator : IZTSDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
