namespace BarcodeManagerment
{
    partial class AddPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_namepart = new System.Windows.Forms.ComboBox();
            this.cmb_function = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_namepart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_devicetype = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.num_lenghtdevice = new System.Windows.Forms.NumericUpDown();
            this.num_startdevice = new System.Windows.Forms.NumericUpDown();
            this.cmb_datatype = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_add = new System.Windows.Forms.RadioButton();
            this.rbtn_delete = new System.Windows.Forms.RadioButton();
            this.dtg_createnew = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_lenghtdevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_startdevice)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_createnew)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txb_search);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(593, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 40);
            this.panel1.TabIndex = 62;
            // 
            // txb_search
            // 
            this.txb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(69, 5);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(353, 29);
            this.txb_search.TabIndex = 52;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "Search";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(417, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 31);
            this.label8.TabIndex = 61;
            this.label8.Text = "Manager Part";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_delete);
            this.groupBox3.Controls.Add(this.btn_add);
            this.groupBox3.Controls.Add(this.btn_update);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 107);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(306, 39);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(91, 38);
            this.btn_delete.TabIndex = 65;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(24, 41);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(91, 38);
            this.btn_add.TabIndex = 63;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(168, 40);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(91, 38);
            this.btn_update.TabIndex = 64;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_namepart);
            this.groupBox2.Controls.Add(this.cmb_function);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txb_namepart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmb_devicetype);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.num_lenghtdevice);
            this.groupBox2.Controls.Add(this.num_startdevice);
            this.groupBox2.Controls.Add(this.cmb_datatype);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 336);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameter";
            // 
            // cmb_namepart
            // 
            this.cmb_namepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_namepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_namepart.FormattingEnabled = true;
            this.cmb_namepart.Location = new System.Drawing.Point(144, 74);
            this.cmb_namepart.Name = "cmb_namepart";
            this.cmb_namepart.Size = new System.Drawing.Size(265, 28);
            this.cmb_namepart.TabIndex = 52;
            this.cmb_namepart.SelectedIndexChanged += new System.EventHandler(this.cmb_namepart_SelectedIndexChanged);
            // 
            // cmb_function
            // 
            this.cmb_function.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmb_function.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_function.FormattingEnabled = true;
            this.cmb_function.Location = new System.Drawing.Point(144, 31);
            this.cmb_function.Name = "cmb_function";
            this.cmb_function.Size = new System.Drawing.Size(265, 28);
            this.cmb_function.TabIndex = 51;
            this.cmb_function.SelectedIndexChanged += new System.EventHandler(this.cmd_function_SelectedIndexChanged);
            this.cmb_function.SelectedValueChanged += new System.EventHandler(this.cmb_function_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Name Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Name Part";
            // 
            // txb_namepart
            // 
            this.txb_namepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_namepart.Location = new System.Drawing.Point(144, 74);
            this.txb_namepart.Name = "txb_namepart";
            this.txb_namepart.Size = new System.Drawing.Size(265, 29);
            this.txb_namepart.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Device Type";
            // 
            // cmb_devicetype
            // 
            this.cmb_devicetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_devicetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_devicetype.FormattingEnabled = true;
            this.cmb_devicetype.Items.AddRange(new object[] {
            "D",
            "ZR"});
            this.cmb_devicetype.Location = new System.Drawing.Point(144, 109);
            this.cmb_devicetype.Name = "cmb_devicetype";
            this.cmb_devicetype.Size = new System.Drawing.Size(116, 28);
            this.cmb_devicetype.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "StartDevice";
            // 
            // num_lenghtdevice
            // 
            this.num_lenghtdevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_lenghtdevice.Location = new System.Drawing.Point(144, 239);
            this.num_lenghtdevice.Name = "num_lenghtdevice";
            this.num_lenghtdevice.Size = new System.Drawing.Size(116, 29);
            this.num_lenghtdevice.TabIndex = 44;
            // 
            // num_startdevice
            // 
            this.num_startdevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_startdevice.Location = new System.Drawing.Point(144, 151);
            this.num_startdevice.Maximum = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.num_startdevice.Name = "num_startdevice";
            this.num_startdevice.Size = new System.Drawing.Size(116, 29);
            this.num_startdevice.TabIndex = 39;
            // 
            // cmb_datatype
            // 
            this.cmb_datatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_datatype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_datatype.FormattingEnabled = true;
            this.cmb_datatype.Items.AddRange(new object[] {
            "String",
            "DEC",
            "Float"});
            this.cmb_datatype.Location = new System.Drawing.Point(144, 194);
            this.cmb_datatype.Name = "cmb_datatype";
            this.cmb_datatype.Size = new System.Drawing.Size(116, 28);
            this.cmb_datatype.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "DataType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "LenghtDevice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_add);
            this.groupBox1.Controls.Add(this.rbtn_delete);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 72);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Function";
            // 
            // rbtn_add
            // 
            this.rbtn_add.AutoSize = true;
            this.rbtn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_add.Location = new System.Drawing.Point(32, 30);
            this.rbtn_add.Name = "rbtn_add";
            this.rbtn_add.Size = new System.Drawing.Size(122, 24);
            this.rbtn_add.TabIndex = 49;
            this.rbtn_add.TabStop = true;
            this.rbtn_add.Text = "Add Function";
            this.rbtn_add.UseVisualStyleBackColor = true;
            this.rbtn_add.CheckedChanged += new System.EventHandler(this.rbtn_add_CheckedChanged);
            // 
            // rbtn_delete
            // 
            this.rbtn_delete.AutoSize = true;
            this.rbtn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_delete.Location = new System.Drawing.Point(218, 30);
            this.rbtn_delete.Name = "rbtn_delete";
            this.rbtn_delete.Size = new System.Drawing.Size(164, 24);
            this.rbtn_delete.TabIndex = 50;
            this.rbtn_delete.TabStop = true;
            this.rbtn_delete.Text = "Update/Delete Part";
            this.rbtn_delete.UseVisualStyleBackColor = true;
            this.rbtn_delete.CheckedChanged += new System.EventHandler(this.rbtn_delete_CheckedChanged);
            // 
            // dtg_createnew
            // 
            this.dtg_createnew.AllowUserToAddRows = false;
            this.dtg_createnew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_createnew.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_createnew.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtg_createnew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_createnew.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtg_createnew.Location = new System.Drawing.Point(444, 89);
            this.dtg_createnew.MultiSelect = false;
            this.dtg_createnew.Name = "dtg_createnew";
            this.dtg_createnew.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_createnew.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtg_createnew.RowHeadersVisible = false;
            this.dtg_createnew.Size = new System.Drawing.Size(578, 623);
            this.dtg_createnew.TabIndex = 57;
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 724);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtg_createnew);
            this.Name = "AddPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddPart";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_lenghtdevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_startdevice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_createnew)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_namepart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_devicetype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_lenghtdevice;
        private System.Windows.Forms.NumericUpDown num_startdevice;
        private System.Windows.Forms.ComboBox cmb_datatype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_add;
        private System.Windows.Forms.RadioButton rbtn_delete;
        private System.Windows.Forms.DataGridView dtg_createnew;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ComboBox cmb_namepart;
    }
}