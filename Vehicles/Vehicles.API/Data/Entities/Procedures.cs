﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles.API.Data.Entities
{
    public class Procedures
    {
        public int Id { get; set; }

        [Display(Name = "Procedimiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatiorio.")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatiorio.")]
        public decimal Price { get; set; }
    }
}
