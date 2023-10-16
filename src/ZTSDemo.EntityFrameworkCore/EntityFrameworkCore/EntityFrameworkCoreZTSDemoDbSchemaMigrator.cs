using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZTSDemo.Data;
using Volo.Abp.DependencyInjection;

namespace ZTSDemo.EntityFrameworkCore;

public class EntityFrameworkCoreZTSDemoDbSchemaMigrator
    : IZTSDemoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreZTSDemoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the ZTSDemoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ZTSDemoDbContext>()
            .Database
            .MigrateAsync();
    }
}
