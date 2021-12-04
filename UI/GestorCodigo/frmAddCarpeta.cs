using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.BL;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.UI;

namespace MiniGestorCodigo.UI
{
    public partial class frmAddCarpeta : Form
    {

        private int? idCarpetaPadre;
        private bool mod = false;
        private bool cod;

        public event EventGuardado actualizarArbol;
        public delegate void EventGuardado();


        public frmAddCarpeta(int? carpetaPadre, bool modificar, bool codigo)
        {
            this.idCarpetaPadre = carpetaPadre;
            this.mod = modificar;
            this.cod = codigo;

            InitializeComponent();

            if (mod)
            {
                if (cod)
                {
                    carpetas car = gCarpetas.getCarpetasById((int)idCarpetaPadre);
                    txtNombreCarpeta.Text = car.nombreCarpeta;
                }
                else
                {
                    carpetas_contrasenas car = gCarpetasContrasenas.getCarpetasContrasenasByIDCarpeta((int)idCarpetaPadre);
                    txtNombreCarpeta.Text = car.nombre;
                }
            }
        }


        private void addCarpeta_Load(object sender, EventArgs e)
        {

        }



        #region Eventos

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metodos        


        private bool validarCarpeta(TreeNode node)
        {
            return false;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (cod)
                GuardarModificarCarpetaCodigo();
            else
                GuardarModificarCarpetaContrasena();
        }

        private void GuardarModificarCarpetaCodigo()
        {
            if (!mod)
            {
                carpetas carpetaNueva = new carpetas();

                if (txtNombreCarpeta.Text != "")
                {
                    carpetaNueva.nombreCarpeta = txtNombreCarpeta.Text;
                    carpetaNueva.fk_IdUsuario = Globales.GetUsuarioActual().idUsuario;
                    carpetaNueva.fk_IdCarpetaPadre = idCarpetaPadre;
                    carpetaNueva.fechaModificacion = DateTime.Now;

                    try
                    {
                        gCarpetas.addCarpetas(carpetaNueva);

                        // Mensaje temporal
                        Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha creado la nueva carpeta", "Nueva carpeta", 1);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: No se ha podido crear la nueva carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Error: El nombre de la carpeta esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                carpetas modCarpeta = gCarpetas.getCarpetasById((int)idCarpetaPadre);

                modCarpeta.nombreCarpeta = txtNombreCarpeta.Text;

                try
                {
                    gCarpetas.updateCarpeta(modCarpeta);
                    Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha modificado el nombre de la carpeta", "Modificar nombre carpeta", 1);
                }
                catch
                {
                    MessageBox.Show("Error: No se ha podido modificar el nombre de la carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void GuardarModificarCarpetaContrasena()
        {
            if (!mod)
            {
                carpetas_contrasenas carpetaNueva = new carpetas_contrasenas();

                if (txtNombreCarpeta.Text != "")
                {
                    carpetaNueva.nombre = txtNombreCarpeta.Text;
                    carpetaNueva.fk_idUsuario = Globales.GetUsuarioActual().idUsuario;
                    carpetaNueva.fk_idCarpetaPadre = idCarpetaPadre;

                    try
                    {
                        gCarpetasContrasenas.addCarpetasContrasenas(carpetaNueva);
                        actualizarArbol();

                        // Mensaje temporal
                        Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha creado la nueva carpeta", "Nueva carpeta", 1);
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: No se ha podido crear la nueva carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Error: El nombre de la carpeta esta vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                carpetas_contrasenas modCarpeta = gCarpetasContrasenas.getCarpetasContrasenasByIDCarpeta((int)idCarpetaPadre);

                modCarpeta.nombre = txtNombreCarpeta.Text;

                try
                {
                    gCarpetasContrasenas.updateCarpetasContrasenas(modCarpeta);
                    actualizarArbol();
                    Utilities.Clases.MessageTemporal.MessageBoxTemporal.Show("Se ha modificado el nombre de la carpeta", "Modificar nombre carpeta", 1);
                }
                catch
                {
                    MessageBox.Show("Error: No se ha podido modificar el nombre de la carpeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void txtNombreCarpeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
