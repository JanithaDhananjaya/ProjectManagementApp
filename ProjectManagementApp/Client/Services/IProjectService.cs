using ProjectManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApp.Client.Services
{
    public interface IProjectService
    {
        event Action OnChange;
        List<Project> Projects { get; set; }
        Task<List<Project>> GetProjects();
        Task<Project> GetProjectDetails(int id);
        Task<List<Project>> CreateProject(Project project);
        Task<List<Project>> UpdateProject(Project project, int id);
        Task<List<Project>> DeleteProject(int id);
    }
}
