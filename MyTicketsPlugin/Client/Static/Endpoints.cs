using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTicketsPlugin.Client.Static

{
    public static class Endpoints
    {

        public static string Prefix = "api";

        public static string TicketsEndpoint = $"{Prefix}/tickets";
        public static string CategoriasEndpoint = $"{Prefix}/categorias";
        public static string EstadoTicketsEndpoint = $"{Prefix}/estadoTickets";
        public static string MessagesEndpoint = $"{Prefix}/messages";
        public static string FileEndpoint = $"{Prefix}/_File";
        public static string FileUpEndpoint = $"{Prefix}/FileUpload";

    }
}
