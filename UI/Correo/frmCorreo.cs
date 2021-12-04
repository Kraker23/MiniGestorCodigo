using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniGestorCodigo.DM;
using MiniGestorCodigo.BL;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using static MiniGestorCodigo.UI.frmMain;
using Utilities.Controls.IntroducirTexto;
using Utilities.Extensions;
using Utilities.Controls.Leyenda;
using Utilities.Clases.MessageTemporal;

namespace MiniGestorCodigo.UI
{
    public partial class frmCorreo : Form
    {
        #region Variables

        public List<usuarios> usuarios;
        public Utilities.Controls.Leyenda.Menu.MenuButton btUsuarios;
        private List<Usuariofiltro> filtroUsuarios;
        private bool abiertofiltroUsuarios;

        private bool CCvisible = false;
        private bool CCOvisible = false;

        private List<string> lCc = new List<string>();
        private List<string> lCco = new List<string>();
        private List<string> archivosAdjuntos = new List<string>();

        private List<string> correosElectronicos = new List<string>();

        // Datos del SMTP de Outlook para enviar correos
        private const string smtpHostOutlook = "smtp.eskape.es";
        private const int smtpPuertoOutlook = 25;
        public partesPrograma partes;
        #endregion


        #region Constructor

        public frmCorreo(partesPrograma partes)
            : this()
        {
            this.partes = partes;

            switch (partes)
            {
                case partesPrograma.Main: this.Text = "Gestor"; break;
                case partesPrograma.Codigo: this.Text = "Gestor de Codigo"; break;
                case partesPrograma.Notas: this.Text = "Gestor de Notas"; break;
                case partesPrograma.PersonasGrupo: this.Text = "Gestor de Grupo"; break;
                case partesPrograma.PersonasUsuarios: this.Text = "Gestor de Usuarios"; break;
                case partesPrograma.Correo: this.Text = "Correo Electronico"; break;
                case partesPrograma.Contraseñas: this.Text = "Gestor de Contraseñas"; break;
                case partesPrograma.H_SeparadorTexto: this.Text = "Herramientas Separador Texto"; break;
                case partesPrograma.H_MoverArchivos: this.Text = "Herramientas Mover Archivos"; break;
                case partesPrograma.H_EncriptarPassword: this.Text = "Herramientas Encriptar Password"; break;
                default:
                    break;
            }
        }
        public frmCorreo()
        {
            InitializeComponent();

            CrearBTUsuarios();

            lEmisor.Text = "Para: ";

            txtCC.Visible = false;
            lbCC.Visible = false;
            btnAddCC.Visible = false;
            CCvisible = false;

            txtCCO.Visible = false;
            lbCCO.Visible = false;
            btnAddCCO.Visible = false;
            CCOvisible = false;

            foreach (usuarios usr in gUsuarios.getUsuarios())
            {
                correosElectronicos.Add(usr.correo);
            }
        }
        #endregion


        #region CC / CCO
        // Mostrar
        private void btnCC_Click(object sender, EventArgs e)
        {
            if (!CCvisible)
            {
                txtCC.Visible = true;
                lbCC.Visible = true;
                btnAddCC.Visible = true;
                CCvisible = true;
            }
            else
            {
                txtCC.Visible = false;
                lbCC.Visible = false;
                btnAddCC.Visible = false;
                CCvisible = false;
            }
        }

        private void btnCCO_Click(object sender, EventArgs e)
        {
            if (!CCOvisible)
            {
                txtCCO.Visible = true;
                lbCCO.Visible = true;
                btnAddCCO.Visible = true;
                CCOvisible = true;
            }
            else
            {
                txtCCO.Visible = false;
                lbCCO.Visible = false;
                btnAddCCO.Visible = false;
                CCOvisible = false;
            }
        }


        // Añadir
        private void btnAddCC_Click(object sender, EventArgs e)
        {
            if (lCc.Contains(txtCC.Text))
                lCc.Remove(txtCC.Text);
            else
                lCc.Add(txtCC.Text);

            txtCC.Text = "";

            actualizarListaCC();
        }

        private void btnAddCCO_Click(object sender, EventArgs e)
        {
            if (lCco.Contains(txtCCO.Text))
                lCco.Remove(txtCCO.Text);
            else
                lCco.Add(txtCCO.Text);

            txtCCO.Text = "";

            actualizarListaCCO();
        }


        //Actualizar listas
        private void actualizarListaCC()
        {
            lbCC.Items.Clear();

            foreach (string item in lCc)
            {
                lbCC.Items.Add(item);
            }
        }

