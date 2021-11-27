using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class capaDatosPersonas
    {

        private conexionSQL conexion = new conexionSQL();

        SqlDataReader leer;
        DataTable talba = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //TRANSACT SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Select * from personas";
            comando.CommandType = CommandType.Text;
            leer=comando.ExecuteReader();
            talba.Load(leer);
            conexion.CerrarConexion();
            return talba; 
        }

        public void Insertar(string nombre, string apellido, int telefono)
        {
            //TRANSACT SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into personas(nombre,apellido,telefono) values('"+nombre+"','"+apellido+"','"+telefono+"') ";
            comando.ExecuteNonQuery();
        }

        public void Editar(string nombre, string apellido, int telefono, int id) {
            //TRANSACT SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update personas set nombre='"+nombre+"', apellido='"+apellido+"', telefono='"+telefono+"' where id='"+id+"' ";
            comando.ExecuteNonQuery();
        }

        public void Eliminar(int id) {
            //TRANSACT SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM personas WHERE id='"+id+"' ";
            comando.ExecuteNonQuery(); 
        }

        public DataTable Buscar(string nombre) {
            //TRANSACT SQL
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM personas WHERE nombre LIKE '"+nombre+"' ";
            leer = comando.ExecuteReader();
            talba.Load(leer);
            conexion.CerrarConexion();
            return talba;
        }
    }
}
