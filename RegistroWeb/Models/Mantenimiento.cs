using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace RegistroWeb.Models
{
    public class Mantenimiento
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private string cadena = "Data Source=ServerName;Initial Catalog=NombreDataBase;Integrated Security= True";
        private void Conectar()
        {
            conexion = new SqlConnection(cadena);
        }
        public void Carga(Persona per)
        {
            Conectar();
            comando = new SqlCommand("insert into registros (dni,nombre,domicilio,fecha) values (@dni,@nombre,@domicilio,@fecha)", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@domicilio", SqlDbType.VarChar);
            comando.Parameters.Add("@fecha", SqlDbType.Date);
            comando.Parameters["@dni"].Value = per.dni;
            comando.Parameters["@nombre"].Value = per.nombre;
            comando.Parameters["@domicilio"].Value = per.domicilio;
            comando.Parameters["@fecha"].Value = per.fecha;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public Persona Leer(string dni)
        {
            Conectar();
            comando = new SqlCommand("select nombre,domicilio,fecha from registros where dni=@dni", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Persona pers = new Persona();
            if (registro.Read())
            {
                pers.nombre = registro["nombre"].ToString();
                pers.domicilio = registro["domicilio"].ToString();
                pers.fecha = DateTime.Parse(registro["fecha"].ToString());                
                pers.dni = dni;
            }
            conexion.Close();
            return pers;
        }
        public List<Persona> LeerTodo()
        {
            Conectar();
            List<Persona> lista = new List<Persona>();
            comando = new SqlCommand("select nombre,domicilio,fecha,dni from registros", conexion);
            conexion.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Persona pers = new Persona
                {
                    dni = registros["dni"].ToString(),
                    nombre = registros["nombre"].ToString(),
                    domicilio = registros["domicilio"].ToString(),
                    fecha = DateTime.Parse(registros["fecha"].ToString()),
                };
                lista.Add(pers);
            }
            conexion.Close();
            return lista;
        }
        public void Modificar(Persona pers)
        {
            Conectar();
            comando = new SqlCommand("update registros set nombre=@nombre, domicilio=@domicilio,fecha=@fecha where dni=@dni", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@domicilio", SqlDbType.VarChar);
            comando.Parameters.Add("@fecha", SqlDbType.Date);
            comando.Parameters["@dni"].Value = pers.dni;
            comando.Parameters["@nombre"].Value = pers.nombre;
            comando.Parameters["@domicilio"].Value = pers.domicilio;
            comando.Parameters["@fecha"].Value = pers.fecha;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarDomicilio(string dni, string domicilio)
        {
            Conectar();
            comando = new SqlCommand("update registros set domicilio=@domicilio where dni=@dni", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@domicilio", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@domicilio"].Value = domicilio;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarFecha(string dni, DateTime fecha)
        {
            Conectar();
            comando = new SqlCommand("update registros set fecha=@fecha where dni=@dni", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@fecha", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@fecha"].Value = fecha;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Borrar (string dni)
        {
            Conectar();
            comando = new SqlCommand("delete from registros where dni = @dni", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
