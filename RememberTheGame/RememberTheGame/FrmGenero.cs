using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RememberTheGame
{
    public partial class FrmGenero : Form
    {
        /////////////////////////////////////////////////////////////////////////////////
        // Campos o atributos

        private ConexionLocalDB conexionldb;
        private Operaciones tipo_operacion;
        
        public FrmGenero(Operaciones operacion)
        {
            InitializeComponent();
            this.conexionldb = new ConexionLocalDB();
            this.tipo_operacion = operacion;
        }

        private void FrmGenero_Load(object sender, EventArgs e)
        {
            switch (this.tipo_operacion)
            {
                case Operaciones.add:
                    lbIdGeneroResultado.Text = "Auto";                                       
                    break;
                case Operaciones.edit:
                    MessageBox.Show("El tipo de operación seleccionada es: " + Convert.ToString(this.tipo_operacion));
                    break;
                default:
                    MessageBox.Show("Caso no esperado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String sql = "SELECT IdGenero, Nombre, Descripcion FROM Generos;";

            String nombre = txbNombre.Text.Trim();
            String descripcion = txbDescripcion.Text.Trim();

            try
            {
                using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
                {
                    cn.Open();

                    // Creamos un dataSet con el contenido de la tabla generos
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Generos");

                    // Creamos nueva fila y la añadimos al dataset
                    DataRow nuevoGenero = ds.Tables["Generos"].NewRow();
                    nuevoGenero["Nombre"] = nombre;
                    nuevoGenero["Descripcion"] = descripcion;
                    ds.Tables["Generos"].Rows.Add(nuevoGenero);

                    DialogResult dresult = MessageBox.Show("¿Estas seguro de añadir " + nuevoGenero["Nombre"] + " como nuevo genero?", "Nuevo genero", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dresult == DialogResult.Yes)
                    {
                        // Registramos cambio en la BD
                        da.Update(ds, "Generos");
                    }

                    this.Close();                    
                } 
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se ha producido una excepción." + ex.Message, "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    } // class
} // namespace
