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
    public partial class FrmCidades : Form
    {
        Cidade C;
        public FrmCidades()
        {
            InitializeComponent();
        }

        void limpacontroles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
            txtUF.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            C = new Cidade()
            {
                nome = pesquisa
            };
            dgvCidades.DataSource = C.Consultar();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            C = new Cidade()
            {
                nome = txtNome.Text,
                uf = txtUF.Text,
            };
            C.Incluir();

            limpacontroles();
            carregarGrid("");
        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            C = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            C.Alterar();

            limpacontroles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;


            if (MessageBox.Show("Deseja realizar a exclusão da Cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                C = new Cidade()
                {
                    id =int.Parse(txtID.Text)
                };
                C.Excluir();

                limpacontroles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpacontroles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void FrmCidades_Load_1(object sender, EventArgs e)
        {
            limpacontroles();
            carregarGrid("");
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["ID"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["Nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["UF"].Value.ToString();
            }
        }
    }
}
