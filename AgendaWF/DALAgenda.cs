using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;       // importação da bliblioteca 'Data.SQLite'
using System.Data;

namespace AgendaWF
{
    public class DALAgenda {        // classe 'DALAgenda' ultiliza modificador de acesso 'public'
        public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";        // 'static'diz que o ue está sendo criado pertence a classe e 'path' armazenará o local onde sera guardado os dados da aplicação (Banco de dados)
        private static SQLiteConnection sQLiteConnection;       // conexão com o banco de dados

        private static SQLiteConnection Dbconnection() {        // método que fará a 'conexão' com o banco de dados
            return new SQLiteConnection(path);
        }

        public static void CriarBancoSQLite() {      // método que 'criará' o banco de dados caso não exista e por ser 'void' não retorna nada

        }

        public static void CriarTabelaSQLite() {        // método que criará a tabela do banco de dados caso não exista

        }

        public static DataTable GetContatos() {     // método que pegará todos os contatos que estão 'armazenados' no banco de dados
            return new DataTable();
        }

        public static DataTable GetContato(int id) {      // método com código do contato 'int id' que 'localizara' um contato
            return new DataTable();
        }

        public static void Add(Contato contato) {       // método para adiçionar um contato

        }

        public static void Uodate(Contato contato) {       // método para atualizará um contato

        }

        public static void Delete(int id) {       // método para deletará um contato

        }
    }
}
