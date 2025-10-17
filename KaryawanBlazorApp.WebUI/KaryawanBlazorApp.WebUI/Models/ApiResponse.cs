
using System.Net;

namespace KaryawanBlazorApp.WebUI.Models;

public class ApiResponse<T>
{
    public bool IsSuccess => (int)StatusCode == 200 && ErrorMessage == null;
    public HttpStatusCode StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
}
