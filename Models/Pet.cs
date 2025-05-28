using System.ComponentModel.DataAnnotations;

public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    [Required]
    public string Especie { get; set; } = "";
    [Required]
    public string Raca { get; set; } = "";
    public int TutorId { get; set; }
}