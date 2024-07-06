using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POOI_EF_JAEN_FIGUEROA.Models
{
    public class Contacto
    {
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "El campo DNI es requerido.")]
        public string DNI { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El campo Apellido Paterno es requerido.")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo Apellido Materno es requerido.")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo Nombres es requerido.")]
        public string Nombres { get; set; }

        [Display(Name = "Fecha de Registro")]
        [Required(ErrorMessage = "El campo Fecha de Registro es requerido.")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El campo Email es requerido.")]
        [EmailAddress(ErrorMessage = "El campo Email no tiene un formato válido.")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo Teléfono es requerido.")]
        public string Telefonos { get; set; }

        [Display(Name = "ID Cliente")]
        [Required(ErrorMessage = "El campo IdCliente es requerido.")]
        public string IdCliente { get; set; }
    }
}