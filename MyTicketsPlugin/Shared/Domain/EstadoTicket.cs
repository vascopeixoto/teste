﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketsPlugin.Shared.Domain
{
    public class Estadoticket
    {
        [Key]
        public int id { get; set; }
        public string? tipoEstado { get; set; }
    }
}
