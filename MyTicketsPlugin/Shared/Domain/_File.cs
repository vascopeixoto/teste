using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketsPlugin.Shared.Domain
{
    public class _File
    {
        [Key]
        public int fileId { get; set; }
        public string fileName { get; set; }
        public string fileUrl { get; set; }
        [NotMapped]
        public byte[] FileContent { get; set; }
        [ForeignKey("Message")]
        public int msgId { get; set; }
        public virtual Message? Message { get; set; }
    }
}
