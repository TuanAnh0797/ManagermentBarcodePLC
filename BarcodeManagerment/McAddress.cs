using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeManagerment
{
    public partial class McAddress : Form
    {
        BindingSource data = new BindingSource();
        public McAddress()
        {
            InitializeComponent();
            rbtn_add.Checked = true;
            try
            {
                loaddata();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        public void loaddata()
        {
            DataTable dt = DBConnect.StoreFillDS("getmcaddress",CommandType.StoredProcedure);
            List<datamcaddress> dts = new List<datamcaddress>();
            data.DataSource = dt;
            dtg_createnew.DataSource = data;
            //
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dts.Add(new datamcaddress(dt.Rows[i]["NameMachine"].ToString(), dt.Rows[i]["Ipaddress"].ToString(), (int)dt.Rows[i]["PortNumber"]));
                }
            }
            cmb_namemachine.DataSource = dts;
            cmb_namemachine.DisplayMember = "Namemachine";

        }
        private void rbtn_add_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_add.Checked)
            {
                btn_add.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                txb_namemachine.Visible = true;
                cmb_namemachine.Visible = false;
                txb_ipaddress.Text = "";
                num_portnumber.Value = 0;
            }
            
        }

        private void rbtn_updatedelete_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rbtn_updatedelete.Checked)
            {
                btn_add.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;
                txb_namemachine.Visible = false;
                cmb_namemachine.Visible = true;
            }
            if (cmb_namemachine.SelectedItem != null)
            {
                if (rbtn_updatedelete.Checked)
                {
                    datamcaddress dt = (datamcaddress)cmb_namemachine.SelectedItem;
                    txb_ipaddress.Text = dt.Address;
                    num_portnumber.Value = dt.portnumber;
                }

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
               DBConnect.excutenonquery("addmcaddress", CommandType.StoredProcedure, txb_namemachine.Text, txb_ipaddress.Text, Convert.ToInt32(num_portnumber.Value));
               loaddata();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn chắc chắn muốn cập nhật: {txb_namemachine.Text}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DBConnect.excutenonquery("updatemcaddress", CommandType.StoredProcedure, cmb_namemachine.Text, txb_ipaddress.Text, Convert.ToInt32(num_portnumber.Value));
                    loaddata();
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
                if (MessageBox.Show($"Bạn chắc chắn muốn xóa: {txb_namemachine.Text}", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DBConnect.excutenonquery("deletemcaddress", CommandType.StoredProcedure, cmb_namemachine.Text);
                    loaddata();
                }
                
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txb_search_TextChanged(object sender, EventArgs e)
        {
            data.Filter = $"Namemachine LIKE '%{txb_search.Text}%'";
            dtg_createnew.DataSource = data;
        }

        private void cmb_namemachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_namemachine.SelectedItem != null)
            {
                if (rbtn_updatedelete.Checked)
                {
                    datamcaddress dt = (datamcaddress)cmb_namemachine.SelectedItem;
                    txb_ipaddress.Text = dt.Address;
                    num_portnumber.Value = dt.portnumber;
                }
               
            }
           
        }
    }
}
