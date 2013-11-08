/*------------------------------------------------------------------------------
 * Creado  : 29.09.2013 por A.Carlos Blanco
 * Uso	   : Incluir la clase en el proyecto, modificar los campos conforme los datos de conexión, 
 *           instanciarlo e invocarlo para obtener una conexión LocalDB.
 * Ejemplo : 
 *              
 * ------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberTheGame
{
    public class ConexionLocalDB
    {
        private String dataSource;
        private String attachDBFilename;
        private Boolean integratedSecurity;

        public ConexionLocalDB()
        {
            this.dataSource = @"(LocalDB)\v11.0";
            //this.attachDBFilename = @"|DataDirectory|\rtgame.mdf";
            this.attachDBFilename = @"D:\Workspace\GitHub\rtgame\RememberTheGame\RememberTheGame\rtgame.mdf";
            this.integratedSecurity = true;            
        }
        
        /*-------------------------------------------------------------------------
        * Metodo publico 
        * Sobrecarga	: no
        * Parametros	: no
        * Valor retorno	: SqlConnection
        * Finalidad     : Devuelve una conexión SqlConnection lista para utilizar.
        *-------------------------------------------------------------------------*/
        public SqlConnection DameConexionLocalDB()
        {
            SqlConnection cn = new SqlConnection();
            SqlConnectionStringBuilder cnBuilder = new SqlConnectionStringBuilder();
            cnBuilder.DataSource = this.dataSource;
            cnBuilder.AttachDBFilename = this.attachDBFilename;
            cnBuilder.IntegratedSecurity = integratedSecurity;
            cn.ConnectionString = cnBuilder.ConnectionString;
            return cn;           
        }
    }
}
