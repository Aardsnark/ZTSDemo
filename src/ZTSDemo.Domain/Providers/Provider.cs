using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Providers
{
    public class Provider: AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual string SimType { get; protected set;}

        protected Provider ()
        {

        }

        public Provider (Guid id, string name, string simType)
            : base(id)
        {
            Check.NotNull(name, nameof(name));
            Check.NotNull(simType, nameof(simType));

            Name = name;
            SimType = simType;
        }
    }
}
