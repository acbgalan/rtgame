/*------------------------------------------------------------------------------
 * Creado  : 23.09.2013 por A.Carlos Blanco
 * Uso	   : Incluir la clase en el proyecto, instanciarlo e invocarlo donde sea necesario.
 * Ejemplo : Un botón para salir dentro de un formulario, el cual instancia la clase y hace una llamada
 *              al método SalidaUniversal.
*              
 *			    SalidaClase sc = new SalidaClase();
 *			    sc.SalidaUniversal();
 ------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace RememberTheGame
{
    public class SalidaClase
    {
        public enum Idiomas { Spanish, English }

        /*-------------------------------------------------------------------------
        * Metodo publico 
        * Sobrecarga	: no
        * Parametros	: si
        * Valor retorno	: no
        * 		: Muestra un mensaje preguntando si se desea salir
        *-------------------------------------------------------------------------*/
        public void SalidaUniversal(Idiomas idioma)
        {
            if (idioma == Idiomas.Spanish)
            {
                DialogResult dr = MessageBox.Show("¿Estas seguro de terminar el programa?", "¿Terminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else if (idioma == Idiomas.English)
            {
                DialogResult dr = MessageBox.Show("Are you sure to end the program ?", "Finish ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
    }
}

