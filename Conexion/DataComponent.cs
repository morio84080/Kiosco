using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using ctc3DES;

namespace Conexion
{
    public class SqlDataConfiguration
    {
        private static string connectionString = "";

        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
    }
    public class SqlDataComponent
    {
        private SqlConnection conn;
        private SqlTransaction trans;
        ctc3DES.TripleDESUtil ctc = new TripleDESUtil();

        public SqlDataComponent()
        {
            string cnn = ConfigurationManager.ConnectionStrings["CNN"].ConnectionString;

            try
            {
                cnn = ctc.DesEncriptar(cnn);
            }
            catch
            {
                cnn = ConfigurationManager.ConnectionStrings["CNN"].ConnectionString;
            }

            conn = new SqlConnection(cnn);
        }

        public SqlConnection ActiveConnection
        {
            get { return conn; }
            set
            {
                if (conn != null) conn.Dispose();
                conn = value;
            }
        }

        public SqlTransaction ActiveTransaction
        {
            get { return trans; }
            set
            {
                if (trans != null) trans.Dispose();
                trans = value;
            }
        }
        public void BindTrans(SqlConnection conn, SqlTransaction trans)
        {
            this.ActiveConnection = conn;
            this.ActiveTransaction = trans;
        }
        public void BeginTrans()
        {
            PrepareConnection();
            trans = conn.BeginTransaction();
        }
        public void RollBackTrans()
        {
            trans.Rollback();
        }
        public void CommitTrans()
        {
            trans.Commit();
        }
        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            cmd.Connection = conn;
            PrepareConnection();
            if (trans != null && trans.Connection != null) cmd.Transaction = trans;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        protected DataSet ExecuteDataSet(SqlCommand cmd)
        {
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            PrepareConnection();
            if (trans != null && trans.Connection != null) cmd.Transaction = trans;
            da.Fill(ds);
            LeaveConnection();
            return ds;
        }

        protected void CloseConexion()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }
        protected int ExecuteNonQuery(SqlCommand cmd)
        {
            int ret;
            cmd.Connection = conn;
            PrepareConnection();
            if (trans != null && trans.Connection != null) cmd.Transaction = trans;
            ret = cmd.ExecuteNonQuery();
            LeaveConnection();
            return ret;
        }
        private void PrepareConnection()
        {
            // Si la transacción no existe, entonces abre la conexión.
            if (conn.State == ConnectionState.Closed) conn.Open();
        }
        private void LeaveConnection()
        {
            // Si la transacciónno existe, entonces cierra la conexión.
            if ((trans == null) || (trans.Connection == null)) conn.Close();
        }


    }

}
