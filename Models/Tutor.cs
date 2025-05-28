using System.ComponentModel.DataAnnotations;

public class Tutor
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; } = "";
    [Required]
    public string Telefone { get; set; } = "";
    public string Email { get; set; } = "";
}