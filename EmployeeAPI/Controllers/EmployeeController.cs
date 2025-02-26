using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Contracts.Interfaces;
using EmployeeAPI.Contracts.Dto;

namespace EmployeeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController(IEmployeeRepository employeeRepository) : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    [HttpGet]
    public async Task<ActionResult> GetEmployees(
        [FromQuery] string sortColumn = nameof(EmployeeDto.FirstName),
        [FromQuery] bool ascending = true,
        [FromQuery] int skip = 0,
        [FromQuery] int take = 10,
        [FromQuery] bool count = false)
    {
        if (count)
        {
            // ¬озвращаем только количество сотрудников
            var totalCount = await _employeeRepository.GetTotalEmployeesCountAsync();
            return Ok(totalCount);
        }

        var result = await _employeeRepository.GetEmployeesAsync(sortColumn, ascending, skip, take);

        return Ok(result);
    }
}
