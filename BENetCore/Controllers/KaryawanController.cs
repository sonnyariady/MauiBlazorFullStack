using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KaryawanApi.Data;
using KaryawanApi.Models;


[ApiController]
[Route("api/[controller]")]
public class KaryawanController : ControllerBase
{
    private readonly AppDbContext _context;
    public KaryawanController(AppDbContext context) => _context = context;


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] Karyawan karyawan)
    {
        _context.Karyawan.Add(karyawan);
        await _context.SaveChangesAsync();
        return Ok(karyawan);
    }


    [HttpPut("update/{nik}")]
    public async Task<IActionResult> Update(string nik, [FromBody] Karyawan karyawan)
    {
        var data = await _context.Karyawan.FindAsync(nik);
        if (data == null) return NotFound();


        data.Nama = karyawan.Nama;
        data.Jabatan = karyawan.Jabatan;
        data.Telp = karyawan.Telp;
        data.Divisi = karyawan.Divisi;
        data.Alamat = karyawan.Alamat;
        await _context.SaveChangesAsync();
        return Ok(data);
    }


    [HttpGet("get/{nik}")]
    public async Task<IActionResult> Get(string nik)
    {
        var data = await _context.Karyawan.FindAsync(nik);
        if (data == null) return NotFound();
        return Ok(data);
    }


    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() => Ok(await _context.Karyawan.ToListAsync());


    [HttpDelete("delete/{nik}")]
    public async Task<IActionResult> Delete(string nik)
    {
        var data = await _context.Karyawan.FindAsync(nik);
        if (data == null) return NotFound();
        _context.Karyawan.Remove(data);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Deleted" });
    }
}