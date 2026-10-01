#nullable disable

namespace Trần_Hoài_Nam_B3_24810320642
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.TableLayoutPanel inputTable;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exportCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            mainTable = new System.Windows.Forms.TableLayoutPanel();
            inputTable = new System.Windows.Forms.TableLayoutPanel();

            lblProductId = new System.Windows.Forms.Label();
            lblProductName = new System.Windows.Forms.Label();
            lblCategory = new System.Windows.Forms.Label();
            lblUnitPrice = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();
            lblSearch = new System.Windows.Forms.Label();

            txtProductId = new System.Windows.Forms.TextBox();
            txtProductName = new System.Windows.Forms.TextBox();
            txtUnitPrice = new System.Windows.Forms.TextBox();
            txtQuantity = new System.Windows.Forms.TextBox();
            txtSearch = new System.Windows.Forms.TextBox();

            cboCategory = new System.Windows.Forms.ComboBox();
            picAvatar = new System.Windows.Forms.PictureBox();

            btnChooseImage = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            dgvProducts = new System.Windows.Forms.DataGridView();
            errorProvider = new System.Windows.Forms.ErrorProvider(components);

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            mainTable.SuspendLayout();
            inputTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();

            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                fileToolStripMenuItem
            });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1200, 24);
            menuStrip1.TabIndex = 0;

            fileToolStripMenuItem.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    exportCsvToolStripMenuItem,
                    exitToolStripMenuItem
                });

            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Text = "File";

            exportCsvToolStripMenuItem.Name =
                "exportCsvToolStripMenuItem";
            exportCsvToolStripMenuItem.ShortcutKeys =
                System.Windows.Forms.Keys.Control |
                System.Windows.Forms.Keys.E;
            exportCsvToolStripMenuItem.Text =
                "Export CSV";
            exportCsvToolStripMenuItem.Click +=
                exportCsvToolStripMenuItem_Click;

            exitToolStripMenuItem.Name =
                "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys =
                System.Windows.Forms.Keys.Control |
                System.Windows.Forms.Keys.X;
            exitToolStripMenuItem.Text =
                "Exit";
            exitToolStripMenuItem.Click +=
                exitToolStripMenuItem_Click;

            statusStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    lblStatus
                });

            statusStrip1.Location =
                new System.Drawing.Point(0, 678);
            statusStrip1.Name =
                "statusStrip1";
            statusStrip1.Size =
                new System.Drawing.Size(1200, 22);
            statusStrip1.TabIndex = 1;

            lblStatus.Name = "lblStatus";
            lblStatus.Text =
                "Tổng số sản phẩm: 0";

            mainTable.ColumnCount = 2;
            mainTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    35F));
            mainTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    65F));
            mainTable.Controls.Add(inputTable, 0, 0);
            mainTable.Controls.Add(dgvProducts, 1, 0);
            mainTable.Dock =
                System.Windows.Forms.DockStyle.Fill;
            mainTable.Location =
                new System.Drawing.Point(0, 24);
            mainTable.Name =
                "mainTable";
            mainTable.RowCount = 1;
            mainTable.RowStyles.Add(
                new System.Windows.Forms.RowStyle(
                    System.Windows.Forms.SizeType.Percent,
                    100F));
            mainTable.Size =
                new System.Drawing.Size(1200, 654);
            mainTable.TabIndex = 2;

            inputTable.ColumnCount = 2;
            inputTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    35F));
            inputTable.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(
                    System.Windows.Forms.SizeType.Percent,
                    65F));

            for (int i = 0; i < 10; i++)
            {
                inputTable.RowStyles.Add(
                    new System.Windows.Forms.RowStyle(
                        System.Windows.Forms.SizeType.Absolute,
                        45F));
            }

            inputTable.Dock =
                System.Windows.Forms.DockStyle.Fill;
            inputTable.Location =
                new System.Drawing.Point(0, 0);
            inputTable.Name =
                "inputTable";
            inputTable.Size =
                new System.Drawing.Size(420, 654);
            inputTable.TabIndex = 0;

            lblProductId.Text = "Mã SP";
            lblProductId.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblProductId.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            lblProductName.Text = "Tên SP";
            lblProductName.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblProductName.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            lblCategory.Text = "Danh Mục";
            lblCategory.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblCategory.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            lblUnitPrice.Text = "Đơn Giá";
            lblUnitPrice.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblUnitPrice.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            lblQuantity.Text = "Số Lượng";
            lblQuantity.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblQuantity.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            lblSearch.Text = "Tìm kiếm";
            lblSearch.Dock =
                System.Windows.Forms.DockStyle.Fill;
            lblSearch.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            txtProductId.Dock =
                System.Windows.Forms.DockStyle.Fill;

            txtProductName.Dock =
                System.Windows.Forms.DockStyle.Fill;

            txtUnitPrice.Dock =
                System.Windows.Forms.DockStyle.Fill;

            txtQuantity.Dock =
                System.Windows.Forms.DockStyle.Fill;

            txtSearch.Dock =
                System.Windows.Forms.DockStyle.Fill;

            txtSearch.TextChanged +=
                txtSearch_TextChanged;

            cboCategory.Dock =
                System.Windows.Forms.DockStyle.Fill;
            cboCategory.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            picAvatar.Dock =
                System.Windows.Forms.DockStyle.Fill;
            picAvatar.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picAvatar.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            btnChooseImage.Text =
                "Chọn ảnh";
            btnChooseImage.Dock =
                System.Windows.Forms.DockStyle.Fill;
            btnChooseImage.Click +=
                btnChooseImage_Click;

            btnAdd.Text = "Thêm";
            btnAdd.Dock =
                System.Windows.Forms.DockStyle.Fill;
            btnAdd.Click +=
                btnAdd_Click;

            btnUpdate.Text = "Sửa";
            btnUpdate.Dock =
                System.Windows.Forms.DockStyle.Fill;
            btnUpdate.Click +=
                btnUpdate_Click;

            btnDelete.Text = "Xóa";
            btnDelete.Dock =
                System.Windows.Forms.DockStyle.Fill;
            btnDelete.Click +=
                btnDelete_Click;

            btnClear.Text = "Làm mới";
            btnClear.Dock =
                System.Windows.Forms.DockStyle.Fill;
            btnClear.Click +=
                btnClear_Click;

            inputTable.Controls.Add(lblProductId, 0, 0);
            inputTable.Controls.Add(txtProductId, 1, 0);

            inputTable.Controls.Add(lblProductName, 0, 1);
            inputTable.Controls.Add(txtProductName, 1, 1);

            inputTable.Controls.Add(lblCategory, 0, 2);
            inputTable.Controls.Add(cboCategory, 1, 2);

            inputTable.Controls.Add(lblUnitPrice, 0, 3);
            inputTable.Controls.Add(txtUnitPrice, 1, 3);

            inputTable.Controls.Add(lblQuantity, 0, 4);
            inputTable.Controls.Add(txtQuantity, 1, 4);

            inputTable.Controls.Add(lblSearch, 0, 5);
            inputTable.Controls.Add(txtSearch, 1, 5);

            inputTable.Controls.Add(picAvatar, 0, 6);
            inputTable.SetColumnSpan(picAvatar, 2);

            inputTable.Controls.Add(btnChooseImage, 0, 7);
            inputTable.Controls.Add(btnAdd, 1, 7);

            inputTable.Controls.Add(btnUpdate, 0, 8);
            inputTable.Controls.Add(btnDelete, 1, 8);

            inputTable.Controls.Add(btnClear, 0, 9);
            inputTable.SetColumnSpan(btnClear, 2);

            dgvProducts.Dock =
                System.Windows.Forms.DockStyle.Fill;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionChanged +=
                dgvProducts_SelectionChanged;

            errorProvider.ContainerControl = this;

            AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            ClientSize =
                new System.Drawing.Size(1200, 700);
            Controls.Add(mainTable);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize =
                new System.Drawing.Size(900, 600);
            Name = "Form1";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            Text =
                "TechMart Product Manager";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            mainTable.ResumeLayout(false);
            inputTable.ResumeLayout(false);
            inputTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}