using System.ComponentModel.DataAnnotations.Schema;

namespace ego_auto.BFF.Domain.Entities;
public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("account_name")]
    public string AccountName { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("role")]
    public string Role { get; set; }
}
