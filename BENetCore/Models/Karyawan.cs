using System.ComponentModel.DataAnnotations;

namespace KaryawanApi.Models
{
    public class Karyawan
    {
        [Key]
        public string NIK { get; set; } = string.Empty;
        public string? Nama { get; set; }
        public string? Jabatan { get; set; }
        public string? Divisi { get; set; }
        public string? Telp { get; set; }
        public string? Alamat { get; set; }
    }
}
