using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public string Correo { get; set; }
}
