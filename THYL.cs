using QuickSupport_v2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuickSupport_v2
{
    public partial class THYL : DevExpress.XtraEditors.XtraForm
    {
        public string TOATHUOC_ID { get; set; }
        public string BENHVIEN_ID { get; set; }
        public List<QuerySql> SQuery { get; set; }
        public SqlConnection connection { get; set; }
        public THYL()
        {
            InitializeComponent();
        }
        private void THYL_Load(object sender, EventArgs e)
        {
            string queryString = SQuery[0].query;
            FPT.Framework.Data.DataObject param = SQuery[0].param;
            param["TOATHUOC_ID"] = TOATHUOC_ID;

            DataTable source = DbTool.DbTool.Query(connection, queryString, param);
            gridControl1.DataSource = source;

            string queryString1 = SQuery[1].query;
            DataTable source1 = DbTool.DbTool.Query(connection, queryString1, param);
            gridControl8.DataSource = source1;

            string queryString2 = SQuery[2].query;
            DataTable source2 = DbTool.DbTool.Query(connection, queryString2, param);
            gridControl2.DataSource = source2;

            string queryString3 = SQuery[3].query;
            DataTable source3 = DbTool.DbTool.Query(connection, queryString3, param);
            gridControl3.DataSource = source3;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0 && string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Nhập người thực hiện vô");
                return;
            }
            string queryString3 = SQuery[4].query;

            FPT.Framework.Data.DataObject param = SQuery[4].param;
            param["TOATHUOC_ID"] = TOATHUOC_ID;
            param["BENHVIEN_ID"] = BENHVIEN_ID;
            param["NGUOITHUCHIEN"] = textBox7.Text;
            try
            {
                DbTool.DbTool.ExcuteStored(connection, queryString3, param);

                DataTable source = DbTool.DbTool.Query(connection, SQuery[0].query, new FPT.Framework.Data.DataObject() { ["TOATHUOC_ID"] = TOATHUOC_ID });
                gridControl1.DataSource = source;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}