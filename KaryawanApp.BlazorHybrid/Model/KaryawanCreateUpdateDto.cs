using System.ComponentModel.DataAnnotations;


namespace MauiBlazor.Karyawan.Models;


// Untuk CREATE: sertakan NIK. Untuk UPDATE: tanpa NIK (payload beda)
public class KaryawanCreateDto
{
    [Required]
    public string NIK { get; set; } = string.Empty;
    [Required]
    public string Nama { get; set; } = string.Empty;
    public string Divisi { get; set; } = string.Empty;
    public string Jabatan { get; set; } = string.Empty;
    public string Alamat { get; set; } = string.Empty;
}


public class KaryawanUpdateDto
{
    [Required]
    public string Nama { get; set; } = string.Empty;
    public string Divisi { get; set; } = string.Empty;
    public string Jabatan { get; set; } = string.Empty;
    public string Alamat { get; set; } = string.Empty;
}