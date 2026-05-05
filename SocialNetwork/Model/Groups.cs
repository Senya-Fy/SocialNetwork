using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Model;

[Table("groups")]
public class Groups
{
    [Key]
    [Column("id")]
    public int Id { get; set; }   // станет PRIMARY KEY
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("owner_id")]
    public int OwnerId { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}