        private void actualizarListaCCO()
        {
            lbCCO.Items.Clear();

            foreach (string item in lCco)
            {
                lbCCO.Items.Add(item);
            }
        }

        #endregion


        #region Archivos adjuntos
        private void btnArchivosAdjuntos_Click(object sender, EventArgs e)
        {
            string pathArchivo = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Selecccionar Archivo";
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pathArchivo = dlg.FileName;

                if (!archivosAdjuntos.Contains(pathArchivo))
                {
                    archivosAdjuntos.Add(pathArchivo);
                }

                cargarListaArchivosAdjuntos();
            }
        }

        /// <summary>
        /// Convertir un archivo a un array de Bytes
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Byte[] convertirArchivoABinario(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        /// <summary>
        /// Convertit un array de Bytes a un archivo
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes">array de Bytes</param>
        private void convertirBinarioAArchivo(string path, Byte[] bytes)
        {
            string directorioActual = Directory.GetCurrentDirectory();
            string pathCarpeta = string.Format(@"{0}\correo", path);


            if (!Directory.Exists(pathCarpeta))
            {
                Directory.CreateDirectory(pathCarpeta);
            }

            Directory.SetCurrentDirectory(pathCarpeta);

            string pathArchivo = string.Format(@"{0}\{1}", pathCarpeta, Path.GetRandomFileName());

            System.IO.File.WriteAllBytes(pathArchivo, bytes);
        }

        private void cargarListaArchivosAdjuntos()
        {
            lbArchivosAdjuntos.Items.Clear();

            foreach (string item in archivosAdjuntos)
            {
                lbArchivosAdjuntos.Items.Add(item);
            }
        }
        #endregion


        #region Validaciones

        private bool validarCamposCompletos()
        {
            bool result = true;

            if (txtAsunto.Text.Count() < 3)
            {
                if (MessageBox.Show("No tiene Asunto. Desea enviarlo Igualmente?","Falta Asunto",MessageBoxButtons.YesNo)==DialogResult.No)
                return false;
            }

            if ((!txtEmisor.Text.Contains('@')) && (filtroUsuarios.Where(x=>x.activado==true).Count()==0))
            {
                return false;
                // mesaje temporal avisando que el correo de destinatario no es correcto
            }

            if (rtxtMensaje.Text.Count() < 5)
                if (MessageBox.Show("No tiene Mensaje. Desea enviarlo Igualmente?", "Falta Mensaje", MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
                
            if (Globales.GetUsuarioActual().pswdCorreo==null)
            {
                if (MessageBox.Show("No tiene Configurada la contraseña del Correo. Desea introducir la (solo requerido una vez)?, Si no la introduce no se puede enviar el correo.",
                    "Falta Contraseña",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    frmIntroducirTexto frm = new frmIntroducirTexto("Introducir Contraseña", "Introducir Contraseña del correo",true);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(frm.resultado))
                        {
                            string ContraseñaCorreo = frm.resultado;
                            usuarios u = Globales.GetUsuarioActual();
                            string codificarPass = ContraseñaCorreo.EncryptAES();
                            u.pswdCorreo = codificarPass;
                            gUsuarios.modUsuario(u);
                            Globales.SetUsuarioActual(gUsuarios.getUsuarioById(u.idUsuario));
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
               
            }

            return result;
        }

        #endregion

        #region Envio

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (validarCamposCompletos())
            {
                crearCorreo(txtEmisor.Text, txtAsunto.Text, rtxtMensaje.Text);
            }
            else
            {
                MessageBox.Show("Hay algun campo del mensaje que es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void crearCorreo(string receptor, string asunto,  string cuerpo)
        {
            MailMessage mensaje = new MailMessage();

            MailAddress mEmisor = new MailAddress(Globales.GetUsuarioActual().correo, Globales.GetUsuarioActual().nombre);
            //MailAddress mReceptor = new MailAddress(receptor);
            mensaje.From = mEmisor;
            if (!string.IsNullOrEmpty(receptor))
            {
                mensaje.To.Add(receptor);
            }
            if (filtroUsuarios.Where(x => x.activado == true).Count() > 0)
            {
                var result = String.Join("; ", filtroUsuarios.Where(x => x.activado == true).Select(x => x.correo).ToArray());
                foreach (string item in filtroUsuarios.Where(x => x.activado == true).ToList().Select(x => x.correo).ToList())
                {
                    mensaje.To.Add(item);
                }
            }

            mensaje.Subject = asunto;
            mensaje.Body = cuerpo;
            //mensaje.BodyEncoding = Encoding.UTF8;
            //mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            #region CC y CCO

            // Añadir CC
            if (lCc.Count >= 1)
                foreach (string item in lCc)
                    mensaje.CC.Add(new MailAddress(item));


            // Añadir CCO
            if (lCco.Count >= 1)
                foreach (string item in lCco)
                    mensaje.Bcc.Add(new MailAddress(item));
                

            #endregion

            // Añadir archivos adjuntos
            foreach (string archivo in archivosAdjuntos)
            {
                using (MemoryStream ms = new MemoryStream(convertirArchivoABinario(archivo)))
                {
                    // Comprobar que las rutas son correctas
                    string[] nombreArchivo = archivo.Split('\\');
                    mensaje.Attachments.Add(new Attachment(ms, nombreArchivo[nombreArchivo.Length -1]));
                }
            }

            enviarCorreo(mensaje);

        }

        private void enviarCorreo(MailMessage msg)
        {
            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = smtpHostOutlook;
            smtpClient.Port = 25;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential("r.serna@eskape.es", "Rs110618");
            smtpClient.Credentials = new NetworkCredential(Globales.GetUsuarioActual().correo, Globales.GetUsuarioActual().pswdCorreo.DecryptAES());

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

            try
            {
                smtpClient.Send(msg);
                //msg.Dispose();
                //smtpClient.Dispose();
                MessageBoxTemporal.Show("Mensaje Enviado","Correo",2);
            }
            catch
            (Exception e)
            {
                MessageBox.Show(e.Message, "Error al enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        #endregion

        #region BtUsuarios

        private void CrearBTUsuarios()
        {
            usuarios = gUsuarios.getUsuarios().OrderBy(x => x.nombre).ToList();

            btUsuarios = new Utilities.Controls.Leyenda.Menu.MenuButton();
            btUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btUsuarios.Image = global::MiniGestorCodigo.UI.Properties.Resources.reunion;
            btUsuarios.Size = new System.Drawing.Size(29, 22);
            btUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;// "Leyenda Adplanning";
            //btCompartirUsuarios.Dock = DockStyle.Right;
            btUsuarios.Location = new Point(756, 9);
            btUsuarios.BringToFront();
            btUsuarios.Click += btCompartirUsuarios_Click;


            ContextMenuStrip menu = new ContextMenuStrip();
            filtroUsuarios = new List<Usuariofiltro>();

            for (int i = 0; i < usuarios.Count(); i++)
            {
                bool activopordefecto = false;
                Random rnd = new Random();
                int rndColor = rnd.Next() * usuarios[i].idUsuario * -1;
                ToolStripCheck tch1 = new ToolStripCheck(
                    usuarios[i].nombre,
                    //Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(-65536)),
                    Utilities.Controls.Leyenda.Menu.GetImagen(System.Drawing.Color.FromArgb(rndColor)),
                    usuarios[i].idUsuario,
                    tch1ComparUsuario_Click,
                    activopordefecto);
                menu.Items.Add(tch1);
                filtroUsuarios.Add(new Usuariofiltro { user = usuarios[i].nombre, activado = activopordefecto, id = usuarios[i].idUsuario,correo= usuarios[i].correo });
                
            }


            //System.Drawing.Color.FromArgb()


            menu.AutoClose = false;
            btUsuarios.Menu = menu;
            this.Controls.Add(btUsuarios);

        }

        private void tch1ComparUsuario_Click(object sender, EventArgs e)
        {
            ActivarFiltroComparUser(((ToolStripCheck)sender).ID);
        }

        private void ActivarFiltroComparUser(int id)
        {
            if (filtroUsuarios.HasContent())
            {
                //filtroUsuarios.First(x=>x.id==id).activado = filtroUsuarios[posicion].activado ? false : true;
                filtroUsuarios.First(x => x.id == id).activado = filtroUsuarios.First(x => x.id == id).activado ? false : true;
            }

        }
        private void btCompartirUsuarios_Click(object sender, EventArgs e)
        {
            Utilities.Controls.Leyenda.Menu.MenuButton bt = sender as Utilities.Controls.Leyenda.Menu.MenuButton;
            //bt.Menu.IsDropDown
            if (bt.Menu.IsDropDown && abiertofiltroUsuarios)
            {
                bt.Menu.Close();
                abiertofiltroUsuarios = false;
            }
            else
            {
                abiertofiltroUsuarios = true;
                bt.Menu.Show();
            }
        }

        public class Usuariofiltro
        {
            public string user { get; set; }
            public int id { get; set; }
            public string correo { get; set; }
            public bool activado { get; set; }
        }
        #endregion

    }
}
