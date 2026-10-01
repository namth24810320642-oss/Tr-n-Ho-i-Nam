using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trần_Hoài_Nam_B3_24810320642
{
    public partial class Form1 : Form
    {
        private class Category
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }

        private class Product
        {
            public string ProductId { get; set; } = "";
            public string ProductName { get; set; } = "";
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = "";
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public Image? Avatar { get; set; }
        }

        private readonly BindingList<Product> products =
            new BindingList<Product>();

        private readonly BindingSource bindingSource =
            new BindingSource();

        private readonly List<Category> categories =
            new List<Category>();

        private Product? selectedProduct;

        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            LoadCategories();
            SetupComboBox();
            SetupDataGridView();
            SetupBinding();
            UpdateStatus();
            ClearForm();
        }

        private void LoadCategories()
        {
            categories.Clear();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Điện thoại"
            });

            categories.Add(new Category
            {
                Id = 2,
                Name = "Laptop"
            });

            categories.Add(new Category
            {
                Id = 3,
                Name = "Phụ kiện"
            });
        }

        private void SetupComboBox()
        {
            cboCategory.DataSource = null;
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            if (categories.Count > 0)
                cboCategory.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvProducts.Columns.Clear();

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name = "colProductId";
            colId.HeaderText = "Mã SP";
            colId.DataPropertyName = "ProductId";
            colId.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            colId.FillWeight = 15;

            DataGridViewTextBoxColumn colName =
                new DataGridViewTextBoxColumn();

            colName.Name = "colProductName";
            colName.HeaderText = "Tên SP";
            colName.DataPropertyName = "ProductName";
            colName.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            colName.FillWeight = 25;

            DataGridViewTextBoxColumn colCategory =
                new DataGridViewTextBoxColumn();

            colCategory.Name = "colCategory";
            colCategory.HeaderText = "Danh Mục";
            colCategory.DataPropertyName = "CategoryName";
            colCategory.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            colCategory.FillWeight = 20;

            DataGridViewTextBoxColumn colPrice =
                new DataGridViewTextBoxColumn();

            colPrice.Name = "colUnitPrice";
            colPrice.HeaderText = "Đơn Giá";
            colPrice.DataPropertyName = "UnitPrice";
            colPrice.DefaultCellStyle.Format = "N0";
            colPrice.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            colPrice.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            colPrice.FillWeight = 20;

            DataGridViewTextBoxColumn colQuantity =
                new DataGridViewTextBoxColumn();

            colQuantity.Name = "colQuantity";
            colQuantity.HeaderText = "Số Lượng";
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            colQuantity.FillWeight = 15;

            dgvProducts.Columns.Add(colId);
            dgvProducts.Columns.Add(colName);
            dgvProducts.Columns.Add(colCategory);
            dgvProducts.Columns.Add(colPrice);
            dgvProducts.Columns.Add(colQuantity);

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.RowHeadersVisible = false;

            dgvProducts.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvProducts.Font, FontStyle.Bold);
        }

        private void SetupBinding()
        {
            bindingSource.DataSource = products;
            dgvProducts.DataSource = bindingSource;
        }

        private bool ValidateInput()
        {
            errorProvider.Clear();

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(
                    txtProductName,
                    "Tên sản phẩm không được để trống.");

                isValid = false;
            }

            decimal price;

            if (!decimal.TryParse(
                    txtUnitPrice.Text.Trim(),
                    out price))
            {
                errorProvider.SetError(
                    txtUnitPrice,
                    "Đơn giá phải là số.");

                isValid = false;
            }
            else if (price <= 0)
            {
                errorProvider.SetError(
                    txtUnitPrice,
                    "Đơn giá phải lớn hơn 0.");

                isValid = false;
            }

            int quantity;

            if (!int.TryParse(
                    txtQuantity.Text.Trim(),
                    out quantity))
            {
                errorProvider.SetError(
                    txtQuantity,
                    "Số lượng phải là số nguyên.");

                isValid = false;
            }
            else if (quantity < 0)
            {
                errorProvider.SetError(
                    txtQuantity,
                    "Số lượng phải lớn hơn hoặc bằng 0.");

                isValid = false;
            }

            return isValid;
        }

        private Product? GetProductFromForm()
        {
            if (!ValidateInput())
                return null;

            decimal price =
                decimal.Parse(txtUnitPrice.Text.Trim());

            int quantity =
                int.Parse(txtQuantity.Text.Trim());

            Category? category =
                cboCategory.SelectedItem as Category;

            if (category == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            string productId =
                txtProductId.Text.Trim();

            if (string.IsNullOrWhiteSpace(productId))
                productId = GenerateProductId();

            return new Product
            {
                ProductId = productId,
                ProductName = txtProductName.Text.Trim(),
                CategoryId = category.Id,
                CategoryName = category.Name,
                UnitPrice = price,
                Quantity = quantity,
                Avatar = picAvatar.Image
            };
        }

        private string GenerateProductId()
        {
            int number = 1;

            while (products.Any(
                p => p.ProductId ==
                     "SP" + number.ToString("000")))
            {
                number++;
            }

            return "SP" + number.ToString("000");
        }

        private void btnAdd_Click(
            object? sender,
            EventArgs e)
        {
            Product? product =
                GetProductFromForm();

            if (product == null)
                return;

            if (products.Any(
                p => p.ProductId.Equals(
                    product.ProductId,
                    StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider.SetError(
                    txtProductId,
                    "Mã sản phẩm đã tồn tại.");

                MessageBox.Show(
                    "Mã sản phẩm đã tồn tại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            products.Add(product);
            bindingSource.ResetBindings(false);
            UpdateStatus();

            MessageBox.Show(
                "Thêm sản phẩm thành công.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearForm();
        }

        private void btnUpdate_Click(
            object? sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!ValidateInput())
                return;

            decimal price =
                decimal.Parse(txtUnitPrice.Text.Trim());

            int quantity =
                int.Parse(txtQuantity.Text.Trim());

            Category? category =
                cboCategory.SelectedItem as Category;

            if (category == null)
                return;

            string newProductId =
                txtProductId.Text.Trim();

            if (string.IsNullOrWhiteSpace(newProductId))
            {
                errorProvider.SetError(
                    txtProductId,
                    "Mã sản phẩm không được để trống.");

                return;
            }

            bool duplicate =
                products.Any(p =>
                    p != selectedProduct &&
                    p.ProductId.Equals(
                        newProductId,
                        StringComparison.OrdinalIgnoreCase));

            if (duplicate)
            {
                errorProvider.SetError(
                    txtProductId,
                    "Mã sản phẩm đã tồn tại.");

                return;
            }

            selectedProduct.ProductId =
                newProductId;

            selectedProduct.ProductName =
                txtProductName.Text.Trim();

            selectedProduct.CategoryId =
                category.Id;

            selectedProduct.CategoryName =
                category.Name;

            selectedProduct.UnitPrice =
                price;

            selectedProduct.Quantity =
                quantity;

            selectedProduct.Avatar =
                picAvatar.Image;

            bindingSource.ResetBindings(false);
            UpdateStatus();

            MessageBox.Show(
                "Cập nhật sản phẩm thành công.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDelete_Click(
            object? sender,
            EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa sản phẩm \"" +
                    selectedProduct.ProductName +
                    "\" không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                products.Remove(selectedProduct);

                selectedProduct = null;

                bindingSource.ResetBindings(false);

                UpdateStatus();

                ClearForm();
            }
        }

        private void btnClear_Click(
            object? sender,
            EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            errorProvider.Clear();

            selectedProduct = null;

            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();

            if (categories.Count > 0)
                cboCategory.SelectedIndex = 0;

            picAvatar.Image = null;

            dgvProducts.ClearSelection();

            txtProductName.Focus();
        }

        private void btnChooseImage_Click(
            object? sender,
            EventArgs e)
        {
            using OpenFileDialog dialog =
                new OpenFileDialog();

            dialog.Title =
                "Chọn ảnh sản phẩm";

            dialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            dialog.Multiselect = false;

            if (dialog.ShowDialog() ==
                DialogResult.OK)
            {
                try
                {
                    using FileStream stream =
                        new FileStream(
                            dialog.FileName,
                            FileMode.Open,
                            FileAccess.Read);

                    using Image image =
                        Image.FromStream(stream);

                    picAvatar.Image =
                        new Bitmap(image);
                }
                catch
                {
                    MessageBox.Show(
                        "Không thể tải ảnh.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProducts_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
                return;

            DataGridViewRow row =
                dgvProducts.SelectedRows[0];

            if (row.DataBoundItem is Product product)
            {
                selectedProduct = product;

                txtProductId.Text =
                    product.ProductId;

                txtProductName.Text =
                    product.ProductName;

                txtUnitPrice.Text =
                    product.UnitPrice.ToString("0");

                txtQuantity.Text =
                    product.Quantity.ToString();

                cboCategory.SelectedValue =
                    product.CategoryId;

                picAvatar.Image =
                    product.Avatar;
            }
        }

        private void txtSearch_TextChanged(
            object? sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                bindingSource.DataSource =
                    products;
            }
            else
            {
                BindingList<Product> filtered =
                    new BindingList<Product>(
                        products
                            .Where(p =>
                                p.ProductName.IndexOf(
                                    keyword,
                                    StringComparison
                                        .CurrentCultureIgnoreCase)
                                >= 0)
                            .ToList());

                bindingSource.DataSource =
                    filtered;
            }

            dgvProducts.ClearSelection();
        }

        private void exportCsvToolStripMenuItem_Click(
            object? sender,
            EventArgs e)
        {
            ExportCsv();
        }

        private void ExportCsv()
        {
            if (products.Count == 0)
            {
                MessageBox.Show(
                    "Danh sách sản phẩm đang trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using SaveFileDialog dialog =
                new SaveFileDialog();

            dialog.Title =
                "Xuất danh sách sản phẩm";

            dialog.Filter =
                "CSV Files|*.csv";

            dialog.FileName =
                "TechMart_Products.csv";

            if (dialog.ShowDialog() !=
                DialogResult.OK)
                return;

            try
            {
                using StreamWriter writer =
                    new StreamWriter(
                        dialog.FileName,
                        false,
                        new UTF8Encoding(true));

                writer.WriteLine(
                    "Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");

                foreach (Product product in products)
                {
                    writer.WriteLine(
                        "\"" +
                        EscapeCsv(product.ProductId) +
                        "\"," +

                        "\"" +
                        EscapeCsv(product.ProductName) +
                        "\"," +

                        "\"" +
                        EscapeCsv(product.CategoryName) +
                        "\"," +

                        product.UnitPrice.ToString("0") +
                        "," +

                        product.Quantity);
                }

                MessageBox.Show(
                    "Xuất CSV thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể xuất file:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string value)
        {
            return value.Replace("\"", "\"\"");
        }

        private void exitToolStripMenuItem_Click(
            object? sender,
            EventArgs e)
        {
            Close();
        }

        private void UpdateStatus()
        {
            lblStatus.Text =
                "Tổng số sản phẩm: " +
                products.Count;
        }
    }
}