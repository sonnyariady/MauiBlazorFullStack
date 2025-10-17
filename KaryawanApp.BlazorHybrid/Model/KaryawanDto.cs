using System.ComponentModel.DataAnnotations;


namespace MauiBlazor.Karyawan.Models;


public class KaryawanDto
{
    [Required]
    public string NIK { get; set; } = string.Empty;
    [Required]
    public string Nama { get; set; } = string.Empty;
    public string Divisi { get; set; } = string.Empty;
    public string Jabatan { get; set; } = string.Empty;
    public string Alamat { get; set; } = string.Empty;
}