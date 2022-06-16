namespace QLradethi
{
    partial class danhsachdethi_Form
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
            this.userPanel = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.tim_btn = new System.Windows.Forms.Button();
            this.mientim_cbbox = new System.Windows.Forms.ComboBox();
            this.label_search_nv_bangluong = new System.Windows.Forms.Label();
            this.tim_txtbox = new System.Windows.Forms.TextBox();
            this.bt_Khoitao_nv_bangluong = new System.Windows.Forms.Button();
            this.quaylai_btn = new System.Windows.Forms.Button();
            this.xoa_btn = new System.Windows.Forms.Button();
            this.capnhat_btn = new System.Windows.Forms.Button();
            this.them_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dsdt_dgv = new System.Windows.Forms.DataGridView();
            this.dsdt = new System.Windows.Forms.Label();
            this.loc_cbbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.userPanel.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsdt_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // userPanel
            // 
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.panel27);
            this.userPanel.Controls.Add(this.button1);
            this.userPanel.Controls.Add(this.quaylai_btn);
            this.userPanel.Controls.Add(this.xoa_btn);
            this.userPanel.Controls.Add(this.capnhat_btn);
            this.userPanel.Controls.Add(this.them_btn);
            this.userPanel.Location = new System.Drawing.Point(-1, 2);
            this.userPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(327, 585);
            this.userPanel.TabIndex = 4;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.loc_cbbox);
            this.panel27.Controls.Add(this.tim_btn);
            this.panel27.Controls.Add(this.mientim_cbbox);
            this.panel27.Controls.Add(this.label_search_nv_bangluong);
            this.panel27.Controls.Add(this.tim_txtbox);
            this.panel27.Controls.Add(this.bt_Khoitao_nv_bangluong);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(0, 0);
            this.panel27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(325, 172);
            this.panel27.TabIndex = 6;
            // 
            // tim_btn
            // 
            this.tim_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tim_btn.FlatAppearance.BorderSize = 0;
            this.tim_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tim_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim_btn.ForeColor = System.Drawing.Color.Black;
            this.tim_btn.Location = new System.Drawing.Point(31, 144);
            this.tim_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tim_btn.Name = "tim_btn";
            this.tim_btn.Size = new System.Drawing.Size(173, 28);
            this.tim_btn.TabIndex = 4;
            this.tim_btn.Text = "Tìm";
            this.tim_btn.UseVisualStyleBackColor = false;
            this.tim_btn.Click += new System.EventHandler(this.tim_btn_Click);
            // 
            // mientim_cbbox
            // 
            this.mientim_cbbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mientim_cbbox.FormattingEnabled = true;
            this.mientim_cbbox.Items.AddRange(new object[] {
            "Mã đề thi",
            "Thời lượng",
            "Ngày thi"});
            this.mientim_cbbox.Location = new System.Drawing.Point(120, 36);
            this.mientim_cbbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mientim_cbbox.Name = "mientim_cbbox";
            this.mientim_cbbox.Size = new System.Drawing.Size(159, 26);
            this.mientim_cbbox.TabIndex = 9;
            this.mientim_cbbox.Text = "Chưa chọn";
            this.mientim_cbbox.SelectedIndexChanged += new System.EventHandler(this.mientim_cbbox_SelectedIndexChanged);
            // 
            // label_search_nv_bangluong
            // 
            this.label_search_nv_bangluong.AutoSize = true;
            this.label_search_nv_bangluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_search_nv_bangluong.Location = new System.Drawing.Point(28, 39);
            this.label_search_nv_bangluong.Name = "label_search_nv_bangluong";
            this.label_search_nv_bangluong.Size = new System.Drawing.Size(74, 18);
            this.label_search_nv_bangluong.TabIndex = 11;
            this.label_search_nv_bangluong.Text = "Tìm theo";
            // 
            // tim_txtbox
            // 
            this.tim_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tim_txtbox.Location = new System.Drawing.Point(39, 103);
            this.tim_txtbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tim_txtbox.Name = "tim_txtbox";
            this.tim_txtbox.Size = new System.Drawing.Size(240, 24);
            this.tim_txtbox.TabIndex = 10;
            // 
            // bt_Khoitao_nv_bangluong
            // 
            this.bt_Khoitao_nv_bangluong.BackColor = System.Drawing.Color.White;
            this.bt_Khoitao_nv_bangluong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Khoitao_nv_bangluong.FlatAppearance.BorderSize = 0;
            this.bt_Khoitao_nv_bangluong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Khoitao_nv_bangluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Khoitao_nv_bangluong.Location = new System.Drawing.Point(336, 62);
            this.bt_Khoitao_nv_bangluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Khoitao_nv_bangluong.Name = "bt_Khoitao_nv_bangluong";
            this.bt_Khoitao_nv_bangluong.Size = new System.Drawing.Size(25, 21);
            this.bt_Khoitao_nv_bangluong.TabIndex = 7;
            this.bt_Khoitao_nv_bangluong.UseVisualStyleBackColor = false;
            // 
            // quaylai_btn
            // 
            this.quaylai_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.quaylai_btn.FlatAppearance.BorderSize = 0;
            this.quaylai_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quaylai_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quaylai_btn.Location = new System.Drawing.Point(31, 458);
            this.quaylai_btn.Margin = new System.Windows.Forms.Padding(4);
            this.quaylai_btn.Name = "quaylai_btn";
            this.quaylai_btn.Size = new System.Drawing.Size(236, 62);
            this.quaylai_btn.TabIndex = 2;
            this.quaylai_btn.Text = "Quay lại";
            this.quaylai_btn.UseVisualStyleBackColor = false;
            this.quaylai_btn.Click += new System.EventHandler(this.quaylai_btn_Click);
            // 
            // xoa_btn
            // 
            this.xoa_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.xoa_btn.FlatAppearance.BorderSize = 0;
            this.xoa_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xoa_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa_btn.Location = new System.Drawing.Point(31, 388);
            this.xoa_btn.Margin = new System.Windows.Forms.Padding(4);
            this.xoa_btn.Name = "xoa_btn";
            this.xoa_btn.Size = new System.Drawing.Size(236, 62);
            this.xoa_btn.TabIndex = 3;
            this.xoa_btn.Text = "Xoá";
            this.xoa_btn.UseVisualStyleBackColor = false;
            this.xoa_btn.Click += new System.EventHandler(this.xoa_btn_Click);
            // 
            // capnhat_btn
            // 
            this.capnhat_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.capnhat_btn.FlatAppearance.BorderSize = 0;
            this.capnhat_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.capnhat_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capnhat_btn.Location = new System.Drawing.Point(31, 318);
            this.capnhat_btn.Margin = new System.Windows.Forms.Padding(4);
            this.capnhat_btn.Name = "capnhat_btn";
            this.capnhat_btn.Size = new System.Drawing.Size(236, 62);
            this.capnhat_btn.TabIndex = 3;
            this.capnhat_btn.Text = "Chi tiết";
            this.capnhat_btn.UseVisualStyleBackColor = false;
            this.capnhat_btn.Click += new System.EventHandler(this.capnhat_btn_Click);
            // 
            // them_btn
            // 
            this.them_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.them_btn.FlatAppearance.BorderSize = 0;
            this.them_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.them_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them_btn.Location = new System.Drawing.Point(31, 248);
            this.them_btn.Margin = new System.Windows.Forms.Padding(4);
            this.them_btn.Name = "them_btn";
            this.them_btn.Size = new System.Drawing.Size(236, 62);
            this.them_btn.TabIndex = 4;
            this.them_btn.Text = "Thêm";
            this.them_btn.UseVisualStyleBackColor = false;
            this.them_btn.Click += new System.EventHandler(this.them_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.dsdt_dgv);
            this.panel1.Controls.Add(this.dsdt);
            this.panel1.Location = new System.Drawing.Point(325, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 586);
            this.panel1.TabIndex = 3;
            // 
            // dsdt_dgv
            // 
            this.dsdt_dgv.AllowUserToAddRows = false;
            this.dsdt_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dsdt_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsdt_dgv.Location = new System.Drawing.Point(8, 39);
            this.dsdt_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dsdt_dgv.Name = "dsdt_dgv";
            this.dsdt_dgv.ReadOnly = true;
            this.dsdt_dgv.RowHeadersWidth = 51;
            this.dsdt_dgv.RowTemplate.Height = 24;
            this.dsdt_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dsdt_dgv.Size = new System.Drawing.Size(739, 533);
            this.dsdt_dgv.TabIndex = 1;
            this.dsdt_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsdt_dgv_CellClick);
            // 
            // dsdt
            // 
            this.dsdt.AutoSize = true;
            this.dsdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dsdt.Location = new System.Drawing.Point(3, 7);
            this.dsdt.Name = "dsdt";
            this.dsdt.Size = new System.Drawing.Size(174, 25);
            this.dsdt.TabIndex = 0;
            this.dsdt.Text = "Danh sách đề thi";
            // 
            // loc_cbbox
            // 
            this.loc_cbbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.loc_cbbox.FormattingEnabled = true;
            this.loc_cbbox.Items.AddRange(new object[] {
            "Bằng",
            "Lớn hơn",
            "Nhỏ hơn"});
            this.loc_cbbox.Location = new System.Drawing.Point(120, 66);
            this.loc_cbbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loc_cbbox.Name = "loc_cbbox";
            this.loc_cbbox.Size = new System.Drawing.Size(99, 26);
            this.loc_cbbox.TabIndex = 12;
            this.loc_cbbox.Text = "Lọc";
            this.loc_cbbox.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(31, 189);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Khởi tạo";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // danhsachdethi_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1087, 590);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "danhsachdethi_Form";
            this.Text = "Danh sách đề thi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.danhsachdethi_Form_FormClosed);
            this.Load += new System.EventHandler(this.danhsachdethi_Form_Load);
            this.userPanel.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsdt_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button quaylai_btn;
        private System.Windows.Forms.Button xoa_btn;
        private System.Windows.Forms.Button capnhat_btn;
        private System.Windows.Forms.Button them_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dsdt_dgv;
        private System.Windows.Forms.Label dsdt;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Button tim_btn;
        private System.Windows.Forms.ComboBox mientim_cbbox;
        private System.Windows.Forms.Label label_search_nv_bangluong;
        private System.Windows.Forms.TextBox tim_txtbox;
        private System.Windows.Forms.Button bt_Khoitao_nv_bangluong;
        private System.Windows.Forms.ComboBox loc_cbbox;
        private System.Windows.Forms.Button button1;
    }
}