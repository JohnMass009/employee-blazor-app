using EmployeeAPI.Contracts;
using EmployeeAPI.Contracts.Dto;
using System.Net.Http.Json;

namespace EmployeeBlazorApp.Services;

public class EmployeeService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("EmployeeApi");

    public async Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(string sortColumn, bool ascending, int skip = 0, int take = 10)
    {
        var response = await _httpClient.GetAsync($"/api/employees?sortColumn={sortColumn}&ascending={ascending}&skip={skip}&take={take}");


        if (!response.IsSuccessStatusCode)
        {
            Console.Error.WriteLine($"Ошибка при загрузке сотрудников: {response.StatusCode}");
            return new PaginatedList<EmployeeDto>([], 0, 0, take);
        }

        var result = await response.Content.ReadFromJsonAsync<PaginatedList<EmployeeDto>>();
        return result ?? new PaginatedList<EmployeeDto>([], 0, 0, take);
    }

    public async Task<int> GetTotalEmployeesCountAsync()
    {
        return await _httpClient.GetFromJsonAsync<int>($"/api/employees?count=true");
    }
}
