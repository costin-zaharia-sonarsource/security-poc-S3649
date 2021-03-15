using System;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SecurityPoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoQuery(this.textBox1.Text);
        }

        private void DoQuery(string UserID)
        {
            string constr = string.Empty;
            OracleConnection con = new OracleConnection(constr);
            con.Open();

            string testSQL = "select * from THEUSER "
                           + "where USERID = '" + UserID + "'";

            OracleCommand cmd = new OracleCommand(testSQL, con);

            DataTable t = new DataTable();
            var dr = cmd.ExecuteReader();
            //create the DataTable object according to Oracle table
            t.Load(dr);
            dr.Close();


            cmd.Dispose();
            con.Dispose();
        }

        public void Bar(SqlConnection connection, string param)
        {
            SqlCommand command;
            string sensitiveQuery = string.Format("INSERT INTO Users (name) VALUES (\"{0}\")", param);
            command = new SqlCommand(sensitiveQuery); // Sensitive

            command.CommandText = sensitiveQuery; // Sensitive

            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter(sensitiveQuery, connection); // Sensitive
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
