using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Sims
{
    public class SimContract: Entity
    {
        public virtual Guid SimId { get; protected set; }
        public virtual Guid DeviceId { get; protected set; }
        public virtual Guid StartDateId { get; protected set; }
        public virtual Guid EndDateId {  get; protected set; }



        protected SimContract() { }

        public SimContract(Guid simID, Guid deviceID, Guid startDateId, Guid endDateId)
        {
            SimId = simID;
            DeviceId = deviceID;
            StartDateId = startDateId;
            EndDateId = endDateId;
        }

        public override object[] GetKeys()
        {
            return new Object[] { SimId, DeviceId };
        }

    }
}
