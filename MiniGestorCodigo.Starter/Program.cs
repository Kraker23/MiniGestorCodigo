using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.UI;
using Utilities.Controls.AutoUpdate;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.BL;

namespace MiniGestorCodigo.Starter
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Programa()); //new Programa()
           
            //frmUpdate frm = new frmUpdate(System.IO.Directory.GetCurrentDirectory(), "\\\\172.18.2.159\\Software\\Programacion\\Cristian\\MiniGestorCodigo");
            //DialogResult rUpdate = frm.ShowDialog();
            //if (rUpdate == DialogResult.OK || rUpdate == DialogResult.Ignore)
            //{
            frmLoggin frmlog;
            bool registro = false;

            if (!comprobarRegistroPC())
            {
                frmlog = new frmLoggin();
                registro = true;
            }
            else
            {
                ultimo_inicio last = gUltimoInicio.getUltimoInicioByNombreOrdenador(Environment.MachineName);

                frmlog = new frmLoggin(last.fk_idUsuario);
               //frmlog = new frmLoggin(last.fk_idUsuario,"1234");
                registro = false;
            }


            DialogResult r = frmlog.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (registro)
                {
                    ultimo_inicio last = new ultimo_inicio();

                    last.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                    last.idOrdenador = 0;
                    last.nombreOrdenador = Environment.MachineName;

                    gUltimoInicio.addUltimoInicio(last);
                }
                else
                {
                    ultimo_inicio last = gUltimoInicio.getUltimoInicioByNombreOrdenador(Environment.MachineName);

                    if (last.fk_idUsuario != Globales.GetUsuarioActual().idUsuario)
                    {
                        last.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;

                        gUltimoInicio.updateUltimoInicio(last);
                    }
                }
                if (Globales.GetUsuarioActual().password == "123")
                {
                    frmCambiarPassword frmPassword = new frmCambiarPassword();
                    DialogResult pas = frmPassword.ShowDialog();

                    if (pas == DialogResult.OK)
                    {
                        Application.Run(new frmMain());
                    }

                }
                else
                {
                    Application.Run(new frmMain());
                }


            }
            else
            {
                Application.Exit();
            }
            //}
            //else
            //{
            //    Application.Exit();
            //}
            


        }

        static bool comprobarRegistroPC()
        { 
            if (gUltimoInicio.getUltimoInicioByNombreOrdenador(Environment.MachineName) == null)
                return false;

            else
                return true;

        }
    }
}
