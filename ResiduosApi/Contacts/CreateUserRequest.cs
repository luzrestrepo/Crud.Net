using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [StringLength(20)]
    public required string Name { get; set; }

    [MinLength(8)]
    public required string Email { get; set; } 

    [Range(1,80)]
    public int Age { get; set; }
}