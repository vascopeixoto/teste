using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketsPlugin.Shared.Domain
{
    public class Categoria
    {
        [Key]
        public int categoriaId { get; set; }
        public string? categoriaName { get; set; }
    }
}
