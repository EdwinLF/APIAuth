﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen.BC.Modelos
{
    public class Usuario
    {
        public string CardUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UserBirthdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
