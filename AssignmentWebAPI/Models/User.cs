using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssignmentWebAPI.Models
{
    public class User
    {
        //[JsonPropertyName("username")]
        [Required, StringLength(50)]
        public string UserName { get; set; }
        //[JsonPropertyName("password")]
        [Required, StringLength(50)]
        public string Password { get; set; }
        //[JsonPropertyName("id")]
        [Key]
        public int ID { get; set; }
        //[JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
    
}