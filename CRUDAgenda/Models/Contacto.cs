using System.ComponentModel.DataAnnotations;

namespace CRUDAgenda.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Es obligatorio el nombre")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio el apelido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Es obligatorio el celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Es obligatorio la dirección")]
        public string Direccion { get; set;}

        [Required, EmailAddress(ErrorMessage = "Es obligatorio el correo")]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
