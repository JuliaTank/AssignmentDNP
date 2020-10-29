using System.Text.Json;

namespace AssignmentWebAPI.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public int SecurityLevel { get; set; }
        
        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
    
}