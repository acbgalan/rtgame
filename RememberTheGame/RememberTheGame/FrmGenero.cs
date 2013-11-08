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
        private FrmPrincipal frmPadre;
        private String nodoPadre;
        private String nodoHijo;
        private Int32 IdGenero;


        /////////////////////////////////////////////////////////////////////////////////
        // Constructores

        //Si es para editar en nodos[0] y nodos[1] deben llegar nodoPadre y nodoHijo respectivamente
        public FrmGenero(Operaciones operacion, FrmPrincipal padre, params String[] nodos)
        {
            InitializeComponent();

            this.conexionldb = new ConexionLocalDB();
            this.tipo_operacion = operacion;
            this.frmPadre = padre;            

            switch (operacion)
            {
                case Operaciones.add:
                    this.nodoPadre = String.Empty;
                    this.nodoHijo = String.Empty;
                    break;
                case Operaciones.edit:
                    if (nodos == null)
                    {
                        throw new ArgumentException("FrmGenero: El constructor ha recibido una lista de parametros con valor null.");
                    }

                    if (nodos.Length != 2)
                    {
                        throw new ArgumentException("FrmGenero: El constructor ha recibido una lista de parametros con un número de elementos no esperado.");
                    }

                    this.nodoPadre = nodos[0];
                    this.nodoHijo = nodos[1];
                    break;
                default:   
                    break;                
            }
        }


        /////////////////////////////////////////////////////////////////////////////////
        // Métodos
        private void FrmGenero_Load(object sender, EventArgs e)
        {
            switch (this.tipo_operacion)
            {
                case Operaciones.add:
                    lbIdGeneroResultado.Text = "Auto";                                       
                    break;
                case Operaciones.edit:
                    rellenarDatosCategoria();
                    break;
                default:
                    MessageBox.Show("Caso no esperado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.tipo_operacion)
            {
                case Operaciones.add:
                    addCategoria();
                    break;
                case Operaciones.edit:
                    editCategoria();
                    break;
                default:
                    MessageBox.Show("Caso no esperado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            // Actualizamos TreeView del formulario principal            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Instrucciones para añadir una nueva categoria
        private void addCategoria()
        {
            String sql = "SELECT IdGenero, Nombre, Descripcion FROM Generos;";

            String nombre = txbNombre.Text.Trim();
            String descripcion = txbDescripcion.Text.Trim();

            // El genero debe tener un nombre
            if (nombre == String.Empty)
            {
                return;
            }

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
                        // Guardamos cambio en la BD
                        da.Update(ds, "Generos");
                        // Actualizamos el TreeView del formulario principal
                        frmPadre.RellenarTreeView();
                    }

                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se ha producido una excepción." + ex.Message, "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Instrucciones para editar/actualizar una categoria
        private void editCategoria()
        {
            String sql = "SELECT IdGenero, Nombre, Descripcion FROM Generos WHERE IdGenero = @IdGenero;";

            String nombre = txbNombre.Text.Trim();
            String descripcion = txbDescripcion.Text.Trim();

            // El genero debe tener un nombre
            if (nombre == String.Empty)
            {
                return;
            }

            try
            {
                using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
                {
                    cn.Open();

                    // Creamos un dataSet con el contenido de la tabla generos
                    DataSet ds = new DataSet();
                    SqlCommand cmmd = new SqlCommand(sql, cn);
                    SqlParameter paramIdGenero = new SqlParameter("@IdGenero", this.IdGenero);
                    cmmd.Parameters.Add(paramIdGenero);
                    SqlDataAdapter da = new SqlDataAdapter(cmmd);                    
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Generos");

                    if (ds.Tables["Generos"].Rows.Count == 1)
                    {
                        DataRow editarGenero = ds.Tables["Generos"].Rows[0];

                        editarGenero["Nombre"] = nombre;
                        editarGenero["Descripcion"] = descripcion;

                        DialogResult dresult = MessageBox.Show("¿Estas seguro de actualizar los datos del genero?", "Actualizar genero", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dresult == DialogResult.Yes)
                        {
                            // Registramos los cambios
                            da.Update(ds, "Generos");
                            // Actualizamos el TreeView del formulario principal
                            frmPadre.RellenarTreeView();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Caso no esperado.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }                                  

                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Se ha producido una excepción." + ex.Message, "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Rellena los datos en los textbox cuando se trata de editar/actualizar una categoria
        private void rellenarDatosCategoria()
        {            
            String sql = "SELECT IdGenero, Nombre, Descripcion FROM Generos WHERE Nombre = @nombreGenero;";

            using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
            {
                cn.Open();

                DataSet ds = new DataSet();
                SqlCommand cmmd = new SqlCommand(sql, cn);
                SqlParameter paramNombreGenero = new SqlParameter("@nombreGenero", this.nodoHijo);
                cmmd.Parameters.Add(paramNombreGenero);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
                da.Fill(ds, "Generos");

                if (ds.Tables["Generos"].Rows.Count == 1)
                {
                    DataRow filaGenero = ds.Tables["Generos"].Rows[0];
                    this.IdGenero = Convert.ToInt32(filaGenero["IdGenero"]);
                    lbIdGeneroResultado.Text = Convert.ToString(this.IdGenero);
                    txbNombre.Text = Convert.ToString(filaGenero["Nombre"]);
                    txbDescripcion.Text = Convert.ToString(filaGenero["Descripcion"]);
                }
                else
                {
                    MessageBox.Show("Caso no esperado. No pueden exister generos con el nombre repetido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

    } // class
} // namespace
