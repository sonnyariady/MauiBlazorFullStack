
namespace KaryawanBlazorApp.WebUI.Models;

public class Karyawan
{
    public string NIK { get; set; } = string.Empty;
    public string Nama { get; set; } = string.Empty;
    public string Divisi { get; set; } = string.Empty;
    public string Jabatan { get; set; } = string.Empty;
    public string Alamat { get; set; } = string.Empty;
    public string Telp { get; set; } = string.Empty;
}

public class KaryawanUpdate
{
    // NIK intentionally omitted for update payload
    public string Nama { get; set; } = string.Empty;
    public string Divisi { get; set; } = string.Empty;
    public string Jabatan { get; set; } = string.Empty;
    public string Alamat { get; set; } = string.Empty;
    public string Telp { get; set; } = string.Empty;
}
