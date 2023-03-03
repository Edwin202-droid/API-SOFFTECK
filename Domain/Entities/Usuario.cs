﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
    }
}
