using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 生成winform界面.SQL
{
    class SQLset
    {
        #region
        //Ticket ticket = new Ticket();    //实例化一下我们自定义的Ticket类型
        ////实现一下契约的添加方法
        //public void Add_Ticket(int count)
        //{
        //    this.ticket.HowMany = this.ticket.HowMany + count;
        //}
        ////实现一下契约的购买方法
        //public int Buy_Tickets(int Num)
        //{
        //    if (this.ticket.BoolTicket)
        //    {
        //        this.ticket.HowMany = this.ticket.HowMany - Num;
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        ////实现一下契约的查询方法
        //public int GetdemandNum()
        //{
        //    return this.ticket.HowMany;
        //}
        #endregion
        /// <summary>
        /// 获取连接数据库的字符串
        /// </summary>
        public string strconn = System.Configuration.ConfigurationSettings.AppSettings["conn"].ToString();
        /// <summary>
        /// 日期时间
        /// </summary>
        /// <returns>服务器日期时间</returns>
        public DateTime ServerTime()
        {
            DateTime dtime = DateTime.Now.Date;
            return dtime;
        }
        /// <summary>
        /// 执行查询，返回DataSet
        /// </summary>
        /// <param name="strcmd">参数</param>
        /// <returns></returns>
        public System.Data.DataSet ExecuteDataSet(string strcmd)
        {
            System.Data.DataSet ds = null;
            using (SqlConnection sqlconn = new SqlConnection(strconn))
            {
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand(strcmd, sqlconn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlcmd;
                ds = new System.Data.DataSet();
                sda.Fill(ds);
                sqlconn.Close();

            }
            return ds;
        }
        /// <summary>
        /// 执行查询，返回Table
        /// </summary>
        /// <param name="strcmd">参数</param>
        /// <returns></returns>
        public System.Data.DataTable ExecutTable(string strcmd)
        {
            System.Data.DataTable dt = null;
            using (SqlConnection sqlconn = new SqlConnection(strconn))
            {
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand(strcmd, sqlconn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sqlcmd;
                dt = new System.Data.DataTable("table1");
                sda.Fill(dt);
                sqlconn.Close();
            }
            return dt;
        }
        /// <summary>
        /// 返回影响行数
        /// </summary>
        /// <param name="strcmd">参数</param>
        /// <returns></returns>
        public int ExecutSQL(string strcmd)
        {
            int Impact = 0;
            using (SqlConnection sqlconn = new SqlConnection(strconn))
            {
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand(strcmd, sqlconn);
                sqlcmd.CommandType = System.Data.CommandType.Text;
                Impact = sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
            }
            return Impact;
        }
        /// <summary>
        /// 返回影响的一个数据
        /// </summary>
        /// <param name="strcmd">参数</param>
        /// <returns></returns>
        public object ExecutSQLobject(string strcmd)
        {
            object Impact = null;
            using (SqlConnection sqlconn = new SqlConnection(strconn))
            {
                SqlCommand cmd = new SqlCommand(strcmd, sqlconn);
                sqlconn.Open();
                Impact = cmd.ExecuteScalar();
                sqlconn.Close();

            }
            return Impact;
        }
        #region DataReader不实用
        /// <summary>
        ///  返回一行一行读取数据
        /// </summary>
        /// <param name="strcmd"></param>
        private void ExecutDataReader(string strcmd)
        {
            using (SqlConnection sqlconn = new SqlConnection(strconn))
            {
                //打开连接
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(strcmd, sqlconn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                }
                dr.Close();
                sqlconn.Close();
            }
        }
        #endregion
        //#region 防注入

        //#endregion
    }

}
