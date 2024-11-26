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
    public partial class FrmProdutos : Form
    {
        Produto P;
        public FrmProdutos()
        {
            InitializeComponent();
        }
        public void limpaControles()
        {
            txtID.Clear();
            txtDescricao.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            P = new Produto()
            {
                descricao = pesquisa
            };
            dgvProdutos.DataSource = P.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == String.Empty) return;

            P = new Produto()
            {
                descricao = txtDescricao.Text,
            };
            P.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            P = new Produto()
            {
                id = int.Parse(txtID.Text),
                descricao = txtDescricao.Text,
            };
            P.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;


            if (MessageBox.Show("Deseja realizar a exclusão do Produto?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                P = new Produto()
                {
                    id = int.Parse(txtID.Text)
                };
                P.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtID.Text = dgvProdutos.CurrentRow.Cells["ID"].Value.ToString();
                txtDescricao.Text = dgvProdutos.CurrentRow.Cells["Nome"].Value.ToString();
            }
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }
    }
}
