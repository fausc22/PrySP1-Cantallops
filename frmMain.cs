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

        private const string PATH_ARCHIVO = "Repuestos.txt";

        private void Inicializar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cmbMarca.Items.Clear();
            cmbMarca.Items.Add("Marca A");
            cmbMarca.Items.Add("Marca B");
            cmbMarca.Items.Add("Marca C");
            cmbMarca.SelectedIndex = 0;
            optNacional.Checked = true;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            Inicializar();
        }


        private bool ValidarDatos()
        {
            bool resultado = false;
            if (txtCodigo.Text != "")
            {
                if (txtNombre.Text != "")
                {
                    if (txtPrecio.Text != "")
                    {
                        ClsArchivo Repuestos = new ClsArchivo();
                        Repuestos.NombreArchivo = PATH_ARCHIVO;
                        if (Repuestos.BuscarCodigoRepuesto(txtCodigo.Text) == false)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }

        private ClsRepuesto CrearRepuesto()
        {
            ClsRepuesto nuevoRep = new ClsRepuesto();
            nuevoRep.codigo = txtCodigo.Text;
            nuevoRep.nombre = txtNombre.Text;
            nuevoRep.marca = cmbMarca.SelectedIndex.ToString();
            nuevoRep.precio = decimal.Parse(txtPrecio.Text);
            if (optNacional.Checked)
            {
                nuevoRep.origen = "Nacional";
            }
            else
            {
                nuevoRep.origen = "Importado";
            }
            return nuevoRep;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                ClsRepuesto nuevoRep = CrearRepuesto();
                ClsArchivo Repuestos = new ClsArchivo();
                Repuestos.NombreArchivo = PATH_ARCHIVO;
                Repuestos.GrabarRepuesto(nuevoRep);
                Inicializar();
            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           



            

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != null && txtCodigo.Text != null & txtPrecio.Text != null && cmbMarca.SelectedIndex != -1)
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (int)Keys.Back )
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && txtPrecio.Text.Contains (",") )
            {
                e.Handled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            frmConsulta abrirConsulta = new frmConsulta(PATH_ARCHIVO);
            abrirConsulta.ShowDialog();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
