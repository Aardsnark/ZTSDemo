using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using ZTSDemo.Devices;
using ZTSDemo.Manufacturers;

namespace ZTSDemo
{
    public class ZTSDemoDataSeederContributor: IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Manufacturer, Guid> _manufacturerRepository;
        private readonly IRepository<Device, Guid> _deviceRepository;
        private readonly IGuidGenerator _guidGenerator;

        public ZTSDemoDataSeederContributor(
            IRepository<Manufacturer, Guid> manufacturerRepository, 
            IRepository<Device, Guid> deviceRepository, 
            IGuidGenerator guidGenerator)
        {
            _manufacturerRepository = manufacturerRepository;
            _deviceRepository = deviceRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _deviceRepository.GetCountAsync() > 0)
            {
                return;
            }

            var manDev01 = await _manufacturerRepository.InsertAsync(
                new Manufacturer(_guidGenerator.Create(), "Manufacturer01", "outsideDevice01"));


            var dev01 = await _deviceRepository.InsertAsync(
                new Device(_guidGenerator.Create(), manDev01.Id));

        }
    }
}
