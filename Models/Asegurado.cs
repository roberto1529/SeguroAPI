using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeguroAPI.Models
{
    public class Asegurado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Evita que sea IDENTITY
        [StringLength(12, MinimumLength = 12, ErrorMessage = "El número de identificación debe tener exactamente 12 caracteres.")]
        [Required]
        public string NumeroIdentificacion { get; set; } = null!;



        [Required]
        public required string PrimerNombre { get; set; }

        public required string SegundoNombre { get; set; }

        [Required]
        public required string PrimerApellido { get; set; }

        [Required]
        public required string SegundoApellido { get; set; }

        [Required]
        public required string TelefonoContacto { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public decimal ValorEstimadoSeguro { get; set; }

        public required string Observaciones { get; set; }
    }
}
