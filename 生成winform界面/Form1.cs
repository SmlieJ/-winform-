using System;
using System.Collections.Generic;
//using System.ComponentModdel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 生成winform界面
{
    public partial class Form1 : Form
    {
        Object connclass;
        private string dd = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CboLoadSql_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strconn = string.Empty;
            if (CboLoadSql.Text.Trim() == "SQL Server")
            {
                strconn = System.Configuration.ConfigurationSettings.AppSettings["SQLconn"];
                label4.Text = "地址：" + strconn;
            }


            if (string.IsNullOrEmpty(strconn))
            {
                MessageBox.Show("没有连接字符串");
                return;
            }
            StartLoad();
            
        }

        private void StartLoad()
        {
            NewAddClass frm = new NewAddClass();
            DataTable dt= frm.ReturnTableName(CboLoadSql.Text.Trim());
            CboSoureName.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                CboSoureName.Items.Add(dr[0].ToString());
            }
        }

        private void CboSoureName_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewAddClass frm = new NewAddClass();
            DataTable dt = frm.ReturnTable(CboSoureName.Text.Trim(),CboLoadSql.Text.Trim());
            CbxTableName.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                CbxTableName.Items.Add(dr[0].ToString());
            }
        }

        private void CbxTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewAddClass frm = new NewAddClass();
            DataTable dt = frm.GetColumnsType(CbxTableName.Text.Trim(), CboSoureName.Text.Trim(), CboLoadSql.Text.Trim());
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
