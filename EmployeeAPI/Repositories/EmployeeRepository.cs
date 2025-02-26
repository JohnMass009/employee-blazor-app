using AutoMapper;
using EmployeeAPI.Contracts;
using EmployeeAPI.Contracts.Dto;
using EmployeeAPI.Contracts.Interfaces;
using EmployeeAPI.Domain.Models;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository(IMapper mapper) : IEmployeeRepository
    {
        private readonly IMapper _mapper = mapper;

        private readonly List<Employee> _employees =
        [
            new() { FirstName = "Анастасия", LastName = "Морозова", Position = "Маркетолог" },
            new() { FirstName = "Дмитрий", LastName = "Попов", Position = "Системный администратор" },
            new() { FirstName = "Иван", LastName = "Иванов", Position = "Менеджер" },
            new() { FirstName = "Петр", LastName = "Морозов", Position = "Аналитик" },
            new() { FirstName = "Юлия", LastName = "Кузнецова", Position = "Программист" },
            new() { FirstName = "Дмитрий", LastName = "Сидоров", Position = "Дизайнер" },
            new() { FirstName = "Сергей", LastName = "Смирнов", Position = "Технический писатель" },
            new() { FirstName = "Анастасия", LastName = "Романова", Position = "Менеджер" },
            new() { FirstName = "Анна", LastName = "Иванова", Position = "Менеджер" },
            new() { FirstName = "Елена", LastName = "Смирнова", Position = "HR" },
            new() { FirstName = "Сергей", LastName = "Иванов", Position = "Тестировщик" },
            new() { FirstName = "Елена", LastName = "Романова", Position = "Программист" },
            new() { FirstName = "Сергей", LastName = "Петров", Position = "Разработчик" },
            new() { FirstName = "Мария", LastName = "Смирнова", Position = "Технический писатель" },
            new() { FirstName = "Алексей", LastName = "Лебедев", Position = "Маркетолог" },
            new() { FirstName = "Мария", LastName = "Смирнова", Position = "Тестировщик" },
            new() { FirstName = "Анастасия", LastName = "Лебедева", Position = "Программист" },
            new() { FirstName = "Иван", LastName = "Петров", Position = "Разработчик" },
            new() { FirstName = "Сергей", LastName = "Александров", Position = "Маркетолог" },
            new() { FirstName = "Елена", LastName = "Морозова", Position = "Маркетолог" },
            new() { FirstName = "Петр", LastName = "Смирнов", Position = "Дизайнер" },
            new() { FirstName = "Анастасия", LastName = "Кузнецова", Position = "Программист" },
            new() { FirstName = "Анна", LastName = "Александрова", Position = "Маркетолог" },
            new() { FirstName = "Дмитрий", LastName = "Сидоров", Position = "HR" },
            new() { FirstName = "Юлия", LastName = "Лебедева", Position = "Разработчик" },
            new() { FirstName = "Иван", LastName = "Лебедев", Position = "Менеджер" },
            new() { FirstName = "Юлия", LastName = "Морозова", Position = "HR" },
            new() { FirstName = "Дмитрий", LastName = "Петров", Position = "Маркетолог" },
            new() { FirstName = "Сергей", LastName = "Смирнов", Position = "Разработчик" },
            new() { FirstName = "Анна", LastName = "Попова", Position = "Системный администратор" },
            new() { FirstName = "Мария", LastName = "Морозова", Position = "Аналитик" },
            new() { FirstName = "Юлия", LastName = "Иванова", Position = "Менеджер" },
            new() { FirstName = "Мария", LastName = "Смирнова", Position = "Дизайнер" },
            new() { FirstName = "Дмитрий", LastName = "Иванов", Position = "HR" },
            new() { FirstName = "Анна", LastName = "Морозова", Position = "Аналитик" },
            new() { FirstName = "Сергей", LastName = "Романова", Position = "Программист" },
            new() { FirstName = "Юлия", LastName = "Петрова", Position = "Тестировщик" },
            new() { FirstName = "Елена", LastName = "Сидорова", Position = "Менеджер" },
            new() { FirstName = "Сергей", LastName = "Смирнов", Position = "Технический писатель" }
        ];

        public Task<EmployeeDto?> GetByIdAsync(Guid id) => Task.FromResult(_mapper.Map<EmployeeDto>( _employees.FirstOrDefault(e => e.Id == id)) ?? null);

        public Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(
            string sortColumn, bool ascending, int skip, int take)
        {
            var sortedEmployees = SortEmployees(_employees, sortColumn, ascending);
            var paginatedEmployees = sortedEmployees.Skip(skip).Take(take);
            var totalCount = _employees.Count;

            var employeeDtos = _mapper.Map<List<EmployeeDto>>(paginatedEmployees);

            var result = new PaginatedList<EmployeeDto>(employeeDtos, totalCount, skip / take, take);
            return Task.FromResult(result);
        }

        public Task<int> GetTotalEmployeesCountAsync()
        {
            // Подсчитываем всех сотрудников в репозитории
            var totalCount = _employees.Count();
            return Task.FromResult(totalCount);
        }

        private static IEnumerable<Employee> SortEmployees(IEnumerable<Employee> employees, string sortColumn, bool ascending)
        {
            return sortColumn?.ToLower() switch
            {
                "firstname" => ascending ? employees.OrderBy(e => e.FirstName) : employees.OrderByDescending(e => e.FirstName),
                "lastname" => ascending ? employees.OrderBy(e => e.LastName) : employees.OrderByDescending(e => e.LastName),
                "position" => ascending ? employees.OrderBy(e => e.Position) : employees.OrderByDescending(e => e.Position),
                _ => employees.OrderBy(e => e.FirstName),
            };
        }
    }
}
