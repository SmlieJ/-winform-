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
            switch (CboLoadSql.Text.Trim())
            {

            }
        }
    }
}
