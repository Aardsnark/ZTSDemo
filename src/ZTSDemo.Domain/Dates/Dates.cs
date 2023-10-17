using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ZTSDemo.Dates
{
    public class Date : AggregateRoot<Guid>
    {
        public virtual DateTime? Datetime { get; protected set; }
        public virtual int Year { get; protected set; }
        public virtual int Month { get; protected set; }
        public virtual int Day { get; protected set;}
        public virtual int Hour { get; protected set; }

        protected Date()
        {

        }

        public Date(Guid id)
            : base(id)
        {

        }
    }
}
