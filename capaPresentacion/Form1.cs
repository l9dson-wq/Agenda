using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaLogica;

namespace capaPresentacion
{
    public partial class Form1 : Form
    {

        capaLogicaPersonas objetoCLP = new capaLogicaPersonas();
        private string idPersona = null;
        private bool editar = false;
        private String nombrePersona = null; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            capaLogicaPersonas newObjetCLP = new capaLogicaPersonas();
            dataGridView1.DataSource = newObjetCLP.MostrarPersonas();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (editar == false)
            {
                try
                {
                    objetoCLP.InsertarPersona(txtNombre.Text, txtApellido.Text, txtTelefono.Text);
                    MessageBox.Show("Se agrego la persona a la agenda con exito");
                    MostrarProductos();
                    limpiarText(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo completar el agregado " + ex);
                }
            }
            if (editar == true) {
                try
                {
                    objetoCLP.EditarPersona(txtNombre.Text, txtApellido.Text, txtTelefono.Text, idPersona);
                    MessageBox.Show("Persona editada de manera exitosa");
                    MostrarProductos();
                    limpiarText(); 
                    editar = false; 
                }
                catch (Exception ex) {
                    MessageBox.Show("No se pudo completar la edicion " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true; 
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
                idPersona = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else {
                MessageBox.Show("por favor seleccione la fila a editar");
            }
        }

        private void limpiarText() {
            txtApellido.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idPersona = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                objetoCLP.EliminarPersona(idPersona);
                MessageBox.Show("Registro eliminado de manera exitosa");
                MostrarProductos(); 
            }
            else {
                MessageBox.Show("Por favor seleccionar un registro"); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                nombrePersona = txtBuscar.Text;
                capaLogicaPersonas newObjetCLP = new capaLogicaPersonas();
                dataGridView1.DataSource = newObjetCLP.BuscarPersona(nombrePersona);
            }
            else {
                MessageBox.Show("Error: No se puede buscar sin valores");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarProductos(); 
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtApellido.Text.Length > 0 && txtTelefono.Text.Length > 0)
            {
                limpiarText();
            }
            else {
                MessageBox.Show("Los campos ya estan limpios!");
            }

        }
    }
}
