using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ITC__vol_0_ {
    public class ConnectionSql {
        private string server, password, user, database, port;

        private MySqlConnection con;
        private MySqlCommand com;
        public ConnectionSql (string server, string password, string user, string database, string port) {
            this.server = server;
            this.password = password;
            this.user = user;
            this.database = database;
            ths.port port;

            Connecte ();
        }

        private void Connecte () {
            try {
                string connectionString = @"server =" + server + ";port = " + port + " ; uid =" + user + ";pwd=" + password + ";database =" + database + ";charset = utf8;SslMode=none;";
                con = new MySqlConnection (connectionString);
                con.Open ();

            } catch (SqlException e) {

                MessageBox.Show (  e.Message);
            }
        }

        public DataTable GetTable (string command) {
            DataTable r = new DataTable ();

            MySqlDataAdapter adapter = new MySqlDataAdapter (command, con);
            adapter.Fill (r);

            return r;
        }

        public void ExcuteCommand (string command) {
            //con.Open();
            com = con.CreateCommand ();
            com.CommandText = command;
            com.CommandType = CommandType.Text;

            com.ExecuteNonQuery ();
        }
        public void CloseConnection () {
            con.Close ();

        }

    }
}