using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POOI_EF_JAEN_FIGUEROA.Models;
using System.Configuration;
using System.Web.Services.Description;

namespace POOI_EF_JAEN_FIGUEROA.Controllers
{
    public class ClientesContactosController : Controller
    {
        private readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

        [HttpGet]
        public ActionResult Index(string mensaje)
        {
            List<Contacto> contactos = new List<Contacto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_Contactos_Listar", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contacto contacto = new Contacto();
                    contacto.DNI = reader["DNI"].ToString();
                    contacto.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                    contacto.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                    contacto.Nombres = reader["Nombres"].ToString();
                    contacto.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    contacto.Email = reader["Email"].ToString();
                    contacto.Telefonos = reader["Telefonos"].ToString();
                    contacto.IdCliente = reader["IdCliente"].ToString();

                    contactos.Add(contacto);
                }

                reader.Close();
            }

            ViewBag.Mensaje = mensaje;

            return View(contactos);
        }

        [HttpGet]
        public ActionResult Eliminar(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return HttpNotFound();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_Contactos_Eliminar", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DNI", dni);

                command.ExecuteNonQuery();
            }

            ViewBag.Mensaje = "Contacto eliminado correctamente";
            return RedirectToAction("Index", new { mensaje = "El contacto se eliminó correctamente" });
        }

        // muestra el formulario para agregar contacto)
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // procesa el formulario para agregar contacto)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SP_Contactos_Agregar", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DNI", contacto.DNI);
                    command.Parameters.AddWithValue("@ApellidoPaterno", contacto.ApellidoPaterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", contacto.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Nombres", contacto.Nombres);
                    command.Parameters.AddWithValue("@FechaRegistro", contacto.FechaRegistro);
                    command.Parameters.AddWithValue("@Email", contacto.Email);
                    command.Parameters.AddWithValue("@Telefonos", contacto.Telefonos);
                    command.Parameters.AddWithValue("@IdCliente", contacto.IdCliente);

                    command.ExecuteNonQuery();
                }

                return RedirectToAction("Index"); 
            }

            return View(contacto); 
        }

        [HttpGet]
        public ActionResult ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_Clientes_Listar", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = reader["IdCliente"].ToString();
                    cliente.NomCliente = reader["NomCliente"].ToString();

                    clientes.Add(cliente);
                }

                reader.Close();
            }

            return View(clientes);
        }
    }
}
