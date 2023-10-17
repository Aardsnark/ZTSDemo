using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Sims
{
    public class Sim: AggregateRoot<Guid>
    {
        public virtual Guid ProviderId { get; protected set; }

        protected Sim()
        {

        }

        public Sim(Guid id, Guid providerId)
            : base(id)
        {
            ProviderId = providerId;
        }
    }
}
