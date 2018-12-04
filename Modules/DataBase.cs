using System;
using MySql.Data.MySqlClient;

namespace WebAPI2.Modules
{
    public class Mysql
    {
        private MySqlConnection conn;

        public Mysql()
        {
            this.conn = GetConnection();
        }

        private MySqlConnection GetConnection()
        {
            string host = "myDB";
            string user = "root";
            string pwd = "1234";
            string db = "test";

            string connStr = string.Format(@"server={0};user={1};password={2};database={3}", host, user, pwd, db);
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                return conn;
            }

            catch
            {
                return null;
            }
        }

        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                //MessageBox.Show("MS-SQL 연결끊기 성공!");
                return true;
            }
            catch
            {
                //MessageBox.Show("MS-SQL 연결끊기 실패!");
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }
    }
}