using System;
using Volo.Abp.Domain.Entities;

namespace IssueTracking.Issues
{
    public class AbpUserxxx : BasicAggregateRoot<Guid>
    {
        public string UserName { get; set; }
    }
}
