using EmployeeAPI.Contracts.Dto;

namespace EmployeeAPI.Contracts.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(string sortColumn, bool ascending, int skip, int take);
        Task<int> GetTotalEmployeesCountAsync();
        Task<EmployeeDto?> GetByIdAsync(Guid id);
    }
}