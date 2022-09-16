using System.Threading.Tasks;
using TodoApp;

public interface IIssueAppService
{
    Task<IssueDto> CreateAsync(IssueCreationDto input);
}