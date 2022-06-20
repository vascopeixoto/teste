using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyTicketsPlugin.Shared.Domain
{
    public class Ticket
    {
        [Key]
        public int ticketId { get; set; }
        [Required]
        public string? ticketName { get; set; }
        [Required]
        public int categoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        [ForeignKey("Estadoticket")]
        [Required]
        public int id { get; set; }
        public virtual Estadoticket? Estadoticket { get; set; }
        public string UserId { get; set; }
    }
}
