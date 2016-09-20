using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace 生成winform界面.Access
{
    class AccessSet
    {
        private OleDbConnection _oleDbConn;
        private OleDbDataAdapter _oleDbAda;
        public string s = string.Empty;
        private string ListD = @"provider=microsoft.jet.oledb.4.0; Data Source=";
    }
}
