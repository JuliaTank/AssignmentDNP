using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace AssignmentWebAPI.Models {
public class Person {
    [Required]
    [Range(1,int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    [JsonPropertyName("userId")]
    public int Id { get; set; }
    [NotNull]
    [JsonPropertyName("first name")]
    public string FirstName { get; set; }
    [NotNull]
    [JsonPropertyName("last name")]
    public string LastName { get; set; }
    [ValidHairColor]
    [JsonPropertyName("hair color")]
    public string HairColor { get; set; }
    [NotNull]
    [JsonPropertyName("eye color")]
    [ValidEyeColor]
    public string EyeColor { get; set; }
    [NotNull, Range(0, 125)]
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [NotNull, Range(1, 250)]
    [JsonPropertyName("weight")]
    public float Weight { get; set; }
    [NotNull, Range(30, 250)]
    
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [NotNull]
    [JsonPropertyName("sex")]
    public string Sex { get; set; }

    public void Update(Person toUpdate) {
        Age = toUpdate.Age;
        Height = toUpdate.Height;
        HairColor = toUpdate.HairColor;
        Sex = toUpdate.Sex;
        Weight = toUpdate.Weight;
        EyeColor = toUpdate.EyeColor;
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
    }

}

public class ValidHairColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
        if (value != null && valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
    }
}

public class ValidEyeColor : ValidationAttribute {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
        List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
        if (value != null && valid.Contains(value.ToString().ToLower())) {
            return ValidationResult.Success;
        }
        return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
    }
}

}