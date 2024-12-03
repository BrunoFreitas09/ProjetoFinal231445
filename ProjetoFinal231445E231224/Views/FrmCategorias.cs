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
        Categorias cat;
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
            cat = new Categorias()
            {
                categoria = busca
            };
            dgvCategoria.DataSource = cat.Consultar();
        }


        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNomeCategoria.Text == String.Empty) return;

            cat = new Categorias()
            {
                categoria = txtNomeCategoria.Text,
            };
            cat.Incluir();

            limpacontroles();
            carregarGrid("");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            limpacontroles();
            carregarGrid("");
        }

        



        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;


            if (MessageBox.Show("Deseja realizar a exclusão da Categoria?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cat = new Categorias()
                {
                    id = int.Parse(txtID.Text)
                };
                cat.Excluir();

                limpacontroles();
                carregarGrid("");
            }
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.RowCount > 0)
            {
                txtID.Text = dgvCategoria.CurrentRow.Cells["ID"].Value.ToString();
                txtNomeCategoria.Text = dgvCategoria.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            cat = new Categorias()
            {
                id = int.Parse(txtID.Text),
                categoria = txtNomeCategoria.Text

            };
            cat.Alterar();

            limpacontroles();
            carregarGrid("");
        }
    }
}

