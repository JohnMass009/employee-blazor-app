namespace EmployeeAPI.Contracts.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Position { get; set; }
    }
}
