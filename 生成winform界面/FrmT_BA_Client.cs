using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace CcbaSystem.Department.BA.Client
{
    /// <summary>
    /// T_BA_Client
    /// 2015/9/26 21:45:22
    /// </summary>	
    public partial class Frm_T_BA_Client : BaseDockForm
    {
        public Frm_T_BA_Client()
        {
            InitializeComponent();
            this.Text = "客户合同管理";//请改为中文名
            InitDictItem();		
        }

        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public void Frm_T_BA_Client_Load(object sender, EventArgs e)
        {
            _last_sql = string.Format("sp_Get_T_BA_Client '','{0}'", 50);
            BindData();
        }
        
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
            //初始化代码
            var sql = string.Format("sp_Search_dictionary '{0}','查询字段'", this.Text);
            var dt = ServerProxy.GetTable(sql);
            cbField.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cbField.Items.Add(dr["值"]);
            }
            if (cbField.Items.Count > 0) cbField.SelectedIndex = 0;
        }

        #region 暂不提供高级查询
        ///// <summary>
        ///// 高级查询条件语句对象
        ///// </summary>
        //private SearchCondition advanceCondition;

        ///// <summary>
        ///// 根据查询条件构造查询语句
        ///// </summary> 
        //private string GetConditionSql()
        //{
        //    //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
        //    SearchCondition condition = advanceCondition;
        //    if (condition == null)
        //    {
        //        condition = new SearchCondition();
        //        condition.AddCondition("Name", this.txtName.Text.Trim(), SqlOperator.Like);
        //    }
        //    string where = condition.BuildConditionSql().Replace("Where", "");
        //    return where;
        //}
        #endregion

        string _last_sql = string.Empty;//最后执行的sql,用于刷新界面
        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
            var dt = ServerProxy.GetTable(_last_sql);
            dgv.DataSource = dt;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["CreateAt"].Visible = false;
            dgv.Columns["statu"].Visible = false;
         }
        
        /// <summary>
        /// 查询数据操作
        /// </summary>
        protected override void btnSearch_Click(object sender, EventArgs e)
        {
            _last_sql = string.Format("sp_Get_T_BA_Client '{0}','{1}'", cbField.Text, cbKey.Text.Trim());
            BindData();
        }
        
        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FrmEdit_T_BA_Client frm = new FrmEdit_T_BA_Client(0);
            frm.OnDataSaved += OnDataSaved;
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindData();
            }
            this.Cursor = Cursors.Default;
        }
        private void OnDataSaved()
        {
            #region 新增或者编辑窗口保存后,当前界面刷新操作
            BindData();
            #endregion
        }
        //导出
        protected override void btnExport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;WinUI.ToExcel(dgv, this.Text);this.Cursor = Cursors.Default;
        }
        //高级查询
        protected override void btnAdvancedSearch_Click(object sender, EventArgs e)
        {

        }
        //双击编辑记录
        protected override void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            int rowID = int.Parse(dgv["ID", e.RowIndex].Value.ToString());
            this.Cursor = Cursors.WaitCursor;
            FrmEdit_T_BA_Client frm = new FrmEdit_T_BA_Client(rowID);
            frm.OnDataSaved += OnDataSaved;
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindData();
            }
            this.Cursor = Cursors.Default;
        }
        protected override void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        protected override void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count < 1)
            {
                MessageBox.Show("请右键选中记录.");
                return;
            }
            int row = dgv.SelectedRows[0].Index;
            if (MessageBox.Show("是否删除当前记录?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                var id = dgv["ID", row].Value.ToString();
                var sql = string.Format("sp_del_T_BA_Client {0},{1}", id, -1);
                try
                {
                    #region 更新数据
                    bool succeed = ServerProxy.UpdateProc(sql);
                    if (succeed)
                    {
                        OnDataSaved();
                        MessageBox.Show("保存成功.");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    //LogTextHelper.Error(ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
