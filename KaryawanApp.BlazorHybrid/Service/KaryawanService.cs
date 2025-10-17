using System.Net.Http.Json;
using KaryawanApp.BlazorHybrid.Entity;
using Microsoft.Extensions.Configuration; // tambahkan ini

public class KaryawanService
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public KaryawanService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _baseUrl = config["ApiBaseUrl"];
    }

    public async Task<List<Karyawan>> GetAll() =>
        await _http.GetFromJsonAsync<List<Karyawan>>($"{_baseUrl}api/Karyawan/getall");

    public async Task<Karyawan?> GetDetails(string nik) {
        string url = $"{_baseUrl}api/Karyawan/get/{nik}";
        var result = await _http.GetFromJsonAsync<Karyawan>(url);
        return result;
    }
        

    public async Task Create(Karyawan karyawan) =>
        await _http.PostAsJsonAsync($"{_baseUrl}api/Karyawan/create", karyawan);

    public async Task Update(string nik, Karyawan karyawan) =>
        await _http.PutAsJsonAsync($"{_baseUrl}api/Karyawan/update/{nik}", karyawan);

    public async Task Delete(string nik) =>
        await _http.DeleteAsync($"{_baseUrl}api/Karyawan/delete/{nik}");
}
