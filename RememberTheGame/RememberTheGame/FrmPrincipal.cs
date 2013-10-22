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
    // Enumerado con los tipos de operaciones que se pueden realizar
    public enum Operaciones { add, edit, delete };

    public partial class FrmPrincipal : Form
    {
        /////////////////////////////////////////////////////////////////////////////////
        // Campos o atributos
        private ConexionLocalDB conexionldb;


        /////////////////////////////////////////////////////////////////////////////////
        // Constructor
        public FrmPrincipal()
        {
            InitializeComponent();
            this.conexionldb = new ConexionLocalDB();            
        }


        /////////////////////////////////////////////////////////////////////////////////
        // Métodos
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            RellenarTreeView();
        }        

        
        // Rellena de datos el TreeView
        private void RellenarTreeView()
        {
            // IdGnero, Nombre, NumJuegos
            String generosSql = "SELECT g.IdGenero, g.Nombre, COUNT(j.IdJuego) AS NumJuegos " +
                "FROM dbo.Juegos AS j INNER JOIN dbo.Juegos_has_Generos AS jg ON j.IdJuego = jg.IdJuego INNER JOIN dbo.Generos AS g ON jg.IdGenero = g.IdGenero " +
                "GROUP BY g.IdGenero, g.Nombre " +
                "ORDER BY g.Nombre;";
            
            //IdPlataforma, Nombre, NumJuegos
            String plataformasSql = "SELECT p.IdPlataforma, p.Nombre, COUNT(j.IdJuego) AS NumJuegos " +
                "FROM dbo.Juegos AS j INNER JOIN dbo.Plataformas AS p ON j.IdPlataforma = p.IdPlataforma " +
                "GROUP BY p.IdPlataforma, p.Nombre " +
                "ORDER BY p.Nombre;";

            tvxPlataformas.Nodes.Clear();
            tvxPlataformas.Nodes.Add(ObtenerTreeNode("Generos", generosSql));
            tvxPlataformas.Nodes.Add(ObtenerTreeNode("Plataformas", plataformasSql));
        }

        // Devuelve un objeto TreeNode para ser agregado al TreeView
        private TreeNode ObtenerTreeNode(String nombreRaiz, String sql)
        {
            TreeNode nodo = new TreeNode(nombreRaiz);

            using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
            {
                cn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);                
                SqlCommandBuilder cmmdBuilder = new SqlCommandBuilder(da);
                da.Fill(ds, nombreRaiz);

                for (Int32 i = 0; i < ds.Tables[nombreRaiz].Rows.Count; i++)
                {
                    String nombre = Convert.ToString(ds.Tables[nombreRaiz].Rows[i]["Nombre"]);
                    String numero = Convert.ToString(ds.Tables[nombreRaiz].Rows[i]["NumJuegos"]);

                    String cadenaTexto = "(" + numero + ") " + nombre;

                    nodo.Nodes.Add(cadenaTexto);
                }
            }
            
            return nodo;
        }

                
        // Rellena el DataGridView con sus correspondientes datos
        private void RellenarDataGrid(String consulta, String filtro)
        {
            String cmmdSql = "";

            using (SqlConnection cn = this.conexionldb.DameConexionLocalDB())
            {
                if (filtro != "")
                {
                    switch (consulta)
                    {
                        case "Generos":
                            cmmdSql = "SELECT j.Nombre, j.Usuario, j.Password, j.CdKey, j.Notas, p.IdPlataforma, p.Nombre AS Plataforma " +
                                "FROM dbo.Juegos AS j INNER JOIN dbo.Plataformas AS p ON j.IdPlataforma = p.IdPlataforma " +
                                "INNER JOIN dbo.Juegos_has_Generos AS jg ON j.IdJuego = jg.IdJuego " +
                                "INNER JOIN dbo.Generos AS g ON jg.IdGenero = g.IdGenero " +
                                "WHERE g.Nombre = @filtro";
                            break;
                        case "Plataformas":
                            cmmdSql = "SELECT j.Nombre, j.Usuario, j.Password, j.CdKey, j.Notas, p.IdPlataforma, p.Nombre AS Plataforma " +
                                "FROM Juegos AS j INNER JOIN Plataformas AS p ON j.IdPlataforma = p.IdPlataforma " +
                                "WHERE p.Nombre = @filtro";
                            break;
                        default:
                            MessageBox.Show("Parametro no esperado. Consulta: " + consulta , "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    cmmdSql = "SELECT j.Nombre, j.Usuario, j.Password, j.CdKey, j.Notas, p.IdPlataforma, p.Nombre " +
                "FROM Juegos AS j INNER JOIN Plataformas AS p ON j.IdPlataforma = p.IdPlataforma;"; 
                }

                DataSet ds = new DataSet();
                SqlCommand cmmd = new SqlCommand(cmmdSql, cn);
                SqlParameter cmmdParam = new SqlParameter("@filtro", filtro);
                cmmd.Parameters.Add(cmmdParam);
                SqlDataAdapter da = new SqlDataAdapter(cmmd);               
                SqlCommandBuilder cmmdBuilder = new SqlCommandBuilder(da);
                da.Fill(ds, "Juegos");

                dgvJuegos.DataSource = ds;
                dgvJuegos.DataMember = "Juegos";                

            }                                         
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalidaClase cerrarAplicacion = new SalidaClase();
            cerrarAplicacion.SalidaUniversal(SalidaClase.Idiomas.Spanish);
        }


        private void tvxPlataformas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String nodoPadre;
            String nodoHijo = "";

            // Si no existe padre estamos en un nodo raiz
            if (e.Node.Parent == null)
            {
                nodoPadre = e.Node.Text;
                nodoHijo = "";
            }
            else
            {
                nodoPadre = e.Node.Parent.Text;

                Int32 posInicioHijo = e.Node.Text.IndexOf(")") + 2;

                for (Int32 i = posInicioHijo; i < e.Node.Text.Length; i++)
                {
                    nodoHijo +=  Convert.ToString(e.Node.Text[i]);                                        
                }                
            }
           
            RellenarDataGrid(nodoPadre, nodoHijo);
        }

        private void acercaDeRememberTheGamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcerca acerca = new FrmAcerca();
            acerca.Show();
        }

        private void añadirCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenero addGenero = new FrmGenero(Operaciones.add);
            addGenero.Show();

        }

        // POR HACER -------------------
        private void editarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenero editGenero = new FrmGenero(Operaciones.edit);
            editGenero.Show();
        }

        // POR HACER -------------------
        private void borrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // POR HACER -------------------
        private void añadirPlataformaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlataforma addPlataforma = new FrmPlataforma();
            addPlataforma.Show();
        }

        // POR HACER -------------------
        private void editarPlataformaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlataforma editPlataforma = new FrmPlataforma();
            editPlataforma.Show();
        }

        // POR HACER -------------------
        private void borrarPlataformaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    } //Class
} //Namespace
