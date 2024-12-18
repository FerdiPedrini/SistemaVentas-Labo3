﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List <Usuario> TEST = new CN_Usuario().listar();
            Usuario ousuario = new CN_Usuario().listar().Where(u => u.Documento == txtNroDocu.Text && u.Clave
                == txtClave.Text).FirstOrDefault();

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
           else
            {
                MessageBox.Show("No se encontró el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Evento para que cuando se cierre el form, se vuelva a al ingreso de datos
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtNroDocu.Text = "";
            txtClave.Text = "";
            this.Show();
        }
    }
}
