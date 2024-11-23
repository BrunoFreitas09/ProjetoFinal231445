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
    public class Categorias
    {

        public int id { get; set; }
        public string categoria { get; set; }

            public void Incluir()
            {
                try
                {
                    //abrindo a conexão com o banco
                    Banco.Abrirconexao();
                    //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                    Banco.Comando = new MySqlCommand("INSERT INTO Categoria (categoria) VALUES (@nome)", Banco.Conexao);
                    //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 

                    Banco.Comando.Parameters.AddWithValue("@nome", categoria);//Parâmetro string 

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
                    //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                    Banco.Comando = new MySqlCommand("UPDATE produtos set categoria = @nome where id = @id", Banco.Conexao);
                    //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                    Banco.Comando.Parameters.AddWithValue("@nome", categoria);//Parâmetro string 
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
                    Banco.Comando = new MySqlCommand("SELECT * FROM produtos where categoria like @nome " +   
                                                                           "order by categoria", Banco.Conexao);
                    //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                    Banco.Comando.Parameters.AddWithValue("@nome", categoria + "%");
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

