using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using ZTSDemo.Dates;
using ZTSDemo.Devices;
using ZTSDemo.DeviceSimContracts;
using ZTSDemo.Manufacturers;
using ZTSDemo.Providers;
using ZTSDemo.Sims;

namespace ZTSDemo.EntityFrameworkCore;

//[ReplaceDbContext(typeof(IIdentityDbContext))]
//[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ZTSDemoDbContext :
    AbpDbContext<ZTSDemoDbContext>
    //IIdentityDbContext,
    //ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    public DbSet<Manufacturer> Manufacturers { get; private set; }
    public DbSet<Device> Devices { get; private set; }
    public DbSet<Date> Dates { get; private set; }

    public DbSet<Sim> Sims {  get; private set; }
    public DbSet<DeviceSimContract> SimContracs {  get; private set; }

    public DbSet<Provider> Providers {  get; private set; }



    public ZTSDemoDbContext(DbContextOptions<ZTSDemoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Date>(d =>
        {
            d.ToTable(ZTSDemoConsts.DbTablePrefix + "Dates",
                ZTSDemoConsts.DbSchema);
            d.ConfigureByConvention();
        });

        builder.Entity<Manufacturer>(ol =>
        {
            ol.ToTable(ZTSDemoConsts.DbTablePrefix + "Manufacturers",
                ZTSDemoConsts.DbSchema);
            ol.ConfigureByConvention();
            ol.Property(x => x.Name).IsRequired().HasMaxLength(64);
            ol.Property(x => x.DeviceType).IsRequired().HasMaxLength(64);

            // Define a unique index on the combination of Name and DeviceType
            ol.HasIndex(x => new { x.Name, x.DeviceType }).IsUnique();

        });

        builder.Entity<Provider>(ol =>
        {
            ol.ToTable(ZTSDemoConsts.DbTablePrefix + "Providers",
                ZTSDemoConsts.DbSchema);
            ol.ConfigureByConvention();
            ol.Property(x => x.Name).IsRequired().HasMaxLength(64);
            ol.Property(x => x.SimType).IsRequired().HasMaxLength(64);

            // Define a unique index on the combination of Name and DeviceType
            ol.HasIndex(x => new { x.Name, x.SimType }).IsUnique();

        });

        builder.Entity<Sim>(s =>
        {
            s.ToTable(ZTSDemoConsts.DbTablePrefix + "Sims",
                ZTSDemoConsts.DbSchema);
            s.ConfigureByConvention();

            s.HasOne<Provider>().WithMany().HasForeignKey(x => x.ProviderId).IsRequired();
        });


        builder.Entity<Device>(o =>
        {
            o.ToTable(ZTSDemoConsts.DbTablePrefix + "Devices",
                ZTSDemoConsts.DbSchema);
            o.ConfigureByConvention(); //auto configure for the base class props
           
            o.HasOne<Manufacturer>().WithMany().HasForeignKey(x => x.ManufacturerId).IsRequired();

        });

        builder.Entity<DeviceSimContract>(sc =>
        {
            sc.ToTable(ZTSDemoConsts.DbTablePrefix + "SimContracts",
                ZTSDemoConsts.DbSchema);
            sc.ConfigureByConvention();

            sc.HasOne<Sim>().WithMany().HasForeignKey(x => x.SimId).IsRequired();
            sc.HasOne<Device>().WithMany().HasForeignKey(x => x.DeviceId).IsRequired();
            sc.HasOne<Date>().WithMany().HasForeignKey(x => x.StartDateId).IsRequired();
            sc.HasOne<Date>().WithMany().HasForeignKey(x => x.EndDateId).IsRequired();

            //index?
        });


    }
}
