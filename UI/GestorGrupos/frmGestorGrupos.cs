using MiniGestorCodigo.BL;
using MiniGestorCodigo.DM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Controls.IntroducirTexto;
using static MiniGestorCodigo.UI.frmMain;

namespace MiniGestorCodigo.UI.GestorGrupos
{
    public partial class frmGestorGrupos : Form
    {
        public Grupo SelGrupo;
        public List<Grupo> grupos;
        public List<usuarios> usuarios;
        public List<GrupoUsuario> grupoUsuarios;

        public List<usuarios> usuariosMarcados;
        public bool cargando;
        public partesPrograma partes;

        public frmGestorGrupos(partesPrograma partes)
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

        public frmGestorGrupos()
        {
            InitializeComponent();
        }

        private void btAñadir_Click(object sender, EventArgs e)
        {
            frmIntroducirTexto frm = new frmIntroducirTexto("Nombre del Grupo", "Nuevo Grupo");
            DialogResult dr=frm.ShowDialog();
            if (dr==DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frm.resultado))
                {
                    SelGrupo = new Grupo();
                    SelGrupo.NombreGrupo = frm.resultado;
                    SelGrupo=gGrupos.NewGrupo(frm.resultado);

                    ActualizarArbol();
                }
                else
                {
                    MessageBox.Show("Debe introducir un nombre");
                }
            }
        }

        private void frmGestorGrupos_Load(object sender, EventArgs e)
        {
            ActualizarArbol();
        }

        private void ActualizarArbol()
        {
            grupos = new List<Grupo>();
            grupos = gGrupos.getGrupos();

            usuarios = new List<usuarios>();
            usuarios = gUsuarios.getUsuarios();

            grupoUsuarios = new List<GrupoUsuario>();
            grupoUsuarios = gGrupos.getGruposUsuarios();
            tGrupos.Nodes.Clear();
            tUsuarios.Nodes.Clear();
            foreach (Grupo item in grupos)
            {
                tGrupos.Nodes.Add(new TreeNode { Text = item.NombreGrupo, Tag = item.idGrupo.ToString() });
            }

            foreach (usuarios item in usuarios.OrderBy(x=>x.nombre))
            {
                tUsuarios.Nodes.Add(new TreeNode { Text = item.nombre, Tag = item });
            }

        }

        private void tGrupos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tGrupos.SelectedNode != null)
            {
                cargando = true;
                foreach (TreeNode node in tUsuarios.Nodes)
                {
                    node.Checked = false;
                }
                TreeNode sel = tGrupos.SelectedNode;
                foreach (GrupoUsuario item in grupoUsuarios.Where(x=>x.idGrupo==int.Parse(sel.Tag.ToString())))
                {
                    foreach (TreeNode node in tUsuarios.Nodes)
                    {
                        if (((usuarios)node.Tag).idUsuario==item.idUsuario)
                        {
                            node.Checked = true;
                        }
                    }
                }

                SelGrupo = grupos.First(x => x.idGrupo == int.Parse(sel.Tag.ToString()));
                cargando = false; ;
            }
        }

        private void tUsuarios_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            
        }

        private void tUsuarios_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!cargando)
            {
                TreeNode node = e.Node;
                usuarios u = ((usuarios)node.Tag);
                if (node.Checked)
                {
                    if (!grupoUsuarios.Exists(x => x.idGrupo == SelGrupo.idGrupo && x.idUsuario == u.idUsuario))
                    {
                        grupoUsuarios.Add(new GrupoUsuario { idGrupo = SelGrupo.idGrupo, idUsuario = u.idUsuario });
                        gGrupos.NewGrupoUsuario(SelGrupo.idGrupo, u.idUsuario);
                    }
                }
                else
                {
                    if (grupoUsuarios.Exists(x => x.idGrupo == SelGrupo.idGrupo && x.idUsuario == u.idUsuario))
                    {
                        grupoUsuarios.Remove(grupoUsuarios.First(x => x.idGrupo == SelGrupo.idGrupo && x.idUsuario == u.idUsuario));
                        gGrupos.RemoveGrupoUsuario(SelGrupo.idGrupo, u.idUsuario);
                    }
                }
            }

        }

        private void btGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}