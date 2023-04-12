using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrySP1_Cantallops
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

           



            ClsRespuesto objRepuesto = new ClsRespuesto();
            objRepuesto.codigo = Convert.ToInt32(txtCodigo.Text);
            objRepuesto.nombre = txtNombre.Text;
            objRepuesto.marca = cmbMarca.Text;
            objRepuesto.precio = Convert.ToInt32(txtPrecio.Text);

            if (optImportado.Checked)
            {
                objRepuesto.origen = "Importado";
            }
            else
            {
                objRepuesto.origen = "Nacional";
            }

            MessageBox.Show("Grabacion Exitosa");

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != null && txtCodigo.Text != null & txtPrecio.Text != null && cmbMarca.SelectedIndex != -1)
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsulta abrirConsulta = new frmConsulta();
            abrirConsulta.ShowDialog();

        }
    }
}
