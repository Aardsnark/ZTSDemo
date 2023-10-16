using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Devices
{
    public class Device : AggregateRoot<Guid>
    {
        public virtual Guid ManufacturerId { get; protected set; }

        protected Device ()
        {

        }

        public Device (Guid id, Guid manufacturerId)
            : base(id)
        {
            ManufacturerId = manufacturerId;
        }
    }
}
