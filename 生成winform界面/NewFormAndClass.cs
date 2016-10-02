using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 生成winform界面
{
    class NewFormAndClass
    {

        string FormString = string.Empty;
        private void BeginLoad(System.Windows.Forms.DataGridView dgv)
        {
            FormString = "using System \n using System.Text;\n using System.Data;\n using System.Drawing;\n using System.Windows.Forms;\n using System.ComponentModel;\n using System.Collections.Generic;\n";
        }

        private void Save()
        {
            //System.IO.FileStream fs = new System.IO.FileStream(@"F:\" + tabName【文件名】 +".cs", FileMode.Create); //文件名+类型
            //System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.Default);
            //sw.Write(""); ///str为文件中的文本内容
            //sw.Close();
            //fs.Close();
        }
    }
}
