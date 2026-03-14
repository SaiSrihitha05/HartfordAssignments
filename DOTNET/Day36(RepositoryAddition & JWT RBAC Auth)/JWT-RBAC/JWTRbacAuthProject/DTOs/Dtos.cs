namespace JWTRbacAuthProject.DTOs
{
    public class Dtos
    {
        public record EmployeeCreateDto(string Name, string? Position, decimal Salary);
        public record EmployeeUpdateDto(string Name, string? Position, decimal Salary);
    }
}
