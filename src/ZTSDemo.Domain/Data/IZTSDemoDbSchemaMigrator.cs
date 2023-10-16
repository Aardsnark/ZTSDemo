using System.Threading.Tasks;

namespace ZTSDemo.Data;

public interface IZTSDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
