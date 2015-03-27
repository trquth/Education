using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education
{
    abstract class Education
    {
        public string hoTen { get; protected set; }
        public string canBo { get; protected set; }
        public string trinhDo { get; protected set; }
        public int phuCap { get; protected set; }
        public int soTiet { get; protected set; }
        public float heSo { get; protected set; }
        public string phongBan { get; protected set; }
        public int ngayCong { get; protected set; }
        public string khoa { get; protected set; }
        public float luong { get; protected set; }
        protected Education()
        {
        }
 
        public bool TimKiem(string chuoi1, string chuoi2)
        {
            if (chuoi1 == Program.TachChuoi(this.hoTen) && chuoi2 ==this.phongBan)
                return true;
            else
                return false;
        }
 
    }
    class GiangVien : Education
    {
        public GiangVien(string hoTen, string canBo, string khoa, string trinhDo,int phuCap, int soTiet, float heSo, float luong) : base() { this.hoTen = hoTen;this.canBo = canBo; this.khoa = khoa; this.trinhDo = trinhDo; this.phuCap = phuCap; this.soTiet = soTiet; this.heSo = heSo; this.luong = luong; }
    }
    class NhanVien : Education
    {
        public NhanVien(string hoTen, string canBo, string phongBan, int ngayCong , string trinhDo, int phuCap, float heSo, float luong) : base() {this.hoTen = hoTen; this.canBo = canBo; this.phongBan = phongBan; this.ngayCong = ngayCong; ; this.trinhDo = trinhDo; this.phuCap = phuCap; this.heSo = heSo;this.luong = luong; }
    }
    class Program
    {
        private static List<Education> list;
        private static bool exit = false;
        //private static Education Worker;
        private static int i = 1;
        static void Main(string[] args)
        {
            list = new List<Education>(0);
            while (!exit)
            {
                Console.WriteLine("1. Nhap du lieu can bo");
                Console.WriteLine("2. Thuc hien viec tim kiem");
                Console.WriteLine("3. Xuat ra danh sach va sap xep");
                Console.Write("Chon cau: ");
                string dk = Console.ReadLine();
                switch (dk)
                {
                    case "1":
                Console.WriteLine("1. Nhap du lieu can bo");
                CreateNewWorker(list);
                        break;
                    case "2":
                Console.WriteLine("--------------------------");
                Console.WriteLine("2. Thuc hien viec tim kiem");
                Console.WriteLine("--------------------------");
                Console.Write("\tNhap ten can tim kiem: ");
                string tenrieng = Console.ReadLine();
                Console.Write("\tNhap phong can tim kiem: ");
                string phongban = Console.ReadLine();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TimKiem(tenrieng, phongban) == true)
                        PrintWork(i + 1, list[i]);
                }
                        break;
                    case "3":
                Console.WriteLine("--------------------------");
                Console.WriteLine("3. Xuat ra danh sach va sap xep");
                Console.WriteLine("--------------------------");
 
                var lengths = from element in list
                              orderby element.luong, TachChuoi(element.hoTen)
                              select element;
 
                foreach (Education value in lengths)
                {
                    PrintWork(i, value);
                    i++;
                }
                Console.WriteLine("--------------------------");
                break;
                    default:
                        break;
                }
            }
        }
        public static string TachChuoi(string chuoi)
        {
            string ten;
            string[] arr = chuoi.Split(' ');
            if (arr.Length >= 2)
            {
                ten = arr[arr.Length - 1];
                return ten;
            }
            return "Khong tim thay";
        }
        private static void CreateNewWorker(List<Education> list)
        {
            list.Clear();
            Console.Write("Nhap so luong: ");
            string sl = Console.ReadLine();
            for (int i = 1; i <= Convert.ToInt32(sl); i++)
            {
                //-------PHAN CHUNG------------
                Console.WriteLine("------------------------------------------");
                Console.Write("Nhap Ho Ten " + i + ": ");
                string hoTen = Console.ReadLine();
                Console.WriteLine("Can bo:\n1. Giang Vien\n2. Nhan Vien");
                Console.Write("Nhap Can bo: ");
                string canBo = Console.ReadLine();
                Console.Write("\tNhap He so :");
                float heSo = float.Parse(Console.ReadLine());
                //-------PHAN RIENG------------
                if (canBo == "1")
                {
                    Console.Write("\tNhap Khoa :");
                    string khoa = Console.ReadLine();
                    Console.Write("Trinh do:\n1. Cu Nhan\n2. Thac si\n3.TienSi\n\tNhap trinh do :");
                    int trinhDo = int.Parse(Console.ReadLine());
                    Console.Write("\tNhap So tiet :");
                    int soTiet = int.Parse(Console.ReadLine());
                    float luong = heSo * 730 + KiemTraPhuCap(trinhDo) + soTiet * 45;
                    list.Add(new GiangVien(hoTen, "GiangVien", khoa, KiemTraTrinhDo(trinhDo), KiemTraPhuCap(trinhDo), soTiet, heSo, luong));
                }
                else if (canBo == "2")
                {
                    Console.Write("\tNhap Phong :");
                    string phongBan = Console.ReadLine();
                    Console.Write("Chuc vu:\n4. Truong Phong\n5. Pho Phong\n6.Nhan vien\n\tNhap Chuc vu :");
                    int trinhDo = int.Parse(Console.ReadLine());
                    Console.Write("\tNhap so ngay cong :");
                    int ngayCong = int.Parse(Console.ReadLine());
                    float luong = heSo * 730 + KiemTraPhuCap(trinhDo) + ngayCong * 30;
                    list.Add(new NhanVien(hoTen, "NhanVien", phongBan, ngayCong, KiemTraTrinhDo(trinhDo), KiemTraPhuCap(trinhDo), heSo, luong));
                }
                else return;
            }
        }
        private static void PrintWork(int number, Education Worker)
        {
            if (Worker.canBo == "GiangVien")
                Console.WriteLine("{0} HoTen: {1}, CanBo: {2}, Phong: {3}, Khoa: {4}, Trinh Do: {5}, Phu cap: {6}, So Tiet: {7}, Ngay Cong: {8}, He So: {9}, Luong: {10}", number, Worker.hoTen, Worker.canBo, Worker.phongBan, Worker.khoa, Worker.trinhDo, Worker.phuCap, Worker.soTiet, Worker.ngayCong, Worker.heSo, Worker.luong);
            if (Worker.canBo == "NhanVien")
                Console.WriteLine("{0} HoTen: {1}, CanBo: {2}, Phong: {3}, Khoa: {4}, Trinh Do: {5}, Phu cap: {6}, So Tiet: {7}, Ngay Cong: {8}, He So: {9}, Luong: {10}", number, Worker.hoTen, Worker.canBo, Worker.phongBan, Worker.khoa, Worker.trinhDo, Worker.phuCap, Worker.soTiet, Worker.ngayCong, Worker.heSo, Worker.luong);
        }
 
        public enum TrinhDo { CuNhan = 1, ThacSi = 2, TienSy = 3, TruongPhong = 4, PhoPhong = 5, NhanVien = 6 }
        public static int KiemTraPhuCap(int trinhDo)
        {
            if (trinhDo == 1)
                return 300;
            else if (trinhDo == 2 || trinhDo == 6)
                return 500;
            else if (trinhDo == 3 || trinhDo == 5)
                return 1000;
            return 2000;
        }
 
        public static string KiemTraTrinhDo(int trinhDo)
        {
            if (trinhDo == 1) return TrinhDo.CuNhan.ToString();
            if (trinhDo == 2) return TrinhDo.ThacSi.ToString();
            if (trinhDo == 3) return TrinhDo.TienSy.ToString();
            if (trinhDo == 4) return TrinhDo.TruongPhong.ToString();
            if (trinhDo == 5) return TrinhDo.PhoPhong.ToString();
            return TrinhDo.NhanVien.ToString(); ;
        }
    }
}
