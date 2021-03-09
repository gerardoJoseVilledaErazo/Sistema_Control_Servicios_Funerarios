﻿using System;
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
    public partial class Login : Form
    {
        //variables globales
        //String _Usuario = "JMENJIVAR";
        //String _Clave = "12345";

        Boolean _Validado = false;

        public bool Validado
        {
            get
            {
                return _Validado;
            }
            /* SOLO LECTURA POR ESO COMENTAMOS EL SET
            set
            {
                _Validado = value;
            }*/
        }

        private void Validar()
        {
            try
            {
                //aca no se puede usar new
                SesionManager.CLS.Sesion SesionInicial = SesionManager.CLS.Sesion.Instancia;
                //                    SesionInicial.IniciarSesion(txbUsuario.Text,txbClave.Text);                     
                _Validado = SesionInicial.IniciarSesion(txbUsuario.Text, txbClave.Text);
                if (_Validado)
                {              
                    Close();//se cierre porque ya se valido
                }
                else
                {
                    lblMensaje.Text = "USUARIO/CLAVE ERRONEOS, VUELVA A INTENTARLO";
                }
            }
            catch
            {
                _Validado = false;
            }
        }








        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //
            Validar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//si el código de la tecla presionada es igual código tecla enter
            {
                txbClave.Focus();
                txbClave.SelectAll();//seleccionar todo el texto que está en ese campo
            }

        }

        private void txbClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//si el código de la tecla presionada es igual código tecla enter
            {
                btnEntrar.PerformClick();//como si hubiera dado clic al botón Entrar
            }
        }
    }
}
