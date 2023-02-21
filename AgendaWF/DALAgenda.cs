using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;       // importação da bliblioteca 'Data.SQLite'
using System.Data;

namespace AgendaWF {
    public class DALAgenda {        // classe 'DALAgenda' ultiliza modificador de acesso 'public'
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";        // 'static'diz que o ue está sendo criado pertence a classe e 'path' armazenará o local onde sera guardado os dados da aplicação (Banco de dados)
        private static SQLiteConnection sQLiteConnection;       // conexão com o banco de dados

        private static SQLiteConnection Dbconnection() {        // método que fará a 'conexão' com o banco de dados
            sqliteConnection = new SQLiteConnection("Data Source=" + path);     // 'sqliteConnection' recebe um novo objeto do tipo 'SQLiteConnection' com a string de conexão
            sqliteConnection.Open();        // abria a conexão
            return sqliteConnection;
        }
    }

    public static void CriarBancoSQLite() {      // método que 'criará' o banco de dados caso não exista e por ser 'void' não retorna nada
        try {
            if(File.Exists(path) == false) {        // 'File.Exists(path) == false' se não existir um arquivo indicao pela variável 'path'
                SQLiteConnection.CreateFile(path);      // o arquivo será criado 
            }
        }
        catch {
            throw;      // se não der certo 'throw' retorna o erro
        }
    }

     public static void CriarTabelaSQLite() {        // método que criará a tabela do banco de dados caso não exista
        try {
            using(var cmd = Dbconnection().CreateCommand()) {       // libera a memória
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS Contatos(id int, nome Varchar(50), email Varchar(30)";      // comando que cria uma tabela
                cmd.ExecuteNonQuery();      // método 'ExecuteNonQuery' executa o comando e não devolve nada como retorno
            }
        }
        catch (Exception ex) {
            throw ex;      // se não der certo 'throw' retorna o erro
        }

     }

     public static DataTable GetContatos() {     // método que pegará todos os contatos que estão 'armazenados' no banco de dados
        SQLiteDataAdapter da = null;       // 'SQLiteDataAdapter' para trabalhar com os dados sqlite
        DataTable dt = new DataTable();       // é uma tabela de memória que receber´os dados
        try {
            using (var cmd = Dbconnection().CreateCommand()) {       // libera a memória
                cmd.CommandText = "SELECT * FROM Contatos";     // pegando todos os dados da tabela 'Contatos'
                da = new SQLiteDataAdapter(cmd.CommandText, Dbconnection());
                da.Fill(dt);        // método 'Fill' excuta o comando pega todos esse dados acima e armazena dentro de DataTable 'dt'
                return dt;
            }
        }
        catch (Exception ex) {

            throw ex;      // se não der certo 'throw' retorna o erro

        }
     }

     public static DataTable GetContato(int id) {     // pegando dados de apenas um contato
        SQLiteDataAdapter da = null;       
        DataTable dt = new DataTable();       
        try {
            using (var cmd = Dbconnection().CreateCommand()) {       // libera a memória
                cmd.CommandText = "SELECT * FROM Contato Where Id = " + id;     // comando pega os dados da tabela de 'Contato' toda a o coluna de um contato que tenha o 'Id' igual ao id passado
                da = new SQLiteDataAdapter(cmd.CommandText, Dbconnection());
                da.Fill(dt);        
                return dt;
            }
        }
        catch (Exception ex) {
            throw ex;      // se não der certo 'throw' retorna o erro
        }
     }


     public static void Add(Contato contato) {       // método para adiçionar um contato
        try {
            using (var cmd = Dbconnection().CreateCommand()) {       // criando um comando com 'CreateCommand' e 'using' libera a memória
                cmd.CommandText = "INSERT INTO Contatos(id, nome, email) values (@id, @nome,@email)";     // inserindo dados dentro da tabela 'Contatos' e '(@id, @nome,@email' com '@' na frente são paraâmetros
                cmd.Parameters.AddWithValue("@id", contato.Id);
                cmd.Parameters.AddWithValue("@nome", contato.Nome);     // local com paâmetros onde o comando ira executar 
                cmd.Parameters.AddWithValue("@email", contato.Email);
                cmd.ExecuteNonQuery();      // 'ExecuteNonQuery' executa p comando
            }
        }
        catch (Exception ex) {

            throw ex;      // se não der certo 'throw' retorna o erro

        }

     }

     public static void Update(Contato contato) {       // método para atualizará um contato
        try {
            using (var cmd = Dbconnection().CreateCommand()) {       // criando um comando com 'CreateCommand' e 'using' libera a memória
                cmd.CommandText = "UPDATE Contatos SET Nome = @Nome, Email = @Email, WHERE Id = @Id";     // atualizando a tabela de 'Contatos' onde 'WHERE' o 'I' desse registro for igual ao 'id' passado
                cmd.Parameters.AddWithValue("@Id", contato.Id);
                cmd.Parameters.AddWithValue("@Nome", contato.Nome);     // local com paâmetros onde o comando ira executar 
                cmd.Parameters.AddWithValue("@Email", contato.Email);
                cmd.ExecuteNonQuery();      // 'ExecuteNonQuery' executa p comando
            }
        }
        catch (Exception ex) {

            throw ex;      // se não der certo 'throw' retorna o erro

        }
     }

     public static void Delete(int id) {       // método para deletará um contato
        try {
            using (var cmd = Dbconnection().CreateCommand()) {       // criando um comando com 'CreateCommand' e 'using' libera a memória
                cmd.CommandText = "DELETE FROM Contatos where Id = @Id";     // vai 'DELETAR' um registro onde o 'Id' seje igual ao 'Id' informado
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();      // 'ExecuteNonQuery' executa p comando
            }
        }
        catch (Exception ex) {

            throw ex;      // se não der certo 'throw' retorna o erro

        }
     }
    
}
