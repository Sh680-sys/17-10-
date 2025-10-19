﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }
}
