using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Model;

[Table("account")]
public class Account
{
    [Key]
    [Column("id")]
    public int Id { get; set; }   // станет PRIMARY KEY
    
    [Column("username")]
    public string UserName { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
}