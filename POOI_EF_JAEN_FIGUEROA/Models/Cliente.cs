using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POOI_EF_JAEN_FIGUEROA.Models
{
    public class Cliente
    {

        [Display(Name = "ID")]
        public string IdCliente { get; set; }

        [Display(Name = "Nombres y Apellidos")]
        public string NomCliente { get; set; }
    }
}