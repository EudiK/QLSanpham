namespace Merge
{
    partial class Form4
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
            this.lb_taikhoan = new System.Windows.Forms.Label();
            this.lb_matkhau = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.lb_dangnhap1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_taikhoan
            // 
            this.lb_taikhoan.AutoSize = true;
            this.lb_taikhoan.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lb_taikhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_taikhoan.Location = new System.Drawing.Point(136, 150);
            this.lb_taikhoan.Name = "lb_taikhoan";
            this.lb_taikhoan.Size = new System.Drawing.Size(93, 22);
            this.lb_taikhoan.TabIndex = 1;
            this.lb_taikhoan.Text = "Tài Khoản";
            this.lb_taikhoan.Click += new System.EventHandler(this.label2_Click);
            // 
            // lb_matkhau
            // 
            this.lb_matkhau.AutoSize = true;
            this.lb_matkhau.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lb_matkhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_matkhau.Location = new System.Drawing.Point(136, 215);
            this.lb_matkhau.Name = "lb_matkhau";
            this.lb_matkhau.Size = new System.Drawing.Size(87, 22);
            this.lb_matkhau.TabIndex = 2;
            this.lb_matkhau.Text = "Mật Khẩu";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(240, 150);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(263, 22);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(240, 216);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(263, 22);
            this.txtMatKhau.TabIndex = 4;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Location = new System.Drawing.Point(289, 266);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(118, 35);
            this.btnTaiKhoan.TabIndex = 5;
            this.btnTaiKhoan.Text = "ĐĂNG NHẬP";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // lb_dangnhap1
            // 
            this.lb_dangnhap1.AutoSize = true;
            this.lb_dangnhap1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dangnhap1.Location = new System.Drawing.Point(283, 56);
            this.lb_dangnhap1.Name = "lb_dangnhap1";
            this.lb_dangnhap1.Size = new System.Drawing.Size(192, 34);
            this.lb_dangnhap1.TabIndex = 6;
            this.lb_dangnhap1.Text = "ĐĂNG NHẬP";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(691, 418);
            this.Controls.Add(this.lb_dangnhap1);
            this.Controls.Add(this.btnTaiKhoan);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.lb_matkhau);
            this.Controls.Add(this.lb_taikhoan);
            this.Name = "Form4";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_taikhoan;
        private System.Windows.Forms.Label lb_matkhau;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Label lb_dangnhap1;
    }
}