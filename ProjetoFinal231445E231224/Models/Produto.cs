using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal231445E231224.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }


        public void Incluir()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("INSERT INTO produtos (nome) VALUES (@nome)", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 

                Banco.Comando.Parameters.AddWithValue("@nome", descricao);//Parâmetro string 
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução  desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("UPDATE produtos SET nome = @nome WHERE id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@nome", descricao);//Parâmetro string 
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("DELETE FROM produtos WHERE id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("SELECT * FROM produtos WHERE descricao LIKE @nome " +   //Esse N maiúsculo é bem sus
                                                                       "ORDER BY descricao", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@nome", descricao + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.Fechar_Conexao();
                return Banco.datTabela;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
