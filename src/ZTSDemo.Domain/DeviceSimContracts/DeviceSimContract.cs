using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.DeviceSimContracts
{
    public class DeviceSimContract: AggregateRoot<Guid>
    {
        public virtual Guid SimId { get; protected set; }
        public virtual Guid DeviceId { get; protected set; }
        public virtual Guid StartDateId { get; protected set; }
        public virtual Guid EndDateId {  get; protected set; }



        protected DeviceSimContract() { }

        public DeviceSimContract(Guid id, Guid simID, Guid deviceID, Guid startDateId, Guid endDateId)
            : base(id)
        {
            SimId = simID;
            DeviceId = deviceID;
            StartDateId = startDateId;
            EndDateId = endDateId;
        }


    }
}
