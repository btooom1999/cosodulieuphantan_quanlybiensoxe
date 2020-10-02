namespace QuanLyBSX
{
    partial class Menu
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
            this.btnDangKyPhuongTien = new System.Windows.Forms.Button();
            this.btnQuanLyCanBo = new System.Windows.Forms.Button();
            this.btnQuanLyPhuongTien = new System.Windows.Forms.Button();
            this.btnQuanLyChuXe = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangKyPhuongTien
            // 
            this.btnDangKyPhuongTien.Location = new System.Drawing.Point(84, 43);
            this.btnDangKyPhuongTien.Name = "btnDangKyPhuongTien";
            this.btnDangKyPhuongTien.Size = new System.Drawing.Size(149, 69);
            this.btnDangKyPhuongTien.TabIndex = 0;
            this.btnDangKyPhuongTien.Text = "ĐĂNG KÝ PHƯƠNG TIỆN";
            this.btnDangKyPhuongTien.UseVisualStyleBackColor = true;
            this.btnDangKyPhuongTien.Click += new System.EventHandler(this.btnDangKyPhuongTien_Click);
            // 
            // btnQuanLyCanBo
            // 
            this.btnQuanLyCanBo.Location = new System.Drawing.Point(330, 43);
            this.btnQuanLyCanBo.Name = "btnQuanLyCanBo";
            this.btnQuanLyCanBo.Size = new System.Drawing.Size(149, 69);
            this.btnQuanLyCanBo.TabIndex = 1;
            this.btnQuanLyCanBo.Text = "QUẢN LÝ CÁN BỘ";
            this.btnQuanLyCanBo.UseVisualStyleBackColor = true;
            this.btnQuanLyCanBo.Click += new System.EventHandler(this.btnQuanLyCanBo_Click);
            // 
            // btnQuanLyPhuongTien
            // 
            this.btnQuanLyPhuongTien.Location = new System.Drawing.Point(603, 43);
            this.btnQuanLyPhuongTien.Name = "btnQuanLyPhuongTien";
            this.btnQuanLyPhuongTien.Size = new System.Drawing.Size(149, 69);
            this.btnQuanLyPhuongTien.TabIndex = 2;
            this.btnQuanLyPhuongTien.Text = "QUẢN LÝ PHƯƠNG TIỆN";
            this.btnQuanLyPhuongTien.UseVisualStyleBackColor = true;
            this.btnQuanLyPhuongTien.Click += new System.EventHandler(this.btnQuanLyPhuongTien_Click);
            // 
            // btnQuanLyChuXe
            // 
            this.btnQuanLyChuXe.Location = new System.Drawing.Point(862, 43);
            this.btnQuanLyChuXe.Name = "btnQuanLyChuXe";
            this.btnQuanLyChuXe.Size = new System.Drawing.Size(149, 69);
            this.btnQuanLyChuXe.TabIndex = 3;
            this.btnQuanLyChuXe.Text = "QUẢN LÝ CHỦ XE";
            this.btnQuanLyChuXe.UseVisualStyleBackColor = true;
            this.btnQuanLyChuXe.Click += new System.EventHandler(this.btnQuanLyChuXe_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnDangKyPhuongTien);
            this.panel1.Controls.Add(this.btnQuanLyChuXe);
            this.panel1.Controls.Add(this.btnQuanLyCanBo);
            this.panel1.Controls.Add(this.btnQuanLyPhuongTien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 147);
            this.panel1.TabIndex = 4;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 442);
            this.Controls.Add(this.panel1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDangKyPhuongTien;
        private System.Windows.Forms.Button btnQuanLyCanBo;
        private System.Windows.Forms.Button btnQuanLyPhuongTien;
        private System.Windows.Forms.Button btnQuanLyChuXe;
        private System.Windows.Forms.Panel panel1;
    }
}