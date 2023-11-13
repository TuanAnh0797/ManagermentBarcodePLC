namespace BarcodeManagerment
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmb_function = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_loaddatabase = new System.Windows.Forms.Button();
            this.btn_savedatabase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exportcsv = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_readselect = new System.Windows.Forms.Button();
            this.btn_readalldataplc = new System.Windows.Forms.Button();
            this.btn_writealldataplc = new System.Windows.Forms.Button();
            this.dtg_data = new System.Windows.Forms.DataGridView();
            this.lbl_address = new System.Windows.Forms.Label();
            this.lbl_maximum = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_writeselect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txb_totalrow = new System.Windows.Forms.TextBox();
            this.txb_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_ip = new System.Windows.Forms.TextBox();
            this.btn_import = new System.Windows.Forms.Button();
            this.txb_search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_testconnect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_function
            // 
            this.cmb_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_function.FormattingEnabled = true;
            this.cmb_function.Location = new System.Drawing.Point(128, 20);
            this.cmb_function.Name = "cmb_function";
            this.cmb_function.Size = new System.Drawing.Size(302, 28);
            this.cmb_function.TabIndex = 1;
            this.cmb_function.SelectedIndexChanged += new System.EventHandler(this.cmb_function_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name Function";
            // 
            // btn_loaddatabase
            // 
            this.btn_loaddatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_loaddatabase.Location = new System.Drawing.Point(6, 34);
            this.btn_loaddatabase.Name = "btn_loaddatabase";
            this.btn_loaddatabase.Size = new System.Drawing.Size(125, 28);
            this.btn_loaddatabase.TabIndex = 4;
            this.btn_loaddatabase.Text = "Load database";
            this.btn_loaddatabase.UseVisualStyleBackColor = true;
            this.btn_loaddatabase.Click += new System.EventHandler(this.btn_loaddatabase_Click);
            // 
            // btn_savedatabase
            // 
            this.btn_savedatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savedatabase.Location = new System.Drawing.Point(146, 34);
            this.btn_savedatabase.Name = "btn_savedatabase";
            this.btn_savedatabase.Size = new System.Drawing.Size(128, 28);
            this.btn_savedatabase.TabIndex = 5;
            this.btn_savedatabase.Text = "Save database";
            this.btn_savedatabase.UseVisualStyleBackColor = true;
            this.btn_savedatabase.Click += new System.EventHandler(this.btn_savedatabase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_import);
            this.groupBox1.Controls.Add(this.btn_exportcsv);
            this.groupBox1.Controls.Add(this.btn_loaddatabase);
            this.groupBox1.Controls.Add(this.btn_savedatabase);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 88);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function for PC";
            // 
            // btn_exportcsv
            // 
            this.btn_exportcsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportcsv.Location = new System.Drawing.Point(289, 34);
            this.btn_exportcsv.Name = "btn_exportcsv";
            this.btn_exportcsv.Size = new System.Drawing.Size(103, 28);
            this.btn_exportcsv.TabIndex = 6;
            this.btn_exportcsv.Text = "Export CSV";
            this.btn_exportcsv.UseVisualStyleBackColor = true;
            this.btn_exportcsv.Click += new System.EventHandler(this.btn_exportcsv_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_readselect);
            this.groupBox2.Controls.Add(this.btn_readalldataplc);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(539, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 88);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function  PLC Read";
            // 
            // btn_readselect
            // 
            this.btn_readselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readselect.Location = new System.Drawing.Point(137, 34);
            this.btn_readselect.Name = "btn_readselect";
            this.btn_readselect.Size = new System.Drawing.Size(165, 28);
            this.btn_readselect.TabIndex = 8;
            this.btn_readselect.Text = "Read Data Select";
            this.btn_readselect.UseVisualStyleBackColor = true;
            this.btn_readselect.Click += new System.EventHandler(this.btn_readselect_Click);
            // 
            // btn_readalldataplc
            // 
            this.btn_readalldataplc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_readalldataplc.Location = new System.Drawing.Point(6, 34);
            this.btn_readalldataplc.Name = "btn_readalldataplc";
            this.btn_readalldataplc.Size = new System.Drawing.Size(125, 28);
            this.btn_readalldataplc.TabIndex = 7;
            this.btn_readalldataplc.Text = "Read all data";
            this.btn_readalldataplc.UseVisualStyleBackColor = true;
            this.btn_readalldataplc.Click += new System.EventHandler(this.btn_readalldataplc_Click);
            // 
            // btn_writealldataplc
            // 
            this.btn_writealldataplc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_writealldataplc.Location = new System.Drawing.Point(6, 34);
            this.btn_writealldataplc.Name = "btn_writealldataplc";
            this.btn_writealldataplc.Size = new System.Drawing.Size(125, 28);
            this.btn_writealldataplc.TabIndex = 8;
            this.btn_writealldataplc.Text = "Write all data";
            this.btn_writealldataplc.UseVisualStyleBackColor = true;
            this.btn_writealldataplc.Click += new System.EventHandler(this.btn_writealldataplc_Click);
            // 
            // dtg_data
            // 
            this.dtg_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_data.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg_data.Location = new System.Drawing.Point(6, 201);
            this.dtg_data.Name = "dtg_data";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_data.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg_data.Size = new System.Drawing.Size(1353, 437);
            this.dtg_data.TabIndex = 58;
            this.dtg_data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_data_CellClick);
            this.dtg_data.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_data_CellMouseEnter);
            this.dtg_data.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_data_CellMouseLeave);
            this.dtg_data.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_data_DataBindingComplete);
            this.dtg_data.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtg_data_UserAddedRow);
            // 
            // lbl_address
            // 
            this.lbl_address.AutoSize = true;
            this.lbl_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_address.ForeColor = System.Drawing.Color.Black;
            this.lbl_address.Location = new System.Drawing.Point(435, 24);
            this.lbl_address.Name = "lbl_address";
            this.lbl_address.Size = new System.Drawing.Size(24, 20);
            this.lbl_address.TabIndex = 59;
            this.lbl_address.Text = "IP";
            // 
            // lbl_maximum
            // 
            this.lbl_maximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_maximum.AutoSize = true;
            this.lbl_maximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_maximum.ForeColor = System.Drawing.Color.Black;
            this.lbl_maximum.Location = new System.Drawing.Point(794, 25);
            this.lbl_maximum.Name = "lbl_maximum";
            this.lbl_maximum.Size = new System.Drawing.Size(80, 20);
            this.lbl_maximum.TabIndex = 60;
            this.lbl_maximum.Text = "Total Row";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_writeselect);
            this.groupBox3.Controls.Add(this.btn_writealldataplc);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(856, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 88);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Function  PLC Write";
            // 
            // btn_writeselect
            // 
            this.btn_writeselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_writeselect.Location = new System.Drawing.Point(137, 34);
            this.btn_writeselect.Name = "btn_writeselect";
            this.btn_writeselect.Size = new System.Drawing.Size(167, 28);
            this.btn_writeselect.TabIndex = 9;
            this.btn_writeselect.Text = "Write Data Select";
            this.btn_writeselect.UseVisualStyleBackColor = true;
            this.btn_writeselect.Click += new System.EventHandler(this.btn_writeselect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_testconnect);
            this.groupBox4.Controls.Add(this.txb_totalrow);
            this.groupBox4.Controls.Add(this.txb_port);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txb_ip);
            this.groupBox4.Controls.Add(this.cmb_function);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lbl_maximum);
            this.groupBox4.Controls.Add(this.lbl_address);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1159, 64);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Infor";
            // 
            // txb_totalrow
            // 
            this.txb_totalrow.Location = new System.Drawing.Point(877, 22);
            this.txb_totalrow.Name = "txb_totalrow";
            this.txb_totalrow.ReadOnly = true;
            this.txb_totalrow.Size = new System.Drawing.Size(117, 26);
            this.txb_totalrow.TabIndex = 64;
            // 
            // txb_port
            // 
            this.txb_port.Location = new System.Drawing.Point(677, 22);
            this.txb_port.Name = "txb_port";
            this.txb_port.ReadOnly = true;
            this.txb_port.Size = new System.Drawing.Size(115, 26);
            this.txb_port.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(636, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Port";
            // 
            // txb_ip
            // 
            this.txb_ip.Location = new System.Drawing.Point(465, 21);
            this.txb_ip.Name = "txb_ip";
            this.txb_ip.ReadOnly = true;
            this.txb_ip.Size = new System.Drawing.Size(167, 26);
            this.txb_ip.TabIndex = 61;
            // 
            // btn_import
            // 
            this.btn_import.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_import.Location = new System.Drawing.Point(408, 34);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(103, 28);
            this.btn_import.TabIndex = 7;
            this.btn_import.Text = "Import CSV";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // txb_search
            // 
            this.txb_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_search.Location = new System.Drawing.Point(1028, 166);
            this.txb_search.Name = "txb_search";
            this.txb_search.Size = new System.Drawing.Size(331, 26);
            this.txb_search.TabIndex = 62;
            this.txb_search.TextChanged += new System.EventHandler(this.txb_search_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(962, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Search";
            // 
            // btn_testconnect
            // 
            this.btn_testconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_testconnect.Location = new System.Drawing.Point(1014, 22);
            this.btn_testconnect.Name = "btn_testconnect";
            this.btn_testconnect.Size = new System.Drawing.Size(125, 28);
            this.btn_testconnect.TabIndex = 10;
            this.btn_testconnect.Text = "Test Connect";
            this.btn_testconnect.UseVisualStyleBackColor = true;
            this.btn_testconnect.Click += new System.EventHandler(this.btn_testconnect_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 646);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_search);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dtg_data);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_data)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmb_function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_loaddatabase;
        private System.Windows.Forms.Button btn_savedatabase;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_exportcsv;
        private System.Windows.Forms.Button btn_writealldataplc;
        private System.Windows.Forms.Button btn_readalldataplc;
        private System.Windows.Forms.DataGridView dtg_data;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_maximum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_writeselect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txb_totalrow;
        private System.Windows.Forms.TextBox txb_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_ip;
        private System.Windows.Forms.Button btn_readselect;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.TextBox txb_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_testconnect;
    }
}