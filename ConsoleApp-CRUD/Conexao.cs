//Biblioteca necessária para Criar nova Conexão com o SQLSERVER
using System.Data.SqlClient;

public class Conexao
{
    //Dados da Conexão
    private SqlConnection sqlConnection;
    private string connectionString = @"Data Source=Codart;Initial Catalog=BDCADASTRO;Integrated Security=True";

    public void abrirConexao() 
    {
        //Abrir nova Conexão
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
    }

    public void fecharConexao() 
    {
        //Fechar Conexão
        sqlConnection.Close();
    }

    public void executarQuery(string query) 
    {
        //Executar a query inserida
        SqlCommand command = new SqlCommand(query, sqlConnection);
        command.ExecuteNonQuery();
    }

    public SqlDataReader listarQuery(string query) 
    {
        //Criar lista de dados a partir da Query SELECT
        SqlCommand command = new SqlCommand(query, sqlConnection);
        SqlDataReader dataReader = command.ExecuteReader();
        return dataReader;
    }
}