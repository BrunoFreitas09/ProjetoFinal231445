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
    public partial class FrmCategorias : Form
    {
        Categoria T;
        public FrmCategorias()
        {
            InitializeComponent();
        }
        void limpacontroles()
        {
            txtID.Clear();
            txtNomeCategoria.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string busca)
        {
            T = new Categoria();
            {
                categoria = busca;
            };
            dgvCategoria.DataSource = T.Consultar();
        }


        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNomeCategoria.Text == String.Empty) return;

            T = new Categoria()
            {
                categoria = txtNomeCategoria.Text,
            };
            T = new Categoria();

            limpacontroles();
            carregarGrid("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
    
            carregarGrid(txtPesquisa.Text);
        }
    }
 }
