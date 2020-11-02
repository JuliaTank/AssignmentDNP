using System.Text.Json;
using System.Text.Json.Serialization;


namespace AssignmentWebAPI.Models {
public class Adult : Person {
    
    [JsonPropertyName("title")]
    public string JobTitle { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }

    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }

}
}