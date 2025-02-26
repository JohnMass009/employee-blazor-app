using EmployeeAPI.Contracts;
using EmployeeAPI.Contracts.Dto;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace EmployeeBlazorApp.Services;

public class EmployeeService(HttpClient httpClient, IOptions<AppSettings> appSettings)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(string sortColumn, bool ascending, int skip = 0, int take = 10)
    {
        var response = await _httpClient.GetAsync($"{_appSettings.EmployeeApiBaseUrl}api/employees?sortColumn={sortColumn}&ascending={ascending}&skip={skip}&take={take}");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<PaginatedList<EmployeeDto>>();

            return result ?? new PaginatedList<EmployeeDto>(new List<EmployeeDto>(), 0, skip / take, take);
        }
        else
        {
            Console.Error.WriteLine($"Ошибка при загрузке сотрудников: {response.StatusCode}");
            return new PaginatedList<EmployeeDto>(new List<EmployeeDto>(), 0, skip / take, take);
        }
    }

    public async Task<int> GetTotalEmployeesCountAsync()
    {
        var response = await _httpClient.GetAsync($"{_appSettings.EmployeeApiBaseUrl}api/employees?count=true");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }

        return 0;
    }
}
