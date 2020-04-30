using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetKeeper.Models
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }
        [Required(ErrorMessage = "Name of role is required")]
        public string RoleName { get; set; }
    }
}
