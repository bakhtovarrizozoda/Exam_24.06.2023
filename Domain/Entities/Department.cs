using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Department
{   
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public List<DepartmentManager> DepartmentManagers { get; set; }
    public List<DepartmentEmployee> DepartmentEmployees { get; set; }
}