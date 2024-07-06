using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POOI_EF_JAEN_FIGUEROA.Models
{
    public class Pedido
    {
        [Display(Name = "ID Cliente")]
        public string IdCliente { get; set; }
        [Display(Name = "Nombres y Apellidos")]
        public string NombreCliente { get; set; }
        [Display(Name = "Cantidad de pedidos")]
        public string CantidadPedidos { get; set; }
    }
}