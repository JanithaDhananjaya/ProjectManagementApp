using ProjectManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectManagementApp.Client.Services
{
    public class ProjectService : IProjectService
    {

        private readonly HttpClient _httpClinet;

        public ProjectService(HttpClient httpClinet)
        {
            _httpClinet = httpClinet;
        }

        public List<Project> Projects { get; set; } = new List<Project>();

        public event Action OnChange;

        public async Task<List<Project>> CreateProject(Project project)
        {
            var result = await _httpClinet.PostAsJsonAsync<Project>($"api/project", project);
            Projects = await result.Content.ReadFromJsonAsync<List<Project>>();
            OnChange.Invoke();
            return Projects;
        }

        public async Task<List<Project>> DeleteProject(int id)
        {
            var result = await _httpClinet.DeleteAsync($"api/project/{id}");
            Projects = await result.Content.ReadFromJsonAsync<List<Project>>();
            OnChange.Invoke();
            return Projects;
        }

        public async Task<Project> GetProjectDetails(int id)
        {
            return await _httpClinet.GetFromJsonAsync<Project>($"api/project/{id}");
        }

        public async Task<List<Project>> GetProjects()
        {
           Projects =  await _httpClinet.GetFromJsonAsync<List<Project>>("api/project");
            return Projects;
        }

        public async Task<List<Project>> UpdateProject(Project project, int id)
        {
            var result = await _httpClinet.PutAsJsonAsync<Project>($"api/project/{id}", project);
            Projects = await result.Content.ReadFromJsonAsync<List<Project>>();
            OnChange.Invoke();
            return Projects;
        }
    }
}
