using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrasladoWebAssemblyPart1.Models
{
    public class Tickets
    {

        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Este campo es Obligatorio")]
        [ForeignKey("Prioridades")]
        public int PrioridadId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Este campo es Obligatorio")]
        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Este campo es Obligatorio")]
        [ForeignKey("Sistemas")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Por favor, introduce un Nombre válido")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Por favor, introduce un Asunto válido")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression(@"^[A-Z][a-zA-Z\s]*$", ErrorMessage = "Por favor, introduce una Descripciòn válida")]
        public string? Descripcion { get; set; }

        public Tickets()
        {
            Fecha = DateTime.Now;
        }
    }
}
