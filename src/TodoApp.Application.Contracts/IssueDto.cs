using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApp
{

    // *** IssueCreationDto class ***
    public class IssueCreationDto
    {
        public Guid RepositoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid? AssignedUserId { get; set; }
        public string Text { get; set; }
    }

    public class UpdateIssueDto
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid? AssignedUserId { get; set; }
    }

    public class IssueDto
    {
        [Required]
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid? AssignedUserId { get; set; }
    }
}
