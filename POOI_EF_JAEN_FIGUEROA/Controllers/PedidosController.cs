using POOI_EF_JAEN_FIGUEROA.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POOI_EF_JAEN_FIGUEROA.Controllers
{
    public class PedidosController : Controller
    {

        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        // Método Index sin parámetros, redirige al método Index con fechas por defecto
        public ActionResult Index()
        {
            return View(ObtenerPedidos()); 
        }

        // Método Index con parámetros, recibe las fechas de inicio y fin
        [HttpPost]
        public ActionResult Index(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio <= fechaFin)
            {
                return View(ObtenerPedidos(fechaInicio, fechaFin));
            }
            else
            {
                ViewBag.ErrorFecha = "La fecha de inicio debe ser menor a la fecha de fin";
                return View(ObtenerPedidos());
            }
        }

        private List<Pedido> ObtenerPedidos()
        {
           return ObtenerPedidos(DateTime.Parse("2025-01-01"), DateTime.Parse("2025-01-01"));
        }

        private List<Pedido> ObtenerPedidos(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_Clientes_ContarPedidos", connection);
                command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@FechaFin", fechaFin);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.NombreCliente = reader["NomCliente"].ToString();
                    pedido.CantidadPedidos = reader["CantidadPedidos"].ToString();
                    pedidos.Add(pedido);
                }

                reader.Close();
            }

            return pedidos;
        }
    }
}