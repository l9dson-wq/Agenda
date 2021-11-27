using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using capaDatos; 

namespace capaLogica
{
    public class capaLogicaPersonas
    {

        private capaDatosPersonas objetoCPD = new capaDatosPersonas();

        public DataTable MostrarPersonas()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCPD.Mostrar();
            return tabla;
        }

        public void InsertarPersona(string nombre, string apellido, string telefono){
            objetoCPD.Insertar(nombre,apellido,Convert.ToInt32(telefono));
        }

        public void EditarPersona(string nombre, string apellido, string telefono, string id) {
            objetoCPD.Editar(nombre, apellido, Convert.ToInt32(telefono), Convert.ToInt32(id));
        }

        public void EliminarPersona(string id) {
            objetoCPD.Eliminar(Convert.ToInt32(id));
        }

        public DataTable BuscarPersona(string nombre)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCPD.Buscar(nombre);
            return tabla;
        }
    }
}
