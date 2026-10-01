using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trần_Hoài_Nam_24810320642
{
    public abstract class PhuongTien
    {
        private string _maPT = "";
        private string _tenHang = "";
        private int _namSanXuat;
        private double _giaGoc;

        public string MaPT
        {
            get => _maPT;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Mã phương tiện không được để trống!");

                _maPT = value;
            }
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Tên hãng không được để trống!");

                _tenHang = value;
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new Exception("Năm sản xuất không hợp lệ!");

                _namSanXuat = value;
            }
        }

        public double GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new Exception("Giá gốc phải lớn hơn 0!");

                _giaGoc = value;
            }
        }

        protected PhuongTien(
            string maPT,
            string tenHang,
            int namSanXuat,
            double giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        public abstract double TinhGiaLanBanh();

        public virtual string GetInfo()
        {
            return $"Mã: {MaPT} | Hãng: {TenHang} | " +
                   $"Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0}";
        }
    }

    public class OTo : PhuongTien
    {
        public int SoCho { get; set; }
        public double DungTichDongCo { get; set; }

        public OTo(
            string maPT,
            string tenHang,
            int namSanXuat,
            double giaGoc,
            int soCho,
            double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            if (soCho <= 0)
                throw new Exception("Số chỗ phải lớn hơn 0!");

            if (dungTichDongCo <= 0)
                throw new Exception("Dung tích động cơ phải lớn hơn 0!");

            SoCho = soCho;
            DungTichDongCo = dungTichDongCo;
        }

        public override double TinhGiaLanBanh()
        {
            if (SoCho <= 9)
                return GiaGoc * 1.42;

            return GiaGoc * 1.10;
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $" | Số chỗ: {SoCho}" +
                   $" | Động cơ: {DungTichDongCo}";
        }
    }

    public class XeMay : PhuongTien
    {
        public double DungTich { get; set; }

        public XeMay(
            string maPT,
            string tenHang,
            int namSanXuat,
            double giaGoc,
            double dungTich)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            if (dungTich <= 0)
                throw new Exception("Dung tích phải lớn hơn 0!");

            DungTich = dungTich;
        }

        public override double TinhGiaLanBanh()
        {
            if (DungTich < 175)
                return GiaGoc * 1.02;

            return GiaGoc * 1.05;
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $" | Dung tích: {DungTich}cc";
        }
    }

    public class QuanLyPhuongTien
    {
        private List<PhuongTien> danhSach =
            new List<PhuongTien>();

        public List<PhuongTien> DanhSach
        {
            get { return danhSach; }
        }

        public void ThemPhuongTien(PhuongTien pt)
        {
            if (pt != null)
                danhSach.Add(pt);
        }

        public PhuongTien? FindMaxGiaLanBanh()
        {
            if (danhSach.Count == 0)
                return null;

            return danhSach
                .OrderByDescending(x => x.TinhGiaLanBanh())
                .First();
        }

        public List<PhuongTien> TimTheoTen(string ten)
        {
            return danhSach
                .Where(x =>
                    x.TenHang
                    .ToLower()
                    .Contains(ten.ToLower()))
                .ToList();
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChayKiemThu()
        {
            QuanLyPhuongTien ql =
                new QuanLyPhuongTien();

            string kq = "";

            // TC01
            try
            {
                new OTo(
                    "OT01",
                    "Toyota",
                    1850,
                    1000000000,
                    5,
                    2000);

                kq +=
                    "TC01 - Năm sản xuất không hợp lệ: FAIL\r\n";
            }
            catch (Exception ex)
            {
                kq +=
                    "TC01 - Năm sản xuất không hợp lệ: PASS\r\n";

                kq +=
                    "       " + ex.Message + "\r\n\r\n";
            }

            // TC02
            OTo toyota = new OTo(
                "OT02",
                "Toyota",
                2024,
                1000000000,
                5,
                2000);

            ql.ThemPhuongTien(toyota);

            kq += "TC02 - Toyota 5 chỗ:\r\n";
            kq += "       Giá gốc: 1.000.000.000\r\n";
            kq +=
                "       Giá lăn bánh: " +
                toyota.TinhGiaLanBanh().ToString("N0") +
                "\r\n\r\n";

            // TC03
            XeMay honda = new XeMay(
                "XM01",
                "Honda",
                2024,
                50000000,
                150);

            ql.ThemPhuongTien(honda);

            kq += "TC03 - Honda 150cc:\r\n";
            kq += "       Giá gốc: 50.000.000\r\n";
            kq +=
                "       Giá lăn bánh: " +
                honda.TinhGiaLanBanh().ToString("N0") +
                "\r\n\r\n";

            // TC04
            kq += "TC04 - Kiểm tra đa hình:\r\n";

            foreach (PhuongTien pt in ql.DanhSach)
            {
                kq +=
                    "       " +
                    pt.GetInfo() +
                    "\r\n";

                kq +=
                    "       Giá lăn bánh: " +
                    pt.TinhGiaLanBanh().ToString("N0") +
                    "\r\n";
            }

            kq += "\r\n";

            // TC05
            PhuongTien? max =
                ql.FindMaxGiaLanBanh();

            kq +=
                "TC05 - Phương tiện có giá lăn bánh cao nhất:\r\n";

            if (max != null)
            {
                kq +=
                    "       " +
                    max.GetInfo() +
                    "\r\n";

                kq +=
                    "       Giá lăn bánh: " +
                    max.TinhGiaLanBanh().ToString("N0");
            }

            txtKetQua.Text = kq;
        }

        private void btnKiemThu_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                ChayKiemThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            txtKetQua.Clear();
        }

        private void btnThoat_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}