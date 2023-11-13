using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeManagerment
{
    public partial class AddPart : Form
    {
        BindingSource data = new BindingSource();
        String mcaddress;
        int indexmax;
        int totalcode;
        int indexpart;
        public AddPart()
        {
            InitializeComponent();
            rbtn_add.Checked = true;
            try
            {
                loaddata();
                getdatamasterbymachine();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void loaddata()
        {
            DataTable dt = DBConnect.StoreFillDS("getdatamaster", CommandType.StoredProcedure);
            // dtg_createnew.DataSource = dt;
            data.DataSource = dt;
            dtg_createnew.DataSource = data;
            dtg_createnew.Columns["indexpart"].Visible = false;
            DataTable dt1 = DBConnect.StoreFillDS("getdatamastercombobox", CommandType.StoredProcedure);
            cmb_function.DataSource = dt1;
            cmb_function.DisplayMember = "NameMachine";
            cmb_function.ValueMember = "NameMachine";
        }

        private void rbtn_add_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_add.Checked)
            {
                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                cmb_namepart.Visible = false;
                cmb_datatype.Enabled = true;

            }
        }

        private void rbtn_delete_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_delete.Checked)
            {
                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                cmb_namepart.Visible = true;
                cmb_datatype.Enabled = false;
                if (cmb_function.SelectedItem != null)
                {

                    getdatamasterbymachine();
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
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
                    string query = $"ALTER TABLE {cmb_function.Text}\r\nADD {txb_namepart.Text} {datatype};";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                if (result != 0)
                {
                    DBConnect.excutenonquery("addmaster", CommandType.StoredProcedure, mcaddress, cmb_function.Text,indexmax+1, txb_namepart.Text, cmb_devicetype.Text, Convert.ToInt32(num_startdevice.Value), cmb_datatype.Text, Convert.ToInt32(num_lenghtdevice.Value),totalcode);
                    MessageBox.Show("Thêm thành công");
                    loaddata();
                }
                getdatamasterbymachine();
            }
            catch (Exception ex)
            {
                if (result != 0)
                {
                    using (SqlConnection conn = new SqlConnection(DBConnect.connection_string))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand($"ALTER TABLE {cmb_function.Text}\r\nDROP COLUMN {txb_namepart.Text};", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                MessageBox.Show(ex.Message);

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
               int rs = (int)DBConnect.excutenonquery("updatepart", CommandType.StoredProcedure, cmb_function.Text, cmb_namepart.Text,cmb_devicetype.Text,Int32.Parse(num_startdevice.Value.ToString()),Int32.Parse(num_lenghtdevice.Value.ToString()));
                if (rs != 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    loaddata();
                    getdatamasterbymachine();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    loaddata();
                    getdatamasterbymachine();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (indexpart > 1)
                {
                    DataTable dt = DBConnect.StoreFillDS("deletepart", CommandType.StoredProcedure, cmb_function.Text, cmb_namepart.Text);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Xóa thành công");
                        loaddata();
                        getdatamasterbymachine();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                        loaddata();
                        getdatamasterbymachine();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa dữ liệu này");
                }
              
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cmd_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                getdatamasterbymachine();
            
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            data.Filter = $"Namemachine LIKE '%{txb_search.Text}%'";
            dtg_createnew.DataSource = data;
        }

        private void cmb_function_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_function.SelectedItem != null)
            {
                DataTable dt = DBConnect.StoreFillDS("getdatamasterbymachine", CommandType.StoredProcedure, cmb_function.SelectedItem.ToString());
                cmb_namepart.DataSource = dt;
                cmb_namepart.DisplayMember = "Namepart";
            }
        }
        public void getdatamasterbymachine()
        {
            if (cmb_function.SelectedItem != null)
            {
                List<datamaster> dtm = new List<datamaster>();
                DataTable dt = DBConnect.StoreFillDS("getdatamasterbymachine", CommandType.StoredProcedure, cmb_function.SelectedValue.ToString());
                if (dt.Rows.Count > 0)

                {
                    mcaddress = dt.Rows[0]["McAddress"].ToString();
                    indexmax = (int)dt.Rows[0]["indexpart"];
                    totalcode = (int)dt.Rows[0]["TotalCode"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtm.Add(new datamaster(dt.Rows[i]["McAddress"].ToString(), dt.Rows[i]["Namepart"].ToString(), dt.Rows[i]["DeviceType"].ToString(), (int)dt.Rows[i]["StartDevice"], dt.Rows[i]["DataType"].ToString(), (int)dt.Rows[i]["LenghtDevice"], (int)dt.Rows[i]["TotalCode"], (int)dt.Rows[i]["indexpart"]));
                    }
                }
                cmb_namepart.DataSource = dtm;
                cmb_namepart.DisplayMember = "namepart";
            }
           
        }

        private void cmb_namepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_namepart.SelectedItem != null && rbtn_delete.Checked)
            {
                
                datamaster mydt = (datamaster)cmb_namepart.SelectedItem;
                cmb_devicetype.Text = mydt.DeviceType;
                num_startdevice.Value = mydt.StartDevice;
                cmb_datatype.Text = mydt.DataType;
                num_lenghtdevice.Value = mydt.LenghtDevice;
                indexpart = mydt.index;
              

            }
           

        }
    }
}
