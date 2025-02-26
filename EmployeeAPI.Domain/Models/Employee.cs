namespace EmployeeAPI.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Position { get; init; }
    }
}
