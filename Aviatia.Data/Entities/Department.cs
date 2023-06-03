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
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }
    
    [Required]
    [Column("name")]
    [JsonPropertyName("name")]
    public String? Name { get; set; }

    [JsonIgnore]
    public IList<Employee> Employees { get; set; } = new List<Employee>();

    [JsonConstructor]
    public Department(string? name, int id)
    {
        this.Id = id;
        this.Name = name;
    }
}