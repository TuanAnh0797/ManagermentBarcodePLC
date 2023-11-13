using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeManagerment
{
    public partial class Createnewfunction : Form
    {
        BindingSource data = new BindingSource();
        public Createnewfunction()
        {
            InitializeComponent();
            getdatamaster();
            rbtn_add.Checked = true;
            try
            {
                DataTable dt =  DBConnect.StoreFillDS("getmcaddress", CommandType.StoredProcedure);
                cmb_McAddress.DataSource = dt;
                cmb_McAddress.DisplayMember = "NameMachine";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void getdatamaster()
        {
            try
            {
                dtg_createnew.DataSource = null;
                DataTable dt = DBConnect.StoreFillDS("getlisttable", CommandType.StoredProcedure);
                // dtg_createnew.DataSource = dt;
                data.DataSource = dt;
                dtg_createnew.DataSource = data;
                dtg_createnew.Columns["indexpart"].Visible = false;
                //
                List<string> datacmb = new List<string>();
                datacmb = dt.AsEnumerable().Select(row => row.Field<string>("Namemachine")).ToList();
                cmd_function.DataSource = datacmb;
                //cmd_function.DisplayMember = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
           
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            if (txb_namefunction.Text != "" && txb_namepart.Text != "" && num_lenghtdevice.Value > 0 && num_totalcode.Value>0 && cmb_McAddress.Text != "")
            {
                if (MessageBox.Show($"Bạn chắc chắn muốn thêm: {txb_namefunction.Text}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int result = 0;
                    string datatype;
                    if (cmb_datatype.Text == "Float")
                    {
                        datatype = "float";
                    }
                    else if (cmb_datatype.Text == "DEC")
                    {
                        datatype = "bigint";
                    }
                    else
                    {
                        datatype = "varchar(100)";
                    }
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                        {
                            conn.Open();
                            string query = $"CREATE TABLE {txb_namefunction.Text} (\r\n{txb_namepart.Text} {datatype});";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            result = cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        if (result != 0)
                        {
                            DBConnect.excutenonquery("addmaster", CommandType.StoredProcedure,cmb_McAddress.Text, txb_namefunction.Text,1, txb_namepart.Text, cmb_devicetype.Text, Convert.ToInt32(num_startdevice.Value), cmb_datatype.Text, Convert.ToInt32(num_lenghtdevice.Value), Convert.ToInt32(num_totalcode.Value));
                            MessageBox.Show("Thêm thành công");
                            getdatamaster();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (result != 0)
                        {
                            using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand($"DROP TABLE {txb_namefunction.Text}", conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                        MessageBox.Show(ex.Message);

                    }
                }  
            }
            else
            {
                MessageBox.Show("Chưa điền đủ thông tin");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (cmd_function.Items.Contains(cmd_function.Text))
            {
                if (MessageBox.Show($"Bạn muốn xóa: {cmd_function.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DBConnect.excutenonquery("deletemaster", CommandType.StoredProcedure, cmd_function.Text);
                        MessageBox.Show("Xóa thành công");
                        getdatamaster();
                        resetall();    
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Không có Function: {cmd_function.Text}","Thông báo");
            }





        }

        private void rbtn_add_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_add.Checked)
            {
                btn_add.Enabled = true;
                txb_namefunction.Visible = true;
                cmd_function.Visible = false;
                btn_delete.Enabled = false;
               
            }
        }

        private void rbtn_delete_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_delete.Checked)
            {
                btn_delete.Enabled = true;
                btn_add.Enabled = false;
                cmd_function.Visible=true;
                txb_namefunction.Visible = false;
            }
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
          
            
            data.Filter = $"Namemachine LIKE '%{txb_search.Text}%'";
            dtg_createnew.DataSource = data;
        }
        void resetall()
        {
            cmd_function.Text = "";
            txb_namefunction.Text = "";
            txb_namepart.Text = "";
            num_lenghtdevice.Value = 0;
            num_startdevice.Value = 0;
            num_totalcode.Value = 0;
            cmb_datatype.Text = "";
            cmb_devicetype.Text = "";

        }
    }
}
