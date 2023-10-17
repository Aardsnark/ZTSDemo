using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Configurations
{
    public class DeviceConfig: AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }
        public virtual Guid PublicationDateId { get; protected set; }
        public virtual Guid ExpirationDateId { get; protected set; }

        protected DeviceConfig()
        {

        }

        public DeviceConfig(Guid id, string name, Guid publicationDateId)
            : base(id)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
            PublicationDateId = publicationDateId;
        }

        public DeviceConfig(Guid id, string name, Guid publicationDateId, Guid expirationDateId)
    : base(id)
        {
            Check.NotNull(name, nameof(name));
            Name = name;
            PublicationDateId = publicationDateId;
            ExpirationDateId = expirationDateId;
        }
    }
}
