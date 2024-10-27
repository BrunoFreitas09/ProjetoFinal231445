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
    }
}
