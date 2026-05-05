using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Model;

[Table("friend")]
public class Friend
{
    [Column("account_id")]
    public int AccountId { get; set; }   // станет PRIMARY KEY
    
    [Column("friend_id")]
    public int FriendId { get; set; }
    
    [Column("status")]
    public string Status { get; set; }
    
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }
    
    public Account? Account { get; set; }
    public Account? FriendAccount { get; set; }
    
   
    
}