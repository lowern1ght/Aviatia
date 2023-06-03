using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace Aviatia.Data.Entities;

[Table("employee")]
public class Employee
{
    [Key]
    [Required]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Required]
    [Column("name")]
    public String? Name { get; set; }
    
    [Required]
    [Column("pass")]
    public String? Password
    {
        set
        {
            if (value != null)
            {
                this.Password = value;
                this.PasswordHashed = HashingPassword(value);
            }
            else
            {
                throw new ArgumentNullException(
                    nameof(this.Password), 
                    $"The password cannot be empty {value}");
            }
        }
    }

    [Required]
    [Column("pass_hash")]
    public String? PasswordHashed { get; set; }
    
    [Required]
    [Column(name: "birth_date")]
    public DateOnly BirthDate { get; set; }
    
    [Column("department_id")]
    public Int32? DepartmentId { get; set; }
    public Department? Department { get; set; }
    

    /// <summary>
    /// This method takes a password as input and returns a hashed password with salt
    /// </summary>
    /// <param name="pass"></param>
    /// <returns></returns>
    public String HashingPassword(String pass)
    {
        using var rng = RandomNumberGenerator.Create();
        Byte[] salt = new byte[16];
        
        using var pdkdf2 = new Rfc2898DeriveBytes(pass, salt, 10100, HashAlgorithmName.SHA512);
        Byte[] hash = pdkdf2.GetBytes(32);
        
        return Convert.ToBase64String(hash) + "|" + Convert.ToBase64String(salt);
    }

    public Boolean PasswordIsEquals(String pass, String passHashed)
    {
        return HashingPassword(pass).Equals(passHashed);
    }
}