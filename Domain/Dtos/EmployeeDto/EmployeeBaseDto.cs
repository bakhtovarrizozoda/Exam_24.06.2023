namespace Domain.Entities;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public int Gender { get; set; }
    public DateTime Hiredate { get; set; }
}