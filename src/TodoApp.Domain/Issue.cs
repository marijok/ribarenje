using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace IssueTracking.Issues
{
    public class Issue : BasicAggregateRoot<Guid>
    {
        public Guid RepositoryId { get; private set; }
        public string Title { get; private set; }
        public string Text { get; set; }
        public Guid? AssignedUserId { get; internal set; }
        public bool IsClosed { get; internal set; }
        

        public Issue(
            Guid id,
            Guid repositoryId,
            string title,
            string text = null
            ) : base(id)
        {
            RepositoryId = repositoryId;
            SetTitle(title);
            Text = text; //Allow empty/null
        }

        private Issue() { /* Empty constructor is for ORMs */ }

        internal void SetTitle(string title)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        }
    }
}