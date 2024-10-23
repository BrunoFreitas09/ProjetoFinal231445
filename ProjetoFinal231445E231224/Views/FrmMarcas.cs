using ProjetoFinal231445E231224.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal231445E231224.Views
{
    public partial class FrmMarcas : Form
        Marca M
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }
        void limpacontroles () 
        {
            txtID.Clear();
            txtNomeMarca.Clear();
            txtPesquisa.Clear();
          
        }

        void carregarGrid(string pesquisa)
        {
            M = new Marca()
            {
                Marca = pesquisa
            };
            dgvMarca.DataSource = M.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNomeMarca.Text == String.Empty) return;

             = new Cidade()
            {
                nome = txtNomeMarca.Text,

            };
            M.Incluir();

            limpacontroles();
            carregarGrid("");
        }
    }
}
