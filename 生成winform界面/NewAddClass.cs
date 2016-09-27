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

        /// <summary>
        /// 返回数据库的表名
        /// </summary>
        /// <param name="TableName">数据库名</param>
        /// <param name="DataBase">数据库类型</param>
        /// <returns></returns>
        private System.Data.DataTable ReturnTable(string TableName,string DataBase)
        {
            string sql = string.Empty;
            System.Data.DataTable dt = new System.Data.DataTable();
            switch (DataBase)
            {
                case "SQL Server":
                    sql = string.Format("select name from {0}.sys.tables",TableName);
                    dt = SQLSet.ExecutTable(sql);
                    return dt;
                case "Access": return dt; 
                case "Oracle": return dt; 
                case "ListSQL": return dt; 
            }
            return dt;
        }

        private void GetColumnsType(string TableName, string DataBase)
        {
           
        }

        private void ReturnTableName(string SoureName, string DataBase)
        {

        }
        

    }
}
