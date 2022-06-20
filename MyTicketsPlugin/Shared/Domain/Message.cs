using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketsPlugin.Shared.Domain
{
    public class Message
    {
        [Key]
        public int msgId { get; set; }
        public string? message { get; set; }
        [ForeignKey("Ticket")]
        public int ticketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public DateTime DateSent { get; set; }
        public string? Username { get; set; }
        public bool CurrentUser { get; set; }
        public string UserId { get; set; }

    }
}
