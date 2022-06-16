namespace QLradethi
{
    partial class danhsachmonhoc_Form
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
            this.quaylai_btn = new System.Windows.Forms.Button();
            this.xoa_btn = new System.Windows.Forms.Button();
            this.capnhat_btn = new System.Windows.Forms.Button();
            this.them_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dsmh_dgv = new System.Windows.Forms.DataGridView();
            this.dsmh = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsmh_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // userPanel
            // 
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.quaylai_btn);
            this.userPanel.Controls.Add(this.xoa_btn);
            this.userPanel.Controls.Add(this.capnhat_btn);
            this.userPanel.Controls.Add(this.them_btn);
            this.userPanel.Location = new System.Drawing.Point(4, 1);
            this.userPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(327, 586);
            this.userPanel.TabIndex = 3;
            // 
            // quaylai_btn
            // 
            this.quaylai_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.quaylai_btn.FlatAppearance.BorderSize = 0;
            this.quaylai_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quaylai_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quaylai_btn.Location = new System.Drawing.Point(44, 369);
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
            this.xoa_btn.Location = new System.Drawing.Point(44, 270);
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
            this.capnhat_btn.Location = new System.Drawing.Point(44, 169);
            this.capnhat_btn.Margin = new System.Windows.Forms.Padding(4);
            this.capnhat_btn.Name = "capnhat_btn";
            this.capnhat_btn.Size = new System.Drawing.Size(236, 62);
            this.capnhat_btn.TabIndex = 3;
            this.capnhat_btn.Text = "Cập nhật";
            this.capnhat_btn.UseVisualStyleBackColor = false;
            this.capnhat_btn.Click += new System.EventHandler(this.capnhat_btn_Click);
            // 
            // them_btn
            // 
            this.them_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.them_btn.FlatAppearance.BorderSize = 0;
            this.them_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.them_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them_btn.Location = new System.Drawing.Point(44, 71);
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
            this.panel1.Controls.Add(this.dsmh_dgv);
            this.panel1.Controls.Add(this.dsmh);
            this.panel1.Location = new System.Drawing.Point(338, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 586);
            this.panel1.TabIndex = 4;
            // 
            // dsmh_dgv
            // 
            this.dsmh_dgv.AllowUserToAddRows = false;
            this.dsmh_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dsmh_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsmh_dgv.Location = new System.Drawing.Point(8, 39);
            this.dsmh_dgv.Name = "dsmh_dgv";
            this.dsmh_dgv.ReadOnly = true;
            this.dsmh_dgv.RowHeadersWidth = 51;
            this.dsmh_dgv.RowTemplate.Height = 24;
            this.dsmh_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dsmh_dgv.Size = new System.Drawing.Size(738, 533);
            this.dsmh_dgv.TabIndex = 1;
            this.dsmh_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsmh_dgv_CellClick);
            // 
            // dsmh
            // 
            this.dsmh.AutoSize = true;
            this.dsmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dsmh.Location = new System.Drawing.Point(3, 8);
            this.dsmh.Name = "dsmh";
            this.dsmh.Size = new System.Drawing.Size(203, 25);
            this.dsmh.TabIndex = 0;
            this.dsmh.Text = "Danh sách môn học";
            // 
            // danhsachmonhoc_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1100, 589);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userPanel);
            this.Name = "danhsachmonhoc_Form";
            this.Text = "Danh sách môn học";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.danhsachmonhoc_Form_FormClosed);
            this.Load += new System.EventHandler(this.danhsachmonhoc_Form_Load);
            this.userPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsmh_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button quaylai_btn;
        private System.Windows.Forms.Button xoa_btn;
        private System.Windows.Forms.Button capnhat_btn;
        private System.Windows.Forms.Button them_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dsmh_dgv;
        private System.Windows.Forms.Label dsmh;
    }
}