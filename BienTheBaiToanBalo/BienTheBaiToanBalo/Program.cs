using System;
using System.Collections.Generic;

class ChuongTrinh
{
    static void Main(string[] args)
    {
        List<MatHang> matHang = new List<MatHang>
        {
            new MatHang { GiaTri = 60, TrongLuong = 10, SoLuong = 2 },
            new MatHang { GiaTri = 100, TrongLuong = 20, SoLuong = 1 },
            new MatHang { GiaTri = 120, TrongLuong = 30, SoLuong = 3 }
        };

        int sucChua = 50;

        double giaTriToiDa = ThuatToanThamLam(sucChua, matHang);
        Console.WriteLine("Gia tri toi da trong Ba lo = " + giaTriToiDa);
    }

    public class MatHang
    {
        public int GiaTri { get; set; }
        public int TrongLuong { get; set; }
        public int SoLuong { get; set; }
        public double TiLe { get { return (double)GiaTri / TrongLuong; } }
    }

    public static double ThuatToanThamLam(int sucChua, List<MatHang> matHang)
    {
        // Sap xep cac mat hang theo ti le gia tri/trong luong giam dan
        matHang.Sort((x, y) => y.TiLe.CompareTo(x.TiLe));

        double tongGiaTri = 0;
        int trongLuongHienTai = 0;

        foreach (var hang in matHang)
        {
            int soLuongConLai = hang.SoLuong;
            while (soLuongConLai > 0 && trongLuongHienTai + hang.TrongLuong <= sucChua)
            {
                trongLuongHienTai += hang.TrongLuong;
                tongGiaTri += hang.GiaTri;
                soLuongConLai--;
            }

            if (soLuongConLai > 0 && trongLuongHienTai < sucChua)
            {
                int trongLuongConLai = sucChua - trongLuongHienTai;
                if (trongLuongConLai > 0)
                {
                    tongGiaTri += hang.GiaTri * ((double)trongLuongConLai / hang.TrongLuong);
                    trongLuongHienTai = sucChua;
                }
            }

            if (trongLuongHienTai >= sucChua)
                break;
        }

        return tongGiaTri;
    }
}
