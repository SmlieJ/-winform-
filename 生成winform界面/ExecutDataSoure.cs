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
        public System.Data.DataTable ReturnTable(string TableName,string DataBase)
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

        /// <summary>
        /// 返回列名信息
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="DataBase">数据库类型</param>
        /// <returns></returns>
        public System.Data.DataTable GetColumnsType(string TableName, string SourceName,string DataBase)
        {
            string sql = string.Empty;
            System.Data.DataTable dt = new System.Data.DataTable();
            switch (DataBase)
            {
                case "SQL Server":
                    sql = string.Format("USE {1} SELECT T.name AS  表名, C.name as 列名, ST.name as 数据类型, C.Length as 长度 FROM dbo.sysobjects T LEFT JOIN dbo.syscolumns C ON T.id = C.id LEFT JOIN dbo.systypes ST ON C.xtype = ST.xusertype WHERE T.xtype = 'U' and t.name = '{0}'  ORDER BY T.name, C.colid ", TableName, SourceName);
                    dt = SQLSet.ExecutTable(sql);
                    return dt;
                case "Access": return dt;
                case "Oracle": return dt;
                case "ListSQL": return dt;
            }
            return dt;
        }

        /// <summary>
        /// 返回所有数据库名
        /// </summary>
        /// <param name="DataBase">数据类型</param>
        /// <returns></returns>
        public System.Data.DataTable ReturnTableName(string DataBase)
        {
            string sql = string.Empty;
            System.Data.DataTable dt = new System.Data.DataTable();
            switch (DataBase)
            {
                case "SQL Server":
                    sql = string.Format("SELECT name FROM master.dbo.sysdatabases ");
                    dt = SQLSet.ExecutTable(sql);
                    return dt;
                case "Access": return dt;
                case "Oracle": return dt;
                case "ListSQL": return dt;
            }
            return dt;
        }
        

    }
}
