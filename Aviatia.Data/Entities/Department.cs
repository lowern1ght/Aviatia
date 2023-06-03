using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Aviatia.Data.Entities;

[Table("department")]
public class Department
{
    [Key]
    [Required]
    [Column("id")]
    public Int32 Id { get; set; }
    
    [Required]
    [Column("name")]
    public String? Name { get; set; }

    public IList<Employee> Employees { get; set; } = new List<Employee>();

    [JsonConstructor]
    public Department(string? name, int id)
    {
        this.Id = id;
        this.Name = name;
    }
}