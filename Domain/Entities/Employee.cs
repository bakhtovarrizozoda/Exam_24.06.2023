using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public DateTime Birthdate { get; set; }
    [Required]
    public int Gender { get; set; }
    [Required]
    public DateTime Hiredate { get; set; }
    public List<Salary> Salaries { get; set; }
    public List<DepartmentManager> DepartmentManagers { get; set; }
    public List<DepartmentEmployee> DepartmentEmployees { get; set; }
}