
using System.Net;
using System.Net.Http.Json;
using KaryawanBlazorApp.WebUI.Models;

namespace KaryawanBlazorApp.WebUI.Services;

public class KaryawanApiClient
{
    private readonly HttpClient _http;

    public KaryawanApiClient(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<ApiResponse<List<Karyawan>>> GetAllAsync()
    {
        try
        {
            var resp = await _http.GetAsync("/api/Karyawan/getall");
            var wrapper = new ApiResponse<List<Karyawan>> { StatusCode = resp.StatusCode };
            if (resp.IsSuccessStatusCode)
            {
                wrapper.Data = await resp.Content.ReadFromJsonAsync<List<Karyawan>>();
            }
            else
            {
                wrapper.ErrorMessage = await resp.Content.ReadAsStringAsync();
            }
            return wrapper;
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<Karyawan>> { StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<Karyawan>> GetAsync(string nik)
    {
        try
        {
            var resp = await _http.GetAsync($"/api/Karyawan/get/{Uri.EscapeDataString(nik)}");
            var wrapper = new ApiResponse<Karyawan> { StatusCode = resp.StatusCode };
            if (resp.IsSuccessStatusCode)
            {
                wrapper.Data = await resp.Content.ReadFromJsonAsync<Karyawan>();
            }
            else
            {
                wrapper.ErrorMessage = await resp.Content.ReadAsStringAsync();
            }
            return wrapper;
        }
        catch (Exception ex)
        {
            return new ApiResponse<Karyawan> { StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<Karyawan>> CreateAsync(Karyawan model)
    {
        try
        {
            var resp = await _http.PostAsJsonAsync("/api/Karyawan/create", model);
            var wrapper = new ApiResponse<Karyawan> { StatusCode = resp.StatusCode };
            if (resp.IsSuccessStatusCode)
            {
                wrapper.Data = await resp.Content.ReadFromJsonAsync<Karyawan>();
            }
            else
            {
                wrapper.ErrorMessage = await resp.Content.ReadAsStringAsync();
            }
            return wrapper;
        }
        catch (Exception ex)
        {
            return new ApiResponse<Karyawan> { StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<Karyawan>> UpdateAsync(string nik, KaryawanUpdate model)
    {
        try
        {
            var resp = await _http.PutAsJsonAsync($"/api/Karyawan/update/{Uri.EscapeDataString(nik)}", model);
            var wrapper = new ApiResponse<Karyawan> { StatusCode = resp.StatusCode };
            if (resp.IsSuccessStatusCode)
            {
                wrapper.Data = await resp.Content.ReadFromJsonAsync<Karyawan>();
            }
            else
            {
                wrapper.ErrorMessage = await resp.Content.ReadAsStringAsync();
            }
            return wrapper;
        }
        catch (Exception ex)
        {
            return new ApiResponse<Karyawan> { StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message };
        }
    }

    public async Task<ApiResponse<bool>> DeleteAsync(string nik)
    {
        try
        {
            var resp = await _http.DeleteAsync($"/api/Karyawan/delete/{Uri.EscapeDataString(nik)}");
            var wrapper = new ApiResponse<bool> { StatusCode = resp.StatusCode };
            if (resp.IsSuccessStatusCode)
            {
                wrapper.Data = true;
            }
            else
            {
                wrapper.ErrorMessage = await resp.Content.ReadAsStringAsync();
                wrapper.Data = false;
            }
            return wrapper;
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool> { StatusCode = HttpStatusCode.InternalServerError, ErrorMessage = ex.Message, Data = false };
        }
    }
}
