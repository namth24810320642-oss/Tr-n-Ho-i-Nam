namespace Trần_Hoài_Nam_24810320642
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Button btnKiemThu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RichTextBox txtKetQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.btnKiemThu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtKetQua = new System.Windows.Forms.RichTextBox();

            this.SuspendLayout();

            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTieuDe.Location =
                new System.Drawing.Point(25, 20);

            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text =
                "QUẢN LÝ PHƯƠNG TIỆN GIAO THÔNG";

            // lblHuongDan
            this.lblHuongDan.AutoSize = true;

            this.lblHuongDan.Location =
                new System.Drawing.Point(28, 65);

            this.lblHuongDan.Name =
                "lblHuongDan";

            this.lblHuongDan.Text =
                "Nhấn 'Chạy kiểm thử' để thực hiện TC01 - TC05";

            // btnKiemThu
            this.btnKiemThu.Location =
                new System.Drawing.Point(30, 105);

            this.btnKiemThu.Size =
                new System.Drawing.Size(150, 40);

            this.btnKiemThu.Text =
                "Chạy kiểm thử";

            this.btnKiemThu.UseVisualStyleBackColor = true;

            this.btnKiemThu.Click +=
                new System.EventHandler(
                    this.btnKiemThu_Click);

            // btnXoa
            this.btnXoa.Location =
                new System.Drawing.Point(195, 105);

            this.btnXoa.Size =
                new System.Drawing.Size(100, 40);

            this.btnXoa.Text = "Xóa";

            this.btnXoa.UseVisualStyleBackColor = true;

            this.btnXoa.Click +=
                new System.EventHandler(
                    this.btnXoa_Click);

            // btnThoat
            this.btnThoat.Location =
                new System.Drawing.Point(310, 105);

            this.btnThoat.Size =
                new System.Drawing.Size(100, 40);

            this.btnThoat.Text = "Thoát";

            this.btnThoat.UseVisualStyleBackColor = true;

            this.btnThoat.Click +=
                new System.EventHandler(
                    this.btnThoat_Click);

            // txtKetQua
            this.txtKetQua.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            this.txtKetQua.Font =
                new System.Drawing.Font(
                    "Consolas",
                    10F);

            this.txtKetQua.Location =
                new System.Drawing.Point(30, 165);

            this.txtKetQua.Name =
                "txtKetQua";

            this.txtKetQua.ReadOnly = true;

            this.txtKetQua.Size =
                new System.Drawing.Size(800, 390);

            // Form1
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(860, 590);

            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnKiemThu);
            this.Controls.Add(this.lblHuongDan);
            this.Controls.Add(this.lblTieuDe);

            this.MinimumSize =
                new System.Drawing.Size(700, 450);

            this.Name = "Form1";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Quản lý phương tiện giao thông";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}