using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Model;

[Table("message")]
public class Message
{
    [Key]
    [Column("id")]
    public int Id { get; set; }   // станет PRIMARY KEY
    
    [Column("sender_id")]
    public int SenderId { get; set; }
    
    [Column("receiver_id")]
    public int ReceiverId { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}