using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace IssueTracking.Issues
{
    public class IssueManager : DomainService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueManager(IRepository<Issue, Guid> issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<Issue> CreateAsync(
            Guid repositoryId,
            string title,
            string text = null)
        {
            if (await _issueRepository.AnyAsync(i => i.Title == title))
            {
                throw new BusinessException("IssueTracking:IssueWithSameTitleExists");
            }

            return new Issue(
                GuidGenerator.Create(),
                repositoryId,
                title,
                text
            );
        }

        public async Task AssignToAsync(Issue issue, IdentityUser user)
        {
            var openIssueCount = await _issueRepository.CountAsync(
                i => i.AssignedUserId == user.Id && !i.IsClosed
            );

            if (openIssueCount >= 3)
            {
                throw new BusinessException("IssueTracking:ConcurrentOpenIssueLimit");
            }

            issue.AssignedUserId = user.Id;
        }

        public async Task ChangeTitleAsync(Issue issue, string title)
        {
            if (issue.Title == title)
            {
                return;
            }

            if (await _issueRepository.AnyAsync(i => i.Title == title))
            {
                throw new BusinessException("IssueTracking:IssueWithSameTitleExists");
            }

            issue.SetTitle(title);
        }
    }
}