using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO
{
    public class Scores
    {
        public Scores (int idhocsinh,int idmonhoc,float diemchuyencan,float diemtrungbinhkiemtra,float diemthi,float diemtrungbinh,int idgiaovien)
        {
          
            this.IDHocSinh = idhocsinh;          
            this.IDMonHoc = idmonhoc;
            this.Diemchuyencan = diemchuyencan;
            this.Diemtrungbinhkiemtra = diemtrungbinhkiemtra;
            this.Diemthi = diemthi;
            this.Diemtrungbinh = diemtrungbinh;
            this.IdGiaoVien = idgiaovien;
        }
        public Scores(DataRow row)
        {
            try
            {
                this.IDHocSinh = (int)row["idhocsinh"];
                this.iDMonHoc = (int)row["idmonhoc"];
                this.Diemchuyencan = (float)Convert.ToDouble(row["diemchuyencan"].ToString());
                this.Diemtrungbinhkiemtra = (float)Convert.ToDouble(row["diemtrungbinhkiemtra"].ToString());
                this.Diemthi = (float)Convert.ToDouble(row["DiemThi"].ToString());
                this.Diemtrungbinh = (float)Convert.ToDouble(row["Diemtrungbinh"].ToString());
                this.TenMonHoc = row["name"].ToString();
                this.TenHocSinh = row["ten hoc sinh"].ToString();
                this.IdGiaoVien = (int)row["idgiaovien"];
            }
            catch { }
        }

        public Scores()
        {
        }

        private int iDHocSinh;
        private int iDMonHoc;
        private float diemchuyencan;
        private float diemtrungbinhkiemtra;
        private float diemthi;
        private float diemtrungbinh;
        private string tenMonHoc;
        private string tenHocSinh;
        private int idGiaoVien;

        public int IDHocSinh { get => iDHocSinh; set => iDHocSinh = value; }
        public int IDMonHoc { get => iDMonHoc; set => iDMonHoc = value; }
     
        public float Diemthi { get => diemthi; set => diemthi = value; }
        public float Diemtrungbinh { get => diemtrungbinh; set => diemtrungbinh = value; }
        public string TenMonHoc { get => tenMonHoc; set => tenMonHoc = value; }
        public string TenHocSinh { get => tenHocSinh; set => tenHocSinh = value; }
        public int IdGiaoVien { get => idGiaoVien; set => idGiaoVien = value; }
        public float Diemchuyencan { get => diemchuyencan; set => diemchuyencan = value; }
        public float Diemtrungbinhkiemtra { get => diemtrungbinhkiemtra; set => diemtrungbinhkiemtra = value; }
    }
}
