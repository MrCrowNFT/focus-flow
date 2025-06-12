using System.Net.Http.Json;
using focus_flow.Shared.models;

public class TaskService
{
    private readonly HttpClient _http;

    public TaskService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<taskItem>> GetTasksAsync()
        => await _http.GetFromJsonAsync<List<taskItem>>("task") ?? new List<taskItem>();

    public async Task<taskItem?> GetTaskItemAsync(int id)
    {
        var response = await _http.GetAsync($"task/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<taskItem>();
    }

    public async Task<taskItem> CreateTaskAsync(taskItem task)
    {
        var response = await _http.PostAsJsonAsync("task", task);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<taskItem>()
                ?? throw new InvalidOperationException("Failed to create task");
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var response = await _http.DeleteAsync($"task/{id}");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return false;
        response.EnsureSuccessStatusCode();
        return true;
    }

    public async Task UpdateTaskAsync(int id, taskItem updatedTask)
    {
        var response = await _http.PutAsJsonAsync($"task/{id}", updatedTask);
        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            throw new ArgumentException("Invalid task data or ID mismatch");
        response.EnsureSuccessStatusCode();
    }
}