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
        Marca M;
        public FrmMarcas()
        {
            InitializeComponent();
        }

        void limpacontroles()
        {
            txtID.Clear();
            txtNomeMarca.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            M = new Marca()
            {
                NomeMarca = pesquisa
            };
            dgvMarca.DataSource = M.Consultar();
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
            if (txtNomeMarca.Text == String.Empty) return;

            M = new Marca()
            {
                NomeMarca = txtNomeMarca.Text,
            };
            M.Incluir();

            limpacontroles();
            carregarGrid("");
        }



        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;
            M = new Marca()
            {
                id = int.Parse(txtID.Text),
                NomeMarca = txtNomeMarca.Text,
                
            };
            M.Alterar();

            limpacontroles();
            carregarGrid("");
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




        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            limpacontroles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;


            if (MessageBox.Show("Deseja realizar a exclusão da Marca?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                M = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };
                M.Excluir();

                limpacontroles();
                carregarGrid("");
            }
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarca.RowCount > 0)
            {
                txtID.Text = dgvMarca.CurrentRow.Cells["ID"].Value.ToString();
                txtNomeMarca.Text = dgvMarca.CurrentRow.Cells["Nome"].Value.ToString();

            }
        }
    }
    }

