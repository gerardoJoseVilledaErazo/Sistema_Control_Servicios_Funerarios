using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exequie.GUI
{
    public partial class Principal : Form
    {        

        public Principal()
        {
            InitializeComponent();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataManager.GUI.Prueba f = new DataManager.GUI.Prueba();
            f.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //no se puede usar new para poder acceder a los miembros static 
            SesionManager.CLS.Sesion oSesion = SesionManager.CLS.Sesion.Instancia;
            lblUsuario.Text = oSesion.Usuario;
        }
    }
}
