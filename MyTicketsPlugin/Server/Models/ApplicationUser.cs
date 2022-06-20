using Microsoft.AspNetCore.Identity;
using MyTicketsPlugin.Shared.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTicketsPlugin.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? role { get; set; }
    }
}