using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using ZTSDemo.Devices;

namespace ZTSDemo.Manufacturers
{
    public class Manufacturer : AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        //DeviceType candidate enum from Shared
        public virtual string DeviceType { get; protected set; }
        protected Manufacturer() 
        { 

        }

        public Manufacturer(Guid id, string name, string deviceType)
            :base(id) 
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(deviceType, nameof(deviceType));

            Name = name;
            DeviceType = deviceType;
        }

    }


}
