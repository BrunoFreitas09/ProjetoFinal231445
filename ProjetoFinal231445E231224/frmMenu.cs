using System;
using ProjetoFinal231445E231224.Views;
using System.Windows.Forms;

namespace ProjetoFinal231445E231224
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
            Banco.CriarTabelas();
        }

        private void CidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.Show();
            Banco.CriarTabelas();
        }

        private void marcaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMarcas form = new FrmMarcas();
            form.Show();
            Banco.CriarTabelas();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.Show();
            Banco.CriarTabelas();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.Show();
            Banco.CriarTabelas();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
            Banco.CriarTabelas();
        }
    }
}
