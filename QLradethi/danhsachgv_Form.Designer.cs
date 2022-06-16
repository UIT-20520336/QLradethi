namespace QLradethi
{
    partial class danhsachgv_Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dsgv_dgv = new System.Windows.Forms.DataGridView();
            this.dsgv = new System.Windows.Forms.Label();
            this.userPanel = new System.Windows.Forms.Panel();
            this.quaylai_btn = new System.Windows.Forms.Button();
            this.xoa_btn = new System.Windows.Forms.Button();
            this.capnhat_btn = new System.Windows.Forms.Button();
            this.them_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsgv_dgv)).BeginInit();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dsgv_dgv);
            this.panel1.Controls.Add(this.dsgv);
            this.panel1.Location = new System.Drawing.Point(324, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 586);
            this.panel1.TabIndex = 0;
            // 
            // dsgv_dgv
            // 
            this.dsgv_dgv.AllowUserToAddRows = false;
            this.dsgv_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dsgv_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsgv_dgv.Location = new System.Drawing.Point(8, 39);
            this.dsgv_dgv.Name = "dsgv_dgv";
            this.dsgv_dgv.ReadOnly = true;
            this.dsgv_dgv.RowHeadersWidth = 51;
            this.dsgv_dgv.RowTemplate.Height = 24;
            this.dsgv_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dsgv_dgv.Size = new System.Drawing.Size(738, 533);
            this.dsgv_dgv.TabIndex = 1;
            this.dsgv_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsgv_dgv_CellClick);
            // 
            // dsgv
            // 
            this.dsgv.AutoSize = true;
            this.dsgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dsgv.Location = new System.Drawing.Point(3, 8);
            this.dsgv.Name = "dsgv";
            this.dsgv.Size = new System.Drawing.Size(220, 25);
            this.dsgv.TabIndex = 0;
            this.dsgv.Text = "Danh sách giảng viên";
            // 
            // userPanel
            // 
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.quaylai_btn);
            this.userPanel.Controls.Add(this.xoa_btn);
            this.userPanel.Controls.Add(this.capnhat_btn);
            this.userPanel.Controls.Add(this.them_btn);
            this.userPanel.Location = new System.Drawing.Point(-2, 1);
            this.userPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(327, 586);
            this.userPanel.TabIndex = 2;
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
            // danhsachgv_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1082, 585);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.panel1);
            this.Name = "danhsachgv_Form";
            this.Text = "Danh sách giảng viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.danhsachgv_Form_FormClosed);
            this.Load += new System.EventHandler(this.danhsachgv_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsgv_dgv)).EndInit();
            this.userPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dsgv;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.DataGridView dsgv_dgv;
        private System.Windows.Forms.Button quaylai_btn;
        private System.Windows.Forms.Button capnhat_btn;
        private System.Windows.Forms.Button them_btn;
        private System.Windows.Forms.Button xoa_btn;
    }
}