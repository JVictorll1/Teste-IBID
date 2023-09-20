using System.Data;

public class Produto 
{
    private int ID;
    private string nome;

    //GET
    public int getId() 
    {
        return ID;
    } 
    public string getNome() 
    {
        return nome;
    }

    //SET
    public void setId(int id)  
    {
        this.ID = id;
    }
    public void setNome(string n) 
    {
        this.nome = n;
    }

    //METHODS
    public void inserir(string nome) 
    {
        //Query SQL de INSERT
        string insertQuery = $"INSERT INTO PRODUTO (NOME) VALUES ('{nome}')";
        //Instâcia do objeto 'conectar' de Conexao
        Conexao conectar = new Conexao();
        //Abrir Conexão
        conectar.abrirConexao();
        //Chama Método que executa as query's através do SQLClient chamado na classe Conexao
        conectar.executarQuery(insertQuery);
        //Fechar Conexão
        conectar.fecharConexao();
    }

    public void excluir(int id)
    {
        //Query SQL de DELETE
        string deleteQuery = $"DELETE FROM PRODUTO WHERE ID={id}";
        //Instâcia do objeto 'conectar' de Conexao
        Conexao conectar = new Conexao();
        //Abrir Conexão
        conectar.abrirConexao();
        //Chama Método que executa as query's através do SQLClient chamado na classe Conexao
        conectar.executarQuery(deleteQuery);
        //Fechar Conexão
        conectar.fecharConexao();
    }

    public void atualizar(int id, string nome)
    {
        //Query SQL de UPDATE
        string udpateQuery = $"UPDATE PRODUTO SET NOME = '{nome}' WHERE ID = {id}";
        //Instâcia do objeto 'conectar' de Conexao
        Conexao conectar = new Conexao();
        //Abrir Conexão
        conectar.abrirConexao();
        //Chama Método que executa as query's através do SQLClient chamado na classe Conexao
        conectar.executarQuery(udpateQuery);
        //Fechar Conexão
        conectar.fecharConexao();
    }

    public DataTable mostrar() 
    {
        // DataTable que recebe os valores gerados pela QUERY
        DataTable tabelaProdutos = new DataTable();
        // Criando as colunas referentes à tabela do SQLServer
        tabelaProdutos.Columns.Add("ID", typeof(int));
        tabelaProdutos.Columns.Add("NOME", typeof(string));
        //Query SQL de SELECT
        string selectQuery = $"SELECT * FROM PRODUTO";
        //Instâcia do objeto 'conectar' de Conexao
        Conexao conectar = new Conexao();
        //Abrir Conexão
        conectar.abrirConexao();
        //Atribuir à variável de tipo implícito o método que lista o conteúdo(SELECT) de uma Query
        var dataReader = conectar.listarQuery(selectQuery);
        while (dataReader.Read())
        {
            // Adicionando as linhas dos respectivos dados em suas respectivas colunas
            tabelaProdutos.Rows.Add(dataReader.GetValue(0), dataReader.GetValue(1));
        }
        //Fechar Conexão
        conectar.fecharConexao();
        //Retorna o Array com todos os dados da QUERY
        return tabelaProdutos;
    }
}