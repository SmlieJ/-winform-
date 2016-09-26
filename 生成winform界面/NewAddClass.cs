using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生成winform界面
{
    class NewAddClass
    {
        string WinformString = string.Empty;

        #region 数据库连接
        SQL.SQLset SQLSet = new SQL.SQLset();
        Access.AccessSet AccessSet = new Access.AccessSet();
        Oracle.OracleSet OracleSet = new Oracle.OracleSet();
        #endregion

        private void ReturnTable(string TableName)
        {
            string sql = string.Empty;
        }

        private void GetColumnsType(string TableName)
        {
           
        }

        private void ReturnTableName(string SoureName)
        {

        }
        

    }
}
