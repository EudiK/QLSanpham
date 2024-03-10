namespace Merge
{
    partial class Form3
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
            this.lb_dangki = new System.Windows.Forms.Label();
            this.lb_nhaptaikhoan = new System.Windows.Forms.Label();
            this.lb_nhapmatkhau = new System.Windows.Forms.Label();
            this.lb_xacnhanmatkhau = new System.Windows.Forms.Label();
            this.txtThemTK = new System.Windows.Forms.TextBox();
            this.txtThemMK = new System.Windows.Forms.TextBox();
            this.txtXacNhanMK = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_dangki
            // 
            this.lb_dangki.AutoSize = true;
            this.lb_dangki.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_dangki.Location = new System.Drawing.Point(326, 52);
            this.lb_dangki.Name = "lb_dangki";
            this.lb_dangki.Size = new System.Drawing.Size(154, 37);
            this.lb_dangki.TabIndex = 0;
            this.lb_dangki.Text = "ĐĂNG KÍ";
            this.lb_dangki.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_nhaptaikhoan
            // 
            this.lb_nhaptaikhoan.AutoSize = true;
            this.lb_nhaptaikhoan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nhaptaikhoan.Location = new System.Drawing.Point(200, 142);
            this.lb_nhaptaikhoan.Name = "lb_nhaptaikhoan";
            this.lb_nhaptaikhoan.Size = new System.Drawing.Size(128, 22);
            this.lb_nhaptaikhoan.TabIndex = 1;
            this.lb_nhaptaikhoan.Text = "Nhập tài khoản";
            // 
            // lb_nhapmatkhau
            // 
            this.lb_nhapmatkhau.AutoSize = true;
            this.lb_nhapmatkhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nhapmatkhau.Location = new System.Drawing.Point(200, 189);
            this.lb_nhapmatkhau.Name = "lb_nhapmatkhau";
            this.lb_nhapmatkhau.Size = new System.Drawing.Size(126, 22);
            this.lb_nhapmatkhau.TabIndex = 2;
            this.lb_nhapmatkhau.Text = "Nhập mật khẩu";
            // 
            // lb_xacnhanmatkhau
            // 
            this.lb_xacnhanmatkhau.AutoSize = true;
            this.lb_xacnhanmatkhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_xacnhanmatkhau.Location = new System.Drawing.Point(200, 235);
            this.lb_xacnhanmatkhau.Name = "lb_xacnhanmatkhau";
            this.lb_xacnhanmatkhau.Size = new System.Drawing.Size(157, 22);
            this.lb_xacnhanmatkhau.TabIndex = 3;
            this.lb_xacnhanmatkhau.Text = "Xác nhận mật khẩu";
            // 
            // txtThemTK
            // 
            this.txtThemTK.Location = new System.Drawing.Point(413, 142);
            this.txtThemTK.Name = "txtThemTK";
            this.txtThemTK.Size = new System.Drawing.Size(227, 22);
            this.txtThemTK.TabIndex = 4;
            // 
            // txtThemMK
            // 
            this.txtThemMK.Location = new System.Drawing.Point(413, 189);
            this.txtThemMK.Name = "txtThemMK";
            this.txtThemMK.Size = new System.Drawing.Size(227, 22);
            this.txtThemMK.TabIndex = 5;
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(413, 236);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.Size = new System.Drawing.Size(227, 22);
            this.txtXacNhanMK.TabIndex = 6;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(345, 294);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(115, 46);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "ĐĂNG KÍ";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtXacNhanMK);
            this.Controls.Add(this.txtThemMK);
            this.Controls.Add(this.txtThemTK);
            this.Controls.Add(this.lb_xacnhanmatkhau);
            this.Controls.Add(this.lb_nhapmatkhau);
            this.Controls.Add(this.lb_nhaptaikhoan);
            this.Controls.Add(this.lb_dangki);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_dangki;
        private System.Windows.Forms.Label lb_nhaptaikhoan;
        private System.Windows.Forms.Label lb_nhapmatkhau;
        private System.Windows.Forms.Label lb_xacnhanmatkhau;
        private System.Windows.Forms.TextBox txtThemTK;
        private System.Windows.Forms.TextBox txtThemMK;
        private System.Windows.Forms.TextBox txtXacNhanMK;
        private System.Windows.Forms.Button btnXacNhan;
    }
}