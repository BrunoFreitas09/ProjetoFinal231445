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
        
    {
        Marca m;
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
            m = new Marca()
            {
                Marca = pesquisa
            };
            dgvMarca.DataSource = m.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNomeMarca.Text == String.Empty) return;

             = new Cidade()
            {
                nome = txtNomeMarca.Text,

            };
            m.Incluir();

            limpacontroles();
            carregarGrid("");
        }

        private void btnIncluir_Click_1(object sender, EventArgs e)
        {

        }
    }
}
