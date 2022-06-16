namespace QLradethi
{
    partial class danhsachbaicham_Form
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
            this.chamthi_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tenlop = new System.Windows.Forms.Label();
            this.dsgv_dgv = new System.Windows.Forms.DataGridView();
            this.dsbc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tenmonthi_lb = new System.Windows.Forms.Label();
            this.tengv_label = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsgv_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // userPanel
            // 
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.quaylai_btn);
            this.userPanel.Controls.Add(this.xoa_btn);
            this.userPanel.Controls.Add(this.capnhat_btn);
            this.userPanel.Controls.Add(this.chamthi_btn);
            this.userPanel.Location = new System.Drawing.Point(1, 3);
            this.userPanel.Margin = new System.Windows.Forms.Padding(4);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(327, 586);
            this.userPanel.TabIndex = 6;
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
            // chamthi_btn
            // 
            this.chamthi_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chamthi_btn.FlatAppearance.BorderSize = 0;
            this.chamthi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chamthi_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chamthi_btn.Location = new System.Drawing.Point(44, 71);
            this.chamthi_btn.Margin = new System.Windows.Forms.Padding(4);
            this.chamthi_btn.Name = "chamthi_btn";
            this.chamthi_btn.Size = new System.Drawing.Size(236, 62);
            this.chamthi_btn.TabIndex = 4;
            this.chamthi_btn.Text = "Chấm thi";
            this.chamthi_btn.UseVisualStyleBackColor = false;
            this.chamthi_btn.Click += new System.EventHandler(this.chamthi_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tengv_label);
            this.panel1.Controls.Add(this.tenmonthi_lb);
            this.panel1.Controls.Add(this.tenlop);
            this.panel1.Controls.Add(this.dsgv_dgv);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dsbc);
            this.panel1.Location = new System.Drawing.Point(335, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 586);
            this.panel1.TabIndex = 7;
            // 
            // tenlop
            // 
            this.tenlop.AutoSize = true;
            this.tenlop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenlop.Location = new System.Drawing.Point(262, 8);
            this.tenlop.Name = "tenlop";
            this.tenlop.Size = new System.Drawing.Size(77, 25);
            this.tenlop.TabIndex = 2;
            this.tenlop.Text = "tên lớp";
            // 
            // dsgv_dgv
            // 
            this.dsgv_dgv.AllowUserToAddRows = false;
            this.dsgv_dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dsgv_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsgv_dgv.Location = new System.Drawing.Point(8, 125);
            this.dsgv_dgv.Name = "dsgv_dgv";
            this.dsgv_dgv.ReadOnly = true;
            this.dsgv_dgv.RowHeadersWidth = 51;
            this.dsgv_dgv.RowTemplate.Height = 24;
            this.dsgv_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dsgv_dgv.Size = new System.Drawing.Size(738, 447);
            this.dsgv_dgv.TabIndex = 1;
            this.dsgv_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsgv_dgv_CellClick);
            // 
            // dsbc
            // 
            this.dsbc.AutoSize = true;
            this.dsbc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dsbc.Location = new System.Drawing.Point(3, 8);
            this.dsbc.Name = "dsbc";
            this.dsbc.Size = new System.Drawing.Size(243, 25);
            this.dsbc.TabIndex = 0;
            this.dsbc.Text = "Danh sách bài chấm lớp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên môn thi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên giảng viên";
            // 
            // tenmonthi_lb
            // 
            this.tenmonthi_lb.AutoSize = true;
            this.tenmonthi_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmonthi_lb.Location = new System.Drawing.Point(169, 47);
            this.tenmonthi_lb.Name = "tenmonthi_lb";
            this.tenmonthi_lb.Size = new System.Drawing.Size(71, 25);
            this.tenmonthi_lb.TabIndex = 2;
            this.tenmonthi_lb.Text = "tên mt";
            // 
            // tengv_label
            // 
            this.tengv_label.AutoSize = true;
            this.tengv_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tengv_label.Location = new System.Drawing.Point(169, 89);
            this.tengv_label.Name = "tengv_label";
            this.tengv_label.Size = new System.Drawing.Size(71, 25);
            this.tengv_label.TabIndex = 2;
            this.tengv_label.Text = "tên gv";
            // 
            // danhsachbaicham_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1098, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userPanel);
            this.Name = "danhsachbaicham_Form";
            this.Text = "Danh sách bài chấm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.danhsachbaicham_Form_FormClosed);
            this.Load += new System.EventHandler(this.danhsachbaicham_Form_Load);
            this.userPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsgv_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Button quaylai_btn;
        private System.Windows.Forms.Button xoa_btn;
        private System.Windows.Forms.Button capnhat_btn;
        private System.Windows.Forms.Button chamthi_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dsgv_dgv;
        private System.Windows.Forms.Label dsbc;
        private System.Windows.Forms.Label tenlop;
        private System.Windows.Forms.Label tengv_label;
        private System.Windows.Forms.Label tenmonthi_lb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}