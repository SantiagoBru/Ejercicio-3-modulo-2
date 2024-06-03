using System.ComponentModel.DataAnnotations;

public class Actor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }

    [Required]
    [MaxLength(50)]
    public string Apellido { get; set; }

    [MaxLength(100)]
    public string NombreArtistico { get; set; }

    [Range(0, 100)]
    public int Edad { get; set; }

    [MaxLength(50)]
    public string Nacionalidad { get; set; }

    [MaxLength(1)]
    public string Genero { get; set; }
}
