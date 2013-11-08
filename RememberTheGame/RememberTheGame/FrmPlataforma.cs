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
    public partial class FrmPlataforma : Form
    {
        /////////////////////////////////////////////////////////////////////////////////
        // Campos o atributos

        private ConexionLocalDB conexionldb;
        private Operaciones tipo_operacion;
        private FrmPrincipal frmPadre;
        private String nodoPadre;
        private String nodoHijo;
        private Int32 IdPlataforma;


        /////////////////////////////////////////////////////////////////////////////////
        // Constructores
        
        //Si es para editar en nodos[0] y nodos[1] deben llegar nodoPadre y nodoHijo respectivamente
        public FrmPlataforma(Operaciones operacion, FrmPrincipal padre, params String[] nodos) 
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
        private void FrmPlataforma_Load(object sender, EventArgs e)
        {
            switch (this.tipo_operacion)
            {
                case Operaciones.add:
                    lbIdPlataformaResultado.Text = "Auto";
                    break;
                case Operaciones.edit:
                    rellenarDatosPlataforma(); 
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
                    addPlataforma();
                    break;
                case Operaciones.edit:
                    editPlataforma();
                    break;
                default:
                    break;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Instrucciones para añadir una nueva categoria
        private void addPlataforma()
        {
            String sql = "SELECT IdPlataforma, Nombre FROM Plataformas;";

            String nombre = txbNombre.Text.Trim();

            //La plataforma no puede contener un nombre vacio
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
                    SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Plataformas");

                    // Creamos nueva fila y la añadimos al dataset
                    DataRow nuevaPlataforma = ds.Tables["Plataformas"].NewRow();
                    nuevaPlataforma["Nombre"] = nombre;
                    ds.Tables["Plataformas"].Rows.Add(nuevaPlataforma);

                    DialogResult dresult = MessageBox.Show("¿Estas seguro de añadir " + nuevaPlataforma["Nombre"] + " como nueva plataforma?", "Nueva plataforma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dresult == DialogResult.Yes)
                    {
                        //Guardamos cambio en la BD
                        da.Update(ds, "Plataformas");
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

        // Instrucciones para editar/actualizar una plataforma
        private void editPlataforma()
        {
            String sql = "SELECT IdPlataforma, Nombre FROM Plataformas WHERE IdPlataforma = @IdPlataforma;";

            String nombre = txbNombre.Text.Trim();

            // La plataforma debe tener un nombre
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
                    SqlParameter paramIdPlataforma = new SqlParameter("@IdPlataforma", this.IdPlataforma);
                    cmmd.Parameters.Add(paramIdPlataforma);
                    SqlDataAdapter da = new SqlDataAdapter(cmmd);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Plataformas");

                    if (ds.Tables["Plataformas"].Rows.Count == 1)
                    {
                        DataRow editarPlataforma = ds.Tables["Plataformas"].Rows[0];

                        editarPlataforma["Nombre"] = nombre;

                        DialogResult dresult = MessageBox.Show("¿Estas seguro de actualizar los datos del genero?", "Actualizar genero", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dresult == DialogResult.Yes)
                        {
                            // Registramos los cambios
                            da.Update(ds, "Plataformas");
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

        //Rellena el formulario cuando se trata de editar/actualizar plataforma
        private void rellenarDatosPlataforma()
        {
            String sql = "SELECT IdPlataforma, Nombre FROM Plataformas WHERE Nombre = @nombrePlataforma;";

            using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
            {
                cn.Open();

                DataSet ds = new DataSet();
                SqlCommand cmmd = new SqlCommand(sql, cn);
                SqlParameter paramNombrePlataforma = new SqlParameter("@nombrePlataforma", this.nodoHijo);
                cmmd.Parameters.Add(paramNombrePlataforma);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);
                da.Fill(ds, "Plataformas");

                if (ds.Tables["Plataformas"].Rows.Count == 1)
                {
                    DataRow filaPlataforma = ds.Tables["Plataformas"].Rows[0];
                    this.IdPlataforma = Convert.ToInt32(filaPlataforma["IdPlataforma"]);
                    lbIdPlataformaResultado.Text = Convert.ToString(filaPlataforma["IdPlataforma"]);
                    txbNombre.Text = Convert.ToString(filaPlataforma["Nombre"]);
                }
                else
                {
                    MessageBox.Show("Caso no esperado. No pueden exister plataformas con el nombre repetido", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }            
        }

    } //Class
}//Namespace